using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimbresIP.Model;
using TimbresIP.Utils;
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
        /// Lista de timbres a ejecutar.
        /// </summary>
        private AutomaticRingSystemModel automaticRingSystemToExecute = new AutomaticRingSystemModel();

        /// <summary>
        /// Ruta de archivo Json.
        /// </summary>
        private String jsonFileFullPath;

        /// <summary>
        /// Gestiona contenido de archivo JSON.
        /// </summary>
        private JsonHandlerUtils jsonHandlerUtils;

        /// <summary>
        /// SoftPhone.
        /// </summary>
        private SoftPhoneUtils softPhoneUtils;

        /// <summary>
        /// Lista de horas en las que debe ejecutarse un timbre.
        /// </summary>
        /// <remarks>
        ///  Construir estructura que permita chequear de forma rápida utilizando quartz.
        /// </remarks>
        private List<String> plannedHours;

        /// <summary>
        /// Inicializar datos de la aplicación.
        /// </summary>
        public void init()
        {
            jsonFileFullPath = Properties.Settings.Default.jsonFolderDirectory + Properties.Settings.Default.jsonFileName + Properties.Settings.Default.jsonExtension;

            if (System.IO.File.Exists(jsonFileFullPath))
            {
                jsonHandlerUtils = new JsonHandlerUtils(jsonFileFullPath);
                automaticRingSystem = (AutomaticRingSystemModel)jsonHandlerUtils.deserialize();
            }
            else
            {
                log.Info("El archivo JSON no existe. Debe ser creado antes de guardar.");
                automaticRingSystem = new AutomaticRingSystemModel();
            }

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
                                HoraryModel horary = new HoraryModel();
                                horary = h;
                                horary.callServerList = callServerList;
                                automaticRingSystemToExecute.horaryList.Add(horary);
                            }
                        }
                    });
                }
            }

            runJobs();

        }

        /// <summary>
        /// Ejecutar hilo que lanza llamadas al servidor en hora determinada.
        /// </summary>
        private void runJobs()
        {
            initScheduler();
            startScheduler();
            startJobs();
        }

        /// <summary>
        /// Inicializar softPhone.
        /// </summary>
        private void initSoftPhone()
        {
            instanceSoftPhone();
        }

        /// <summary>
        /// Instanciar softPhone.
        /// </summary>
        private void instanceSoftPhone()
        {
            if (softPhoneUtils == null)
            {
                softPhoneUtils = new SoftPhoneUtils();
            }

        }

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
        public async void stopScheduler()
        {
            await scheduler.Shutdown();
        }

        /// <summary>
        /// 
        /// </summary>
        private async void startJobs()
        {
            initSoftPhone();

            foreach (var h in automaticRingSystemToExecute.horaryList)
            {
                foreach (var cs in h.callServerList)
                {
                    String idJob = h.randomId + cs.randomId;
                    String hour = cs.startAt.Substring(0, 2);//start:"12:30"
                    String min = cs.startAt.Substring(2);
                    JobDataMap jobDataMap = new JobDataMap();
                    jobDataMap.Put("registrationRequired", automaticRingSystemToExecute.registrationRequired);
                    jobDataMap.Put("domainHost", automaticRingSystemToExecute.domainHost);
                    jobDataMap.Put("domainPort", automaticRingSystemToExecute.domainPort);
                    jobDataMap.Put("connectionCallServer", JsonConvert.SerializeObject(h.connectionCallServer));
                    jobDataMap.Put("callServer", JsonConvert.SerializeObject(cs));
                    jobDataMap.Put("softPhone", softPhoneUtils);

                    //Definir job.
                    IJobDetail job = JobBuilder.Create<RingJobUtils>()
                        .WithIdentity(idJob, groupJobs)
                        //.UsingJobData("horary", JsonConvert.SerializeObject(h))
                        .SetJobData(jobDataMap)
                        .Build();

                    //// Trigger the job to run now, and then repeat every 10 seconds
                    //ITrigger trigger = TriggerBuilder.Create()
                    //    .WithIdentity(idJob, groupJobs)
                    //    .StartNow()
                    //    .WithSimpleSchedule(x => x
                    //        .WithIntervalInSeconds(2)
                    //        //.RepeatForever()
                    //        .WithRepeatCount(2)
                    //        )
                    //    .Build();

                    //DayOfWeek[] triggerParam = new DayOfWeek[]{
                    //    DayOfWeek.Monday,
                    //    DayOfWeek.Tuesday,
                    //    DayOfWeek.Wednesday,
                    //    DayOfWeek.Thursday,
                    //    DayOfWeek.Friday,
                    //    DayOfWeek.Sunday};// excluir Domingo(0). L-V 12345

                    //ITrigger trigger2 = TriggerBuilder.Create()
                    //    .WithIdentity("rings", "app")
                    //    //.ForJob("rings", groupJobs)
                    //    .WithSchedule(CronScheduleBuilder.AtHourAndMinuteOnGivenDaysOfWeek(hour, min, triggerParam))
                    //    //.ModifiedByCalendar("myHolidays") // but not on holidays
                    //    .Build();

                    //Disparador de trabajos a hora y minuto de lunes a viernes: "0 30 10 ? * WED,FRI"
                    ITrigger trigger = TriggerBuilder.Create()
                        .WithIdentity(idJob, groupJobs)
                        //.WithCronSchedule("0 " + min + " " + hour + " ? * MON-FRI,SUN")
                        .StartNow()
                        .ForJob(idJob, groupJobs)
                        .Build();

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
            }
        }

        /// <summary>
        /// Tiene la aplicación definidos los parámetros de conexión al servidor?.
        /// </summary>
        /// <returns></returns>
        private bool hasServerParams()
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
    }
}
