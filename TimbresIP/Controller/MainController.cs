using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimbresIP.Model;
using TimbresIP.Utils;
using TimbresIP.Common;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Calendar;
using Quartz.Impl.Matchers;
using Newtonsoft.Json;

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

        /// <summary>
        /// Gestiona contenido de archivo JSON.
        /// </summary>
        private JsonHandlerUtils jsonHandlerUtils;

        ///// <summary>
        ///// SoftPhone.
        ///// </summary>
        //private SoftPhoneUtils softPhoneUtils;

        /// <summary>
        /// Mapa de llamadas. identificador de trabajo(idJob) y su llamada(SoftPhone) asociada.
        /// </summary>
        private Dictionary<string, SoftPhoneUtils> softPhoneUtilsMap = new Dictionary<string, SoftPhoneUtils>();

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
                    //automaticRingSystemToExecute.registrationRequired = automaticRingSystem.registrationRequired;
                    //automaticRingSystemToExecute.domainHost = automaticRingSystem.domainHost;
                    //automaticRingSystemToExecute.domainPort = automaticRingSystem.domainPort;

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
                    //String idJob = h.randomId + cs.randomId;
                    //String hour = cs.startAt.Substring(0, 2);//start:"12:30"
                    //String min = cs.startAt.Substring(3);
                    //JobDataMap jobDataMap = new JobDataMap();
                    //softPhoneUtils.jobDataCommon = new JobDataCommon(automaticRingSystemToExecute.registrationRequired, automaticRingSystemToExecute.domainHost, automaticRingSystemToExecute.domainPort, h.connectionCallServer, cs);
                    //jobDataMap.Put("softPhone", JsonConvert.SerializeObject(softPhoneUtils));

                    ////Definir job.
                    //IJobDetail job = JobBuilder.Create<RingJobUtils>()
                    //    .WithIdentity(idJob, groupJobs)
                    //    //.UsingJobData("horary", JsonConvert.SerializeObject(h))
                    //    .SetJobData(jobDataMap)
                    //    .Build();

                    ////Disparador de trabajos a hora y minuto de lunes a viernes: "0 30 10 ? * WED,FRI"
                    //ITrigger trigger = TriggerBuilder.Create()
                    //    .WithIdentity(idJob, groupJobs)
                    //    //.WithCronSchedule("0 " + min + " " + hour + " ? * MON-FRI,SUN")
                    //    .WithCronSchedule("0 " + min + " " + hour + " ? * MON-FRI")
                    //    //.StartNow()
                    //    .ForJob(idJob, groupJobs)
                    //    .Build();

                    ////Eliminar trabajo si existe
                    //if (await scheduler.CheckExists(new JobKey(idJob, groupJobs)))
                    //{
                    //    await scheduler.DeleteJob(new JobKey(idJob, groupJobs));
                    //}

                    ////Asignar trigger a job en el programador de llamadas(scheduler)
                    //await scheduler.ScheduleJob(job, trigger);
                    ////Sintaxis para asignarle varios triggers a un treabajo.
                    ////await scheduler.ScheduleJob(objJob, new[] { trigger, trigger1, trigger2, trigger3 }, true);
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
                if (scheduler == null)
                {
                    initScheduler();
                    startScheduler();
                }
                //initSoftPhone();
            }

            SoftPhoneUtils softPhoneUtils = new SoftPhoneUtils();

            String idJob = horary.randomId + callServer.randomId + (startNow ? "now" : "");
            String hour = startNow ? "00" : callServer.startAt.Substring(0, 2);//start:"12:30:10"
            String min = startNow ? "00" : callServer.startAt.Substring(3, 2);
            String sec = startNow ? "00" : callServer.startAt.Substring(6);
            JobDataMap jobDataMap = new JobDataMap();
            softPhoneUtils.jobDataCommon = new JobDataCommon(automaticRingSystem.registrationRequired, automaticRingSystem.domainHost, automaticRingSystem.domainPort, horary.connectionCallServer, callServer);
            jobDataMap.Put("softPhone", JsonConvert.SerializeObject(softPhoneUtils));

            //if (startNow)
            //{
            //    if (softPhoneUtilsMap.ContainsKey(idJob))
            //    {
            //        idJobSoftPhoneRunningByCallNowMap[idJob] = softPhoneUtils;
            //    }
            //    else
            //    {
            //        idJobSoftPhoneRunningByCallNowMap.Add(idJob, softPhoneUtils);
            //    }

            //}

            if (softPhoneUtilsMap.ContainsKey(idJob))
            {
                softPhoneUtilsMap[idJob] = softPhoneUtils;
            }
            else
            {
                softPhoneUtilsMap.Add(idJob, softPhoneUtils);
            }

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
                    //.WithCronSchedule("0 " + min + " " + hour + " ? * MON-FRI,SUN")
                    //.WithCronSchedule("0 " + min + " " + hour + " ? * MON-FRI")
                    .WithCronSchedule(sec + " " + min + " " + hour + " ? * MON-FRI")
                    //.StartNow()
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
            startJobs(horary, callServer, true);
        }

        /// <summary>
        /// Colgar llamada ahora.
        /// </summary>
        public void hangUpNow(HoraryModel horary, CallServerModel callServer)
        {
            String idJob = horary.randomId + callServer.randomId + "now";
            if (softPhoneUtilsMap.ContainsKey(idJob))
            {
                softPhoneUtilsMap[idJob].hangUpNow();
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
            //Descomentar para probar. Este método debe llamarse luego de visualizar el formulario.
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
            init();
            start();
        }

        public Boolean matchData()
        {
            return JsonConvert.SerializeObject(automaticRingSystem).CompareTo(automaticRingSystemToMatchSerialized) == 0;
        }
    }
}
