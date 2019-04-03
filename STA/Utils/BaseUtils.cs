using System;

namespace STA.Utils
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

        /// <summary>
        /// Encriptador y desencriptador de archivos.
        /// </summary>
        public static CypherUtils cypherUtils = new CypherUtils();


        /// <summary>
        /// Validador de entradas.
        /// </summary>
        public static ValidateEntriesUtils validateEntriesUtils = new ValidateEntriesUtils();

        /// <summary>
        /// Ruta de archivo Json de llamadas en ejecución.
        /// </summary>
        public static String callsRunningJsonFileFullPath = validateEntriesUtils.getProgramDataPath() + "\\" + Properties.Settings.Default.callsRunning + Properties.Settings.Default.jsonExtension;

        /// <summary>
        /// Lista de llamadas en ejecución.
        /// </summary>
        public static CallsRunningUtils callsRunningUtils = new CallsRunningUtils();

        /// <summary>
        /// Gestiona contenido de archivo JSON.
        /// </summary>
        public static JsonHandlerUtils jsonHandlerUtils;

        /// <summary>
        /// Establecer lista de llamadas en ejecución.
        /// </summary>
        /// <returns></returns>
        public static void setCallsRunningUtils()
        {
            jsonHandlerUtils = new JsonHandlerUtils(callsRunningJsonFileFullPath, "STA.Utils.CallsRunningUtils");
            jsonHandlerUtils.serialize(callsRunningUtils);
        }

        /// <summary>
        /// Obtener lista de llamadas en ejecución. Estático.
        /// </summary>
        /// <returns></returns>
        public static CallsRunningUtils getCallsRunningUtils()
        {
            jsonHandlerUtils = new JsonHandlerUtils(callsRunningJsonFileFullPath, "STA.Utils.CallsRunningUtils");
            if (!System.IO.File.Exists(callsRunningJsonFileFullPath))
            {
                jsonHandlerUtils.serialize(callsRunningUtils);
            }
            else
            {
                callsRunningUtils = (CallsRunningUtils)jsonHandlerUtils.deserialize();
            }

            return callsRunningUtils;
        }

        /// <summary>
        /// Inicializar lista de llamadas en ejecución. Estático.
        /// </summary>
        /// <returns></returns>
        public static void resetCallsRunningUtils()
        {
            callsRunningUtils = new CallsRunningUtils();
            jsonHandlerUtils = new JsonHandlerUtils(callsRunningJsonFileFullPath, "STA.Utils.CallsRunningUtils");
            jsonHandlerUtils.serialize(callsRunningUtils);
        }
    }
}
