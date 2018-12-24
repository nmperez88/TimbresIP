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
        private String idGroup { get; set; }

        /// <summary>
        /// Identificador.
        /// </summary>
        /// <remarks>
        /// Sintaxis: "h"+startId. A startId debe autoincrementarse previamente.
        /// </remarks>
        public String randomId { get; set; }

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

        }

        public HoraryModel(string name, List<CallServerModel> callServerList, ConnectionCallServerModel connectionCallServer)
        {
            this.name = name;
            this.randomId = idGroup + getStartId();
            this.callServerList = callServerList;
            this.connectionCallServer = connectionCallServer;
        }
    }
}
