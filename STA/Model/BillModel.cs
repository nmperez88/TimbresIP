using System;
using System.Collections.Generic;

namespace STA.Model
{
    /// <summary>
    /// Factura
    /// </summary>
    class BillModel : BaseModel
    {
        /// <summary>
        /// Fecha inicio de la llamada.
        /// </summary>
        public DateTime start { get; set; }

        /// <summary>
        /// Fecha inicio de la llamada.
        /// </summary>
        public DateTime end { get; set; }

        /// <summary>
        /// Nombre del horario.
        /// </summary>
        public String horaryName { get; set; }

        /// <summary>
        /// Identificador del horario.
        /// </summary>
        public String horaryRandomId { get; set; }

        /// <summary>
        /// Llamada al servidor.
        /// </summary>
        public CallServerModel callServer { get; set; } = new CallServerModel();

        /// <summary>
        /// Lista de estados por los que pasó la llamada.
        /// </summary>
        public List<String> statusCall { get; set; } = new List<String>();

    }
}
