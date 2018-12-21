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
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    }
}
