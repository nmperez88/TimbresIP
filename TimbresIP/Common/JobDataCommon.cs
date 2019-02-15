using System;
using System.Collections.Generic;
using TimbresIP.Model;
using TimbresIP.Utils;

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

        ///// <summary>
        ///// Mapa de llamadas. identificador de trabajo(idJob).
        ///// </summary>
        //public List<string> softPhoneUtilsList = new List<string>();

        /// <summary>
        /// Identificador del traajo.
        /// </summary>
        public String idJob { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="registrationRequired"></param>
        /// <param name="domainHost"></param>
        /// <param name="domainPort"></param>
        /// <param name="connectionCallServer"></param>
        /// <param name="callServer"></param>
        /// <param name="softPhoneUtilsList"></param>
        /// <param name="idJob"></param>
        //public JobDataCommon(bool registrationRequired, string domainHost, int domainPort, ConnectionCallServerModel connectionCallServer, CallServerModel callServer, List<string> softPhoneUtilsList, String idJob)
        public JobDataCommon(bool registrationRequired, string domainHost, int domainPort, ConnectionCallServerModel connectionCallServer, CallServerModel callServer, String idJob)
        {
            this.registrationRequired = registrationRequired;
            this.domainHost = domainHost;
            this.domainPort = domainPort;
            this.connectionCallServer = connectionCallServer;
            this.callServer = callServer;
            //this.softPhoneUtilsList = softPhoneUtilsList;
            this.idJob = idJob;
        }
    }
}
