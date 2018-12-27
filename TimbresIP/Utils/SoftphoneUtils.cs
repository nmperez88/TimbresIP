using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ozeki.Media;
using Ozeki.VoIP;
using TimbresIP.Model;

namespace TimbresIP.Utils
{
    /// <summary>
    /// Gestionar conexión con el servidor.
    /// </summary>
    class SoftPhoneUtils : BaseUtils
    {
        /// <summary>
        /// SoftPhone.
        /// </summary>
        static ISoftPhone softphone;

        /// <summary>
        /// Línea SoftPhone.
        /// </summary>
        static IPhoneLine phoneLine;

        /// <summary>
        /// Llamada.
        /// </summary>
        static IPhoneCall call;

        /// <summary>
        /// Conector multimedia.
        /// </summary>
        static MediaConnector connector;

        /// <summary>
        /// Envía audio multimedia.
        /// </summary>
        static PhoneCallAudioSender mediaSender;

        /// <summary>
        /// Reproductor multimedia.
        /// </summary>
        static MP3StreamPlayback mp3Player;

        /// <summary>
        /// Extensión a llamar. Generalmente es la extensión telefónica. numberToDial.
        /// </summary>
        static String registerName { get; set; }

        /// <summary>
        /// Ruta a archivo de sonido.
        /// </summary>
        static String audioFilePath { get; set; }

        /// <summary>
        /// Variable que define el mínimo del rango.
        /// </summary>
        private int softPhoneRangeMin = !Properties.Settings.Default.softPhoneRangeMin.Equals(0) ? Properties.Settings.Default.softPhoneRangeMin : 5000;

        /// <summary>
        /// Variable que define el máximo del rango.
        /// </summary>
        private int softPhoneRangeMax = !Properties.Settings.Default.softPhoneRangeMax.Equals(0) ? Properties.Settings.Default.softPhoneRangeMax : 10000;

        /// <summary>
        /// Contructor.
        /// </summary>
        public SoftPhoneUtils()
        {
            //Crear instancia softPhone. Rango 5000-10000
            softphone = SoftPhoneFactory.CreateSoftPhone(softPhoneRangeMin, softPhoneRangeMax);

            mediaSender = new PhoneCallAudioSender();
            connector = new MediaConnector();
        }

        /// <summary>
        /// Iniciar lamada.
        /// </summary>
        public void start(Boolean registrationRequired, String domainHost, int domainPort, ConnectionCallServerModel connectionCallServer, CallServerModel callServer)
        {
            //var account = new SIPAccount(registrationRequired, displayName, userName, authenticationId, registerPassword, domainHost, domainPort);
            var account = new SIPAccount(registrationRequired, connectionCallServer.displayName, connectionCallServer.userName, connectionCallServer.registerName, connectionCallServer.registerPassword, domainHost, domainPort);

            //Extensión a llamar. numberToDial.
            registerName = callServer.registerName;

            //Registrar cuenta. Los eventos desencadenan la ejecución de la llamada.
            registerAccount(account);

            mp3Player = new MP3StreamPlayback(callServer.soundFile.targetPath);
        }

        /// <summary>
        /// Registrar cuenta.
        /// </summary>
        /// <param name="account"></param>
        static void registerAccount(SIPAccount account)
        {
            try
            {
                phoneLine = softphone.CreatePhoneLine(account);
                phoneLine.RegistrationStateChanged += registrationStateChanged;
                softphone.RegisterPhoneLine(phoneLine);
            }
            catch (Exception e)
            {
                log.Error(e);
            }
        }

        /// <summary>
        /// Gestionar cambio de estado en la llamada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void registrationStateChanged(object sender, RegistrationStateChangedArgs e)
        {
            if (e.State == RegState.NotRegistered || e.State == RegState.Error)
            {
                log.Error("Error al registrar la cuenta de usuario: " + RegState.Error);
            }

            if (e.State == RegState.RegistrationSucceeded)
            {
                log.Info("Registro satisfactorio.");
                startCall();
            }
        }

        /// <summary>
        /// Iniciar llamada.
        /// </summary>
        private static void startCall()
        {
            //var numberToDial = "853";
            call = softphone.CreateCallObject(phoneLine, registerName);
            call.CallStateChanged += callStateChanged;
            call.Start();
        }

        /// <summary>
        /// Iniciar reproductor mp3.
        /// </summary>
        static void startMp3Player()
        {
            connector.Connect(mp3Player, mediaSender);
            mediaSender.AttachToCall(call);

            mp3Player.Start();

            log.Info("Reproduciendo mp3 player!.");
        }

        /// <summary>
        /// Ggestionar cambio de estado al llamar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void callStateChanged(object sender, CallStateChangedArgs e)
        {
            log.Info("Estado en la llamada: " + e.State);
            if (e.State == CallState.Answered)
            {
                startMp3Player();
            }
        }
    }
}
