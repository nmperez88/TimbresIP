using Newtonsoft.Json;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using TimbresIP.Common;
using TimbresIP.Model;
using TimbresIP.Utils;

namespace TimbresIP.Controller
{
    /// <summary>
    /// Controlador principal.
    /// </summary>
    class MainController : BaseUtils
    {

        /// <summary>
        /// Programador de trabajos para ejecutar las llamadas.
        /// </summary>
        private IScheduler scheduler;

        /// <summary>
        /// Variable que agrupa los trabajos en un grupo.
        /// </summary>
        private String groupJobs = Properties.Settings.Default.groupJobs != null ? Properties.Settings.Default.groupJobs : "sta";

        /// <summary>
        /// Sistema de Timbres Automáticos.
        /// </summary>
        private AutomaticRingSystemModel automaticRingSystem;

        /// <summary>
        /// Sistema de Timbres Automáticos. Objeto para comparar.
        /// </summary>
        private String automaticRingSystemToMatchSerialized;

        /// <summary>
        /// Lista de timbres a ejecutar.
        /// </summary>
        private AutomaticRingSystemModel automaticRingSystemToExecute = new AutomaticRingSystemModel();

        /// <summary>
        /// Ruta de archivo Json.
        /// </summary>
        private String jsonFileFullPath;

        /// <summary>
        /// Ruta de archivo Json encriptado.
        /// </summary>
        private String jsonFileFullPathEncrypted;

        ///// <summary>
        ///// SoftPhone.
        ///// </summary>
        //private SoftPhoneUtils softPhoneUtils;

        /// <summary>
        /// Mapa de llamadas. identificador de trabajo(idJob) y su llamada(SoftPhone) asociada.
        /// </summary>
        private Dictionary<string, SoftPhoneUtils> softPhoneUtilsMap = new Dictionary<string, SoftPhoneUtils>();

        ///// <summary>
        ///// Mapa de llamadas. identificador de trabajo(idJob).
        ///// </summary>
        //private List<string> softPhoneUtilsList = new List<string>();

        ///// <summary>
        ///// Lista de horas en las que debe ejecutarse un timbre.
        ///// </summary>
        ///// <remarks>
        /////  Construir estructura que permita chequear de forma rápida utilizando quartz.
        ///// </remarks>
        //private List<String> plannedHours;

        /// <summary>
        /// Inicializar datos de la aplicación.
        /// </summary>
        public void init()
        {

            //callsRunningJsonFileFullPath = validateEntriesUtils.getProgramDataPath() + "\\" + Properties.Settings.Default.callsRunning + Properties.Settings.Default.jsonExtension;

            jsonFileFullPath = validateEntriesUtils.getProgramDataPath() + "\\" + Properties.Settings.Default.jsonFileName + Properties.Settings.Default.jsonExtension;
            jsonFileFullPathEncrypted = jsonFileFullPath + Properties.Settings.Default.encryptedExtension;

            if (System.IO.File.Exists(jsonFileFullPathEncrypted))
            {
                cypherUtils.FileDecrypt(jsonFileFullPathEncrypted, jsonFileFullPath, Properties.Settings.Default.cypherPassword);
                jsonHandlerUtils = new JsonHandlerUtils(jsonFileFullPath, "TimbresIP.Model.AutomaticRingSystemModel");
                automaticRingSystem = (AutomaticRingSystemModel)jsonHandlerUtils.deserialize();
                try
                {
                    System.IO.File.Delete(jsonFileFullPath);
                }
                catch (Exception e)
                {
                    log.Error("Intentando eliminar archivo json", e);
                }
            }
            else
            {
                log.Info("El archivo JSON encriptado no existe.");
                automaticRingSystem = new AutomaticRingSystemModel();
            }

            //Asignar objeto para validar.
            automaticRingSystemToMatchSerialized = JsonConvert.SerializeObject(automaticRingSystem);

            //Fueron asignados los parámetros de conexión al servidor.
            if (hasServerParams())
            {

                //Hay horarios configurados?.
                if (automaticRingSystem.horaryList.Any())
                {
                    automaticRingSystem.horaryList.ForEach(h =>
                    {
                        //Tiene el horario definidos los parámetros para llamar al servidor?.
                        if (hasHoraryConnectionCallServerParams(h))
                        {
                            //Crear lista con llamadas al servidor habilitadas.
                            List<CallServerModel> callServerList = h.callServerList.Where(cs =>
                            {
                                //Tiene llamadas habilitadas?.
                                if (cs.enabled)
                                {
                                    //Existe archivo de sonido.
                                    Boolean existSoundFile = System.IO.File.Exists(cs.soundFile.targetPath);

                                    //Deshabilitar horario en caso de no existir archivo de sonido.
                                    if (!existSoundFile)
                                    {
                                        cs.enabled = false;
                                    }

                                    return existSoundFile;
                                }
                                return false;

                            }).ToList();

                            //Tiene llamadas al servidor habilitadas y existe el archivo de sonido?.
                            if (callServerList.Any())
                            {
                                //Agregar horario.
                                HoraryModel horary = new HoraryModel(h.name, h.randomId, callServerList, h.connectionCallServer);
                                automaticRingSystemToExecute.horaryList.Add(horary);
                            }
                        }
                    });
                }
            }

        }

