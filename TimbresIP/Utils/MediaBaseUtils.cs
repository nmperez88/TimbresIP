using System;
using System.Collections.Generic;

namespace TimbresIP.Utils
{
    /// <summary>
    /// Clase base. Contiene variables de uso común.
    /// </summary>
    abstract class MediaBaseUtils : BaseUtils
    {

        /// <summary>
        /// Tiempo de duración del audio.
        /// </summary>
        public static int time { get; set; } = !Properties.Settings.Default.callTime.Equals(0) ? Properties.Settings.Default.callTime : 30;

        /// <summary>
        /// Tipo de extensión de archivo a reproducir. Por defecto wav.
        /// </summary>
        public static String extTypePlayer = "wav";

        /// <summary>
        /// Tipo de extensión wav. 
        /// </summary>
        public static List<String> extTypeWav = new List<string>() { "wav", "wave", ".wav", ".wave" };

        /// <summary>
        /// Establecer valor por defecto a callTime.
        /// </summary>
        public void resetTime()
        {
            time = !Properties.Settings.Default.callTime.Equals(0) ? Properties.Settings.Default.callTime : 30;
        }

        /// <summary>
        /// Iniciar reproducción.
        /// </summary>
        abstract public void start();

        /// <summary>
        /// Detener reproductor ahora.
        /// </summary>
        abstract public void hangUpNow();
    }
}
