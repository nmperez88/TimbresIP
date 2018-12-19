using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimbresIP.Model
{
    /*
     * Sistema de Timbres Automáticos
     * 
     */
    class AutomaticRingSystemModel
    {
        /*
         * Es requerido registrarse
         * 
         */
        public Boolean registrationRequired { get; set; } = true;

        /*
         * Servidor
         * 
         */
        public String domainHost { get; set; } //= "";//"100.50.40.3";

        /*
         * Puerto del servidor
         * 
         */
        public Int32 domainPort { get; set; } //= 5060;

        /*
         * Lista de horarios
         * 
         */
        public List<HoraryModel> horaryList { get; set; } = new List<HoraryModel>();

        /*
         * Lista de timbres generales
         * 
         */
        public List<HoraryModel> generalRingList { get; set; } = new List<HoraryModel>();

    }
}
