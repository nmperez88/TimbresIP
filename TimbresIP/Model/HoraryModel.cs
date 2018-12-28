using System;
using System.Collections.Generic;

namespace TimbresIP.Model
{
    /// <summary>
    /// Horario.
    /// </summary>
    class HoraryModel : BaseModel
    {
        /// <summary>
        /// Nombre.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// Identificador para el grupo horario.
        /// </summary>
        private String idGroup { get; set; } = "h";

        /// <summary>
        /// Identificador.
        /// </summary>
        /// <remarks>
        /// Sintaxis: "h"+startId. A startId debe autoincrementarse previamente.
        /// </remarks>
        public String randomId { get; private set; }

        /// <summary>
        /// Lista de llamadas al servidor.
        /// </summary>
        public List<CallServerModel> callServerList { get; set; } = new List<CallServerModel>();

        /// <summary>
        /// Conexión al servidor.
        /// </summary>
        public ConnectionCallServerModel connectionCallServer { get; set; }

        public HoraryModel()
        {
            this.randomId = idGroup + getStartId();
            connectionCallServer = new ConnectionCallServerModel();
        }

        public HoraryModel(string name, ConnectionCallServerModel connectionCallServer)
        {
            this.name = name;
            this.randomId = idGroup + getStartId();
            this.connectionCallServer = connectionCallServer;
        }
        public HoraryModel(string name, List<CallServerModel> callServerList)
        {
            this.callServerList = callServerList;
        }

        public HoraryModel(List<CallServerModel> callServerList)
        {
            this.callServerList = callServerList;
        }
    }
}
