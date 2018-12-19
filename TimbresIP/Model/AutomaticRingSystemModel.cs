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
        private Boolean registrationRequired = true;

        /*
         * Servidor
         * 
         */
        private String domainHost = "100.50.40.3";

        /*
         * Puerto del servidor
         * 
         */
        private Int32 domainPort = 5060;

        /*
         * Lista de horarios
         * 
         */
        private List<HoraryModel> horaryList = new List<HoraryModel>();

        /*
         * Lista de timbres generales
         * 
         */
        private List<HoraryModel> generalRingList = new List<HoraryModel>();

    }
}
