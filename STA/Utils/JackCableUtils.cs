using System;
using System.Media;
using STA.Common;
using WMPLib;

namespace STA.Utils
{
    /// <summary>
    /// Conector de audio jack 3.5.
    /// </summary>
    class JackCableUtils : MediaBaseUtils
    {

        /// <summary>
        /// Reproductor multimedia mp3.
        /// </summary>
        static WindowsMediaPlayer mp3Player;

        /// <summary>
        /// Reproductor multimedia wav/wave.
        /// </summary>
        static SoundPlayer wavPlayer;

        /// <summary>
        /// Parámetros(datos) para el trabajador.
        /// </summary>
        public JobDataCommon jobDataCommon { get; set; }

        /// <summary>
        /// Parámetros(datos) para el trabajador.
        /// </summary>
        public static JobDataCommon jobDataCommonStatic { get; set; }

        /// <summary>
        /// Contructor.
        /// </summary>
        public JackCableUtils()
        {
        }

        /// <summary>
        /// Iniciar reproducción.
        /// </summary>
        public override void start()
        {
            jobDataCommonStatic = jobDataCommon;

            //Tiempo de duración de la reproducción. En segundos.
            resetTime();
            if (!jobDataCommon.callServer.callTime.Equals(0))
            {
                time = jobDataCommon.callServer.callTime;
            }

            //Establecer tipo de archivo a reproducir.
            if (System.IO.File.Exists(jobDataCommon.callServer.soundFile.targetPath))
            {
                try
                {
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
            initPlayback();
        }

        /// <summary>
        /// Inicializar reproductor.
        /// </summary>
        void initPlayback()
        {
            if (extTypeWav.Contains(extTypePlayer))
            {
                try
                {
                    wavPlayer = new SoundPlayer(jobDataCommon.callServer.soundFile.targetPath);
                }
                catch (Exception e)
                {
                    log.Error(e);
                }

            }
            else
            {
                mp3Player = new WindowsMediaPlayer();
                mp3Player.settings.autoStart = false;
                mp3Player.settings.setMode("loop", true);
                mp3Player.URL = jobDataCommon.callServer.soundFile.targetPath;

            }
            startPlayer();
        }

        /// <summary>
        /// Iniciar reproductor mp3.
        /// </summary>
        static void startMp3Player()
        {

            mp3Player.controls.play();

            log.Info("Reproduciendo mp3 player!.");
            HangUp();
        }

        /// <summary>
        /// Iniciar reproductor wav/wave.
        /// </summary>
        static void startWavPlayer()
        {
            try
            {
                //wavPlayer.Play();
                wavPlayer.PlayLooping();
            }
            catch (Exception e)
            {
                log.Error(e);
            }

            log.Info("Reproduciendo wav player!.");
            HangUp();
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
        /// Detener reproductor.
        /// </summary>
        static void HangUp()
        {
            int milliseconds = (int)TimeSpan.FromSeconds(time).TotalMilliseconds;

            System.Threading.Tasks.Task.Run(() =>
            {
                System.Threading.Thread.Sleep(milliseconds);
                mediaHangUpNow();
            });
        }

        /// <summary>
        /// Detener reproductor ahora. Estático
        /// </summary>
        static void mediaHangUpNow()
        {
            if (extTypeWav.Contains(extTypePlayer))
            {

                if (wavPlayer != null)
                {
                    wavPlayer.Stop();
                    log.Info("Deteniendo reproductor!");
                }
                else
                {
                    log.Info("Reproductor no inicializado!");
                }
            }
            else
            {
                if (mp3Player != null)
                {
                    mp3Player.controls.stop();
                    log.Info("Deteniendo reproductor!");
                }
                else
                {
                    log.Info("Reproductor no inicializado!");
                }
            }

            getCallsRunningUtils();
            if (callsRunningUtils.idsList.Contains(jobDataCommonStatic.idJob))
            {
                callsRunningUtils.idsList.Remove(jobDataCommonStatic.idJob);
                setCallsRunningUtils();
            }
        }

        /// <summary>
        /// Detener reproductor ahora.
        /// </summary>
        public override void hangUpNow()
        {
            mediaHangUpNow();
        }
    }
}
