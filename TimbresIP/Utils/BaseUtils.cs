using System;

namespace TimbresIP.Utils
{
    /// <summary>
    /// Clase base. Contiene variables de uso común.
    /// </summary>
    class BaseUtils
    {
        /// <summary>
        /// Generador de logs.
        /// </summary>
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Incrementar propiedad de configuración startId.
        /// </summary>
        public void increaseStartId()
        {
            Int32 int32 = Int32.Parse(Properties.Settings.Default.startId) + 1;
            Properties.Settings.Default.startId = int32.ToString();
            Properties.Settings.Default.Save();
            //Properties.Settings.Default.Reload();
        }
        /// <summary>
        /// Obtener startId.
        /// </summary>
        public String getStartId()
        {
            increaseStartId();
            return Properties.Settings.Default.startId;
        }
    }
}
