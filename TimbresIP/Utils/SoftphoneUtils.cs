using Ozeki.Common;
using Ozeki.Media;
using Ozeki.VoIP;
using System;
using TimbresIP.Common;

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
        /// Tiempo de duración de la llamada. Utilizado para colgar(hangUp).
        /// </summary>
        static int callTime { get; set; } = !Properties.Settings.Default.callTime.Equals(0) ? Properties.Settings.Default.callTime : 30;

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
        /// Parámetros(datos) para el trabajador.
        /// </summary>
        public JobDataCommon jobDataCommon { get; set; }

        /// <summary>
        /// Contructor.
        /// </summary>
        public SoftPhoneUtils()
        {
            try
            {
                if (LicenseManager.Instance.LicenseType.ToString().Equals("Expired"))
                {
                    var userName = "OZSDK-CALL-1234567-IWAREZ 2017";
                    var key = "UDoyMDMzLTEyLTI1LFVQOjIwMzMtMDEtMDEsTUNDOjUwMCxNUEw6NTAwLE1TTEM6NTAwLE1GQzo1MDAsRzcyOTp0cnVlLE1XUEM6NTAwLE1JUEM6NTAwfHFQZDBhQnhlaEFGaTlNMmV4cXZxaHUyVE5rMWh2S0FzaUZlVlowbFFseTZWZ3JKbmFMTXh3ZVV2elBGcEliTFpwNHZtZDArZlZwc2VkRGpjQWdKR3ZnPT0=";
                    LicenseManager.Instance.SetLicense(userName, key);
                }
            }
            catch (Exception e)
            {
                log.Error(e);
            }

            //Crear instancia softPhone. Rango 5000-10000
            softphone = SoftPhoneFactory.CreateSoftPhone(softPhoneRangeMin, softPhoneRangeMax);

            mediaSender = new PhoneCallAudioSender();
            connector = new MediaConnector();
        }

        /// <summary>
        /// Iniciar lamada.
        /// </summary>
        //public void start(Boolean registrationRequired, String domainHost, int domainPort, ConnectionCallServerModel connectionCallServer, CallServerModel callServer)
        public void start()
        {
            //var account = new SIPAccount(registrationRequired, displayName, userName, authenticationId, registerPassword, domainHost, domainPort);
            var account = new SIPAccount(jobDataCommon.registrationRequired, jobDataCommon.connectionCallServer.displayName, jobDataCommon.connectionCallServer.userName, jobDataCommon.connectionCallServer.registerName, jobDataCommon.connectionCallServer.registerPassword, jobDataCommon.domainHost, jobDataCommon.domainPort);

            //Extensión a llamar. numberToDial.
            registerName = jobDataCommon.callServer.registerName;

            //Tiempo de duración de la llamada. En segundos.
            resetCallTime();
            if (!jobDataCommon.callServer.callTime.Equals(0))
            {
                callTime = jobDataCommon.callServer.callTime;
            }

            //Registrar cuenta. Los eventos desencadenan la ejecución de la llamada.
            registerAccount(account);

            mp3Player = new MP3StreamPlayback(jobDataCommon.callServer.soundFile.targetPath);
        }

        /// <summary>
        /// Establecer valor por defecto a callTime.
        /// </summary>
        public void resetCallTime()
        {
            callTime = !Properties.Settings.Default.callTime.Equals(0) ? Properties.Settings.Default.callTime : 30;
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
            callHangUp();
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

        /// <summary>
        /// Colgar llamada.
        /// </summary>
        static void callHangUp()
        {
            int milliseconds = (int)TimeSpan.FromSeconds(callTime).TotalMilliseconds;

            System.Threading.Tasks.Task.Run(() =>
            {
                System.Threading.Thread.Sleep(milliseconds);
                //call.HangUp();
                //log.Info("Colgando llamada!");
                callHangUpNow();
            });

            ////Alternativa 2
            //System.Threading.Tasks.Task.Delay(milliseconds);
            //call.HangUp();
            //log.Info("Colgando llamada!");
        }

        /// <summary>
        /// Colgar llamada ahora. Estático
        /// </summary>
        static void callHangUpNow()
        {
            if (call != null)
            {
                call.HangUp();
                log.Info("Colgando llamada!");
            }
            else
            {
                log.Info("Llamada no inicializada!");
            }
        }

        /// <summary>
        /// Colgar llamada ahora.
        /// </summary>
        public void hangUpNow()
        {
            callHangUpNow();
        }
    }
}
