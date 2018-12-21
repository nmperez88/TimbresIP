using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimbresIP.Model;
using TimbresIP.Utils;
using Ozeki.Media;
using Ozeki.VoIP;


namespace TimbresIP.Controller
{
    /// <summary>
    /// Controlador principal.
    /// </summary>
    class MainController : BaseUtils
    {

        static ISoftPhone softphone;
        static IPhoneLine phoneLine;
        static IPhoneCall call;
        static MediaConnector connector;
        static PhoneCallAudioSender mediaSender;
        static MP3StreamPlayback mp3Player;

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

            //TODO Ejecutar hilo que ejecuta llamadas al servidor en hora determinada.
            runThread();

        }

        /// <summary>
        /// Ejecutar hilo que ejecuta llamadas al servidor en hora determinada.
        /// </summary>
        private void runThread()
        {
            //Ejecutar un hilo para cada horario
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

        /// <summary>
        /// Incrementar propiedad de configuración startId.
        /// </summary>
        public void increaseStartId()
        {
            Properties.Settings.Default.startId = Properties.Settings.Default.startId + 1;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
        }
    }
}
