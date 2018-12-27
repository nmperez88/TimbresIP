using System;
using TimbresIP.Model;

namespace TimbresIP.Common
{
    /// <summary>
    /// Estructura de datos para los trabajadores.
    /// Su función es minimizar la declaración de parámetros en los métodos.
    /// </summary>

    class JobDataCommon : BaseCommon
    {
        /// <summary>
        /// Es requerido registrarse.
        /// </summary>
        public Boolean registrationRequired { get; set; }

        /// <summary>
        /// Servidor.
        /// </summary>
        public String domainHost { get; set; }

        /// <summary>
        /// Puerto del servidor.
        /// </summary>
        public int domainPort { get; set; }

        /// <summary>
        /// Conexión al servidor.
        /// </summary>
        public ConnectionCallServerModel connectionCallServer { get; set; }

        /// <summary>
        /// Llamada al servidor.
        /// </summary>
        public CallServerModel callServer { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="registrationRequired"></param>
        /// <param name="domainHost"></param>
        /// <param name="domainPort"></param>
        /// <param name="connectionCallServer"></param>
        /// <param name="callServer"></param>
        public JobDataCommon(bool registrationRequired, string domainHost, int domainPort, ConnectionCallServerModel connectionCallServer, CallServerModel callServer)
        {
            this.registrationRequired = registrationRequired;
            this.domainHost = domainHost;
            this.domainPort = domainPort;
            this.connectionCallServer = connectionCallServer;
            this.callServer = callServer;
        }
    }
}