        /// <summary>
        /// Iniciar.
        /// </summary>
        public void start()
        {
            runJobs();
        }

        /// <summary>
        /// Detener programador de llamadas.
        /// </summary>
        public async void stop()
        {
            stopScheduler();
        }

        /// <summary>
        /// Ejecutar hilo que lanza llamadas al servidor en hora determinada.
        /// </summary>
        private void runJobs()
        {
            if (automaticRingSystemToExecute.horaryList.Any())
            {
                initScheduler();
                startScheduler();
                startJobs();
            }
        }

        /// <summary>
        /// Inicializar softPhone.
        /// </summary>
        //private void initSoftPhone()
        //{
        //    instanceSoftPhone();
        //}

        /// <summary>
        /// Instanciar softPhone.
        /// </summary>
        //private void instanceSoftPhone()
        //{
        //    if (softPhoneUtils == null)
        //    {
        //        softPhoneUtils = new SoftPhoneUtils();
        //    }

        //}

        /// <summary>
        /// Inicializar programador de llamadas.
        /// </summary>
        private async void initScheduler()
        {
            //Variables de configuración.
            NameValueCollection prop = new NameValueCollection
            {
                { "quartz.serializer.type", "binary" }
            };

            //Inicializar.
            StdSchedulerFactory stdSchedulerFactory = new StdSchedulerFactory(prop);
            scheduler = await stdSchedulerFactory.GetScheduler();
        }

        /// <summary>
        /// Iniciar programador de llamadas.
        /// </summary>
        private async void startScheduler()
        {
            await scheduler.Start();
        }

        /// <summary>
        /// Detener programador de llamadas.
        /// </summary>
        private async void stopScheduler()
        {
            if (scheduler != null)
            {
                await scheduler.Shutdown();
            }
        }

        /// <summary>
        /// Iniciar trabajos.
        /// </summary>
        private async void startJobs()
        {
            //initSoftPhone();

            foreach (var h in automaticRingSystemToExecute.horaryList)
            {
                foreach (var cs in h.callServerList)
                {
                    startJobs(h, cs, false);
                }
            }
        }

        /// <summary>
        /// Iniciar trabajo ahora.
        /// </summary>
        /// <param name="horary">
        /// Horario.
        /// </param>
        /// <param name="callServer">
        /// Llamada al servidor.
        /// </param>
        /// <param name="startNow">
        /// Iniciar ahora. Por defecto falso.
        /// </param>
        private async void startJobs(HoraryModel horary, CallServerModel callServer, Boolean startNow = false)
        {
            if (startNow)
            {
                if (scheduler == null || scheduler.IsShutdown)
                {
                    initScheduler();
                    startScheduler();
                }
            }

            SoftPhoneUtils softPhoneUtils = new SoftPhoneUtils();

            String idJob = horary.randomId + callServer.randomId + (startNow ? "now" : "");
            String hour = startNow ? "00" : callServer.startAt.Substring(0, 2);//start:"12:30:10"
            String min = startNow ? "00" : callServer.startAt.Substring(3, 2);
            String sec = startNow ? "00" : callServer.startAt.Substring(6);

            if (softPhoneUtilsMap.ContainsKey(idJob))
            {
                softPhoneUtilsMap[idJob] = softPhoneUtils;

            }
            else
            {
                softPhoneUtilsMap.Add(idJob, softPhoneUtils);
            }

            //if (!softPhoneUtilsList.Contains(idJob))
            //{
            //    softPhoneUtilsList.Add(idJob);
            //}
            if (startNow)
            {
                getCallsRunningUtils();
                if (!callsRunningUtils.idsList.Contains(idJob))
                {
                    callsRunningUtils.idsList.Add(idJob);
                }
                setCallsRunningUtils();
            }

            JobDataMap jobDataMap = new JobDataMap();
            //softPhoneUtils.jobDataCommon = new JobDataCommon(automaticRingSystem.registrationRequired, automaticRingSystem.domainHost, automaticRingSystem.domainPort, horary.connectionCallServer, callServer, softPhoneUtilsList, idJob);
            softPhoneUtils.jobDataCommon = new JobDataCommon(automaticRingSystem.registrationRequired, automaticRingSystem.domainHost, automaticRingSystem.domainPort, horary.connectionCallServer, callServer, idJob);
            jobDataMap.Put("softPhone", JsonConvert.SerializeObject(softPhoneUtils));

            //Definir job.
            IJobDetail job = JobBuilder.Create<RingJobUtils>()
                .WithIdentity(idJob, groupJobs)
                .SetJobData(jobDataMap)
                .Build();

            //Disparador de trabajos.
            ITrigger trigger;
            if (startNow)
            {
                //Disparador de trabajos ahora.
                trigger = TriggerBuilder.Create()
                                .WithIdentity(idJob, groupJobs)
                                .StartNow()
                                .ForJob(idJob, groupJobs)
                                .Build();
            }
            else
            {
                //Disparador de trabajos a hora y minuto de lunes a viernes: "0 30 10 ? * WED,FRI"
                trigger = TriggerBuilder.Create()
                    .WithIdentity(idJob, groupJobs)
                    .WithCronSchedule(sec + " " + min + " " + hour + " ? * MON-FRI")
                    .ForJob(idJob, groupJobs)
                    .Build();
            }

            //Eliminar trabajo si existe
            if (await scheduler.CheckExists(new JobKey(idJob, groupJobs)))
            {
                await scheduler.DeleteJob(new JobKey(idJob, groupJobs));
            }

            //Asignar trigger a job en el programador de llamadas(scheduler)
            await scheduler.ScheduleJob(job, trigger);
            //Sintaxis para asignarle varios triggers a un treabajo.
            //await scheduler.ScheduleJob(objJob, new[] { trigger, trigger1, trigger2, trigger3 }, true);

        }

