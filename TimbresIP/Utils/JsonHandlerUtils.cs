using Newtonsoft.Json;
using System;
using System.IO;

namespace TimbresIP.Utils
{
    /*
     * Crear y actualizar archivo JSON
     * 
     */
    class JsonHandlerUtils : BaseUtils
    {
        private String path;
        private String name;
        private String fullPath;
        private Object contentObject;

        //public JsonHandlerUtils(string path, string name, object contentObject)
        //{
        //    this.path = path;
        //    this.name = name;
        //    this.fullPath = path + "/" + name;
        //    checkExtension();
        //    this.contentObject = contentObject;
        //}

        //public JsonHandlerUtils(string fullPath, object contentObject)
        //{

        //    this.fullPath = fullPath;
        //    checkExtension();
        //    this.contentObject = contentObject;
        //}

        public JsonHandlerUtils(string fullPath)
        {

            this.fullPath = fullPath;
            checkExtension();
        }

        ///*
        // * Crear o actualizar
        // * 
        // */
        //public void serialize()
        //{
        //    try
        //    {
        //        string outputJSON = JsonConvert.SerializeObject(contentObject);
        //        File.WriteAllText(fullPath, outputJSON);
        //    }
        //    catch (Exception e)
        //    {
        //        log.Error(e);
        //    }
        //}

        /*
         * Crear o actualizar
         * 
         */
        public void serialize(Object contentObject)
        {

            try
            {
                string outputJSON = JsonConvert.SerializeObject(contentObject);
                File.WriteAllText(fullPath, outputJSON);
                this.contentObject = contentObject;
            }
            catch (Exception e)
            {
                log.Error(e);
            }
        }

        /*
         * Obtener contenido
         * 
         */
        public Object deserialize()
        {
            Object obj = new Object();
            try
            {
                string outputJSON = File.ReadAllText(fullPath);
                obj = JsonConvert.DeserializeObject(outputJSON);
            }
            catch (Exception e)
            {
                log.Error(e);
            }

            return obj;
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
