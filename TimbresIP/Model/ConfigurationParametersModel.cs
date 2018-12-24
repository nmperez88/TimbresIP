using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimbresIP
{
    class ConfigurationParametersModel
    {
        /// <summary>
        /// Cantidad de horas permitidas por horario
        /// </summary>
        public int numberHours { get; set; }
        /// <summary>
        /// Cantidad de Horarios permitidos
        /// </summary>
        public int numberschedules { get; set; }
        /// <summary>
        /// Variable de control de envio de correo con registro
        /// </summary>
        public bool sendedEMail { get; set; }
    }
}
