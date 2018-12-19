using Newtonsoft.Json;
using System;
using System.IO;

namespace TimbresIP.Utils
{
    /*
     * Crear y actualizar archivo JSON
     * 
     */
    class JsonUtils
    {
        private String path;
        private String name;
        private String fullPath;
        private Object contentObject;

        public JsonUtils(string path, string name, object contentObject)
        {
            this.path = path;
            this.name = name;
            this.fullPath = path + "/" + name;
            checkExtension();
            this.contentObject = contentObject;
        }

        public JsonUtils(string fullPath, object contentObject)
        {

            this.fullPath = fullPath;
            checkExtension();
            this.contentObject = contentObject;
        }

        /*
         * Crear o actualizar
         * 
         */
        public void serialize()
        {
            string outputJSON = JsonConvert.SerializeObject(contentObject);
            File.WriteAllText(fullPath, outputJSON);
        }

        /*
         * Obtener contenido
         * 
         */
        public Object deserialize()
        {
            string outputJSON = File.ReadAllText(fullPath);
            return JsonConvert.DeserializeObject(outputJSON);
        }

        /*
         * Chequear tenga extensión, agregarla en caso de no tenerla
         * 
         */
        public void checkExtension()
        {
            if (!fullPath.EndsWith(Properties.Settings.Default.jsonExtension))
            {
                fullPath += Properties.Settings.Default.jsonExtension;
            }

        }

    }
}