        /// <summary>
        /// Iniciar trabajo ahora.
        /// </summary>
        /// <param name="horary"></param>
        /// <param name="callServer"></param>
        public void startJobNow(HoraryModel horary, CallServerModel callServer)
        {
            String idJob = horary.randomId + callServer.randomId + "now";
            //if (!softPhoneUtilsList.Contains(idJob))
            //{
            //    startJobs(horary, callServer, true);
            //}
            getCallsRunningUtils();
            if (!callsRunningUtils.idsList.Contains(idJob))
            {
                startJobs(horary, callServer, true);
            }

        }

        /// <summary>
        /// Colgar llamada ahora.
        /// </summary>
        public void hangUpNow(HoraryModel horary, CallServerModel callServer)
        {
            String idJob = horary.randomId + callServer.randomId + "now";
            //if (softPhoneUtilsList.Contains(idJob))
            //{

            //    if (softPhoneUtilsMap.ContainsKey(idJob))
            //    {
            //        softPhoneUtilsMap[idJob].hangUpNow();
            //        softPhoneUtilsMap.Remove(idJob);
            //    }
            //    softPhoneUtilsList.Remove(idJob);
            //}
            if (callsRunningUtils.idsList.Contains(idJob))
            {

                if (softPhoneUtilsMap.ContainsKey(idJob))
                {
                    softPhoneUtilsMap[idJob].hangUpNow();
                    softPhoneUtilsMap.Remove(idJob);
                }
                callsRunningUtils.idsList.Remove(idJob);
            }
        }

        /// <summary>
        /// Tiene la aplicación definidos los parámetros de conexión al servidor?.
        /// </summary>
        /// <returns></returns>
        public bool hasServerParams()
        {
            return !automaticRingSystem.domainHost.Equals("") && !automaticRingSystem.domainPort.Equals(0);
        }

        /// <summary>
        /// Tiene el horario definidos los parámetros para llamar al servidor?.
        /// </summary>
        /// <param name="horary"></param>
        /// <returns></returns>
        private bool hasHoraryConnectionCallServerParams(HoraryModel horary)
        {
            return !horary.connectionCallServer.registerName.Equals("") && !horary.connectionCallServer.registerPassword.Equals("");
        }

        /// <summary>
        /// Obtener automaticRingSystem
        /// </summary>
        /// <returns></returns>
        public AutomaticRingSystemModel getAutomaticRingSystem()
        {
            return automaticRingSystem;
        }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public MainController()
        {
            init();
            start();
        }

        /// <summary>
        /// Salvar.
        /// </summary>
        public void save()
        {
            try
            {
                System.IO.File.WriteAllText(jsonFileFullPath, JsonConvert.SerializeObject(automaticRingSystem));
                cypherUtils.FileEncrypt(jsonFileFullPath, Properties.Settings.Default.cypherPassword);
            }
            catch (Exception e)
            {

                log.Error("Intentando guardar archivo json", e);
            }

            try
            {
                System.IO.File.Delete(jsonFileFullPath);
            }
            catch (Exception e)
            {
                log.Error("Intentando eliminar archivo json", e);
            }
        }

        /// <summary>
        /// Salvar y reiniciar.
        /// </summary>
        public void saveAndRestart()
        {
            save();
            stop();
            resetCallsRunningUtils();
            init();
            start();
        }

        public Boolean matchData()
        {
            return JsonConvert.SerializeObject(automaticRingSystem).CompareTo(automaticRingSystemToMatchSerialized) == 0;
        }

    }
}
