using System;
using System.Collections.Generic;

namespace TimbresIP.Model
{
    /// <summary>
    /// Horario.
    /// </summary>
    class HoraryModel
    {
        /// <summary>
        /// Nombre.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// Identificador.
        /// </summary>
        /// <remarks>
        /// Sintaxis: "h"+startId.A startId debe asignarse 1 previamente.
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

    }
}
