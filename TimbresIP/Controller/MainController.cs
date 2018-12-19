using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimbresIP.Model;
using TimbresIP.Utils;

namespace TimbresIP.Controller
{
    class MainController
    {
        /*
         * AutomaticRingSystemModel
         * 
         */
        private AutomaticRingSystemModel automaticRingSystemModel;

        /*
         * Ruta de archivo Json
         * 
         */
        private String jsonFileFullPath;

        /*
         * Gestiona contenido de archivo JSON
         * 
         */
        private JsonHandlerUtils jsonHandlerUtils;

        /*
         * Lista de horas en las que debe ejecutarse un timbre. Construir estructura que permita chequear de forma rápida utilizando quartz
         * 
         */
        private List<String> plannedHours;



        //Inicializar automaticRingSystemLeer archivo JSON. 
        //Existe(No)=> new AutomaticRingSystem()
        //      (Sí)=> (AutomaticRingSystem)JsonUtils.deserialize() 

        public void init()
        {
            jsonFileFullPath = Properties.Settings.Default.jsonFolderDirectory + Properties.Settings.Default.jsonFileName + Properties.Settings.Default.jsonExtension;

            if (System.IO.File.Exists(jsonFileFullPath))
            {

            }
            jsonHandlerUtils = new JsonHandlerUtils(jsonFileFullPath, null);
        }

        //Lanzar hilo que verifica si debe ejecutarse algún timbre
    }

}
