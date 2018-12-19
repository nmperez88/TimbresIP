using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimbresIP.Model;
using TimbresIP.Utils;

namespace TimbresIP.Controller
{
    class MainController : BaseUtils
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

        /*
         * Inicializar datos de la aplicación
         * 
         */
        public void init()
        {
            jsonFileFullPath = Properties.Settings.Default.jsonFolderDirectory + Properties.Settings.Default.jsonFileName + Properties.Settings.Default.jsonExtension;

            if (System.IO.File.Exists(jsonFileFullPath))
            {
                jsonHandlerUtils = new JsonHandlerUtils(jsonFileFullPath);
                automaticRingSystemModel = (AutomaticRingSystemModel)jsonHandlerUtils.deserialize();
            }
            else
            {
                log.Info("El archivo JSON no existe. Debe ser creado antes de guardar.");
                automaticRingSystemModel = new AutomaticRingSystemModel();
            }

            //Están los parámetros de conexión al servidor.
            if (hasServerParams())
            {

            }
            //Hay horarios configurados.
            //  Está habilitado.
            //  Existe archivo de sonido. Deshabilitar horario en caso de no existir archivo de sonido.
            //  Tiene los parámetros de conexión al servidor.

            //Construir lista de timbres a ejecutar.
            //Lanzar hilo(thread) que verifica si debe ejecutarse algún timbre

        }

        private bool hasServerParams()
        {
            return !automaticRingSystemModel.domainHost.Equals("") && automaticRingSystemModel.domainPort != null;
        }
    }

}
