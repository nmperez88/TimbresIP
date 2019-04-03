using System;
using System.Collections.Generic;

namespace STA.Model
{
    /// <summary>
    /// Lista de facturas.
    /// </summary>
    class BillsModel : BaseModel
    {
        /// <summary>
        /// Lista de facturas por llamada.
        /// </summary>
        public List<BillModel> bills { get; set; } = new List<BillModel>();

    }
}
