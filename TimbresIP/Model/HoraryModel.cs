using System;
using System.Collections.Generic;

namespace TimbresIP.Model
{
    /*
     * Horario
     */
    class HoraryModel
    {
        private String name { get; set; }
        private String randomId;//"h"+startId. A startId debe asignarse 1 previamente
        private List<CallServerModel> callServerList = new List<CallServerModel>();
        private ConnectionCallServerModel connectionCallServer;


        /*
         * Incrementar propiedad de configuración startId
         * 
         */
        public void increaseStartId()
        {
            Properties.Settings.Default.startId = Properties.Settings.Default.startId + 1;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
        }
    }
}
