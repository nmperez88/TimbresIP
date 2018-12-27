using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimbresIP.Model
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
        /// <summary>
        /// Fecha en la que se inicio el software por primera vez
        /// </summary>
        public DateTime installedDate { get; set; }
        /// <summary>
        /// Construnctor de la clase vacio
        /// </summary>
        public ConfigurationParametersModel() { }
        /// <summary>
        /// Constructor de la clase con parametros
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="dateTime"></param>
        public ConfigurationParametersModel(bool flag, DateTime dateTime)
        {
            this.numberHours = 5;
            this.numberschedules = 3;
            this.sendedEMail = flag;
            this.installedDate = dateTime;
        }
    }
}
