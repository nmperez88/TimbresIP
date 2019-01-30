using Ozeki.Common;
using Ozeki.Media;
using Ozeki.VoIP;
using System;
using System.Collections.Generic;
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
        /// Reproductor multimedia mp3.
        /// </summary>
        static MP3StreamPlayback mp3Player;

        /// <summary>
        /// Reproductor multimedia wav/wave.
        /// </summary>
        static WaveStreamPlayback wavPlayer;

        ///// <summary>
        ///// Tipo de archivo a reproducir. Por defecto wav/wave.
        ///// </summary>
        //static String mimeTypePlayer = "audio/x-wav";

        /// <summary>
        /// Tipo de extensión de archivo a reproducir. Por defecto wav.
        /// </summary>
        static String extTypePlayer = "wav";

        /// <summary>
        /// Tipo de extensión wav. 
        /// </summary>
        static List<String> extTypeWav = new List<string>() { "wav", "wave", ".wav", ".wave" };

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

            softphone.EnableCodec(0);
            softphone.EnableCodec(8);//PCMU(G711U)=> 0, PCMA(G711A)=> 8
            log.Info(softphone.Codecs);

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

            //Establecer tipo de archivo a reproducir.

            if (System.IO.File.Exists(jobDataCommon.callServer.soundFile.targetPath))
            {
                try
                {
                    //mimeTypePlayer = HeyRed.Mime.MimeGuesser.GuessExtension(jobDataCommon.callServer.soundFile.targetPath);//QUITAR paquete nuget mime
                    extTypePlayer = System.IO.Path.GetExtension(jobDataCommon.callServer.soundFile.targetPath).ToLower();
                }
                catch (Exception e)
                {
                    log.Error("No fue posible obtener la extensión del archivo de audio", e);
                }
            }
            else
            {
                log.Error("El archivo de audio no existe");
            }

            //Inicializar reproductor.
            initStreamPlayback();
        }

        /// <summary>
        /// Inicializar reproductor.
        /// </summary>
        void initStreamPlayback()
        {
            if (extTypeWav.Contains(extTypePlayer))
            {
                wavPlayer = new WaveStreamPlayback(jobDataCommon.callServer.soundFile.targetPath);
            }
            else
            {
                mp3Player = new MP3StreamPlayback(jobDataCommon.callServer.soundFile.targetPath);
            }
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
            try
            {
                call = softphone.CreateCallObject(phoneLine, registerName);
                call.CallStateChanged += callStateChanged;
                call.Start();
            }
            catch (Exception e)
            {
                log.Error(e);
            }

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
        /// Iniciar reproductor wav/wave.
        /// </summary>
        static void startWavPlayer()
        {
            connector.Connect(wavPlayer, mediaSender);
            mediaSender.AttachToCall(call);

            wavPlayer.Start();

            log.Info("Reproduciendo wav player!.");
            callHangUp();
        }

        /// <summary>
        /// iniciar reproductor.
        /// </summary>
        static void startPlayer()
        {
            if (extTypeWav.Contains(extTypePlayer))
            {
                startWavPlayer();
            }
            else
            {
                startMp3Player();
            }

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
                startPlayer();

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
