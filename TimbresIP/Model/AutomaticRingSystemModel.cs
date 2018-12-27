using System;
using System.Collections.Generic;

namespace TimbresIP.Model
{
    /// <summary>
    /// Sistema de Timbres Automáticos.
    /// </summary>
    class AutomaticRingSystemModel
    {
        /// <summary>
        /// Es requerido registrarse.
        /// </summary>
        public Boolean registrationRequired { get; set; } = true;

        /// <summary>
        /// Servidor.
        /// </summary>
        public String domainHost { get; set; } = "";//"100.50.40.3";

        /// <summary>
        /// Puerto del servidor.
        /// </summary>
        public Int32 domainPort { get; set; } = 0;//= 5060;

        /// <summary>
        /// Lista de horarios.
        /// </summary>
        public List<HoraryModel> horaryList { get; set; } = new List<HoraryModel>();

        /// <summary>
        /// Lista de timbres generales.
        /// </summary>
        public List<HoraryModel> generalRingList { get; set; } = new List<HoraryModel>();

        public AutomaticRingSystemModel()
        {
        }
    }
}
