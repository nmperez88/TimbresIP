
using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using TimbresIP.Model;

namespace TimbresIP.Utils
{
    /// <summary>
    /// Crear y actualizar archivo JSON.
    /// </summary>
    class JsonHandlerUtils : BaseUtils
    {
        /// <summary>
        /// Ruta a directorio.
        /// </summary>
        /// <remarks>
        /// Hasta carpeta que contiene el archivo.
        /// </remarks>
        protected String dirPath;

        /// <summary>
        /// Nombre.
        /// </summary>
        protected String name;

        /// <summary>
        /// Ruta completa.
        /// </summary>
        protected String fullPath;

        /// <summary>
        /// Contenido.
        /// </summary>
        private Object content;

        /// <summary>
        /// Nombre de clase a deserializar.
        /// </summary>
        private String className;

        //public JsonHandlerUtils(string dirPath, string name, object content)
        //{
        //    this.dirPath = dirPath;
        //    this.name = name;
        //    this.fullPath = dirPath + "/" + name;
        //    checkExtension();
        //    this.content = content;
        //}

        //public JsonHandlerUtils(string fullPath, object content)
        //{

        //    this.fullPath = fullPath;
        //    checkExtension();
        //    this.content = content;
        //}

        /// <summary>
        /// Contructor.
        /// </summary>
        /// <param name="fullPath">
        /// Ruta completa.
        /// </param>
        /// <param name="className">
        /// Nombre de clase.
        /// </param>
        public JsonHandlerUtils(string fullPath, String className)
        {
            this.fullPath = fullPath;
            this.className = className;
            checkExtension();
        }

        public JsonHandlerUtils() { }

        /// <summary>
        /// Crear o actualizar.
        /// </summary>
        /// <param name="content">
        /// Contenido del archivo.
        /// </param>
        public void serialize(Object content)
        {
            try
            {
                string outputJSON = JsonConvert.SerializeObject(content);
                File.WriteAllText(fullPath, outputJSON);
                this.content = content;
            }
            catch (Exception e)
            {
                log.Error(e);
            }
        }

        /// <summary>
        /// Obtener contenido.
        /// </summary>
        /// <returns></returns>
        public Object deserialize()
        {
            //AutomaticRingSystemModel obj = new AutomaticRingSystemModel();
            Object obj = System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(className);
            try
            {
                string outputJSON = File.ReadAllText(fullPath);
                obj = JsonConvert.DeserializeObject(outputJSON, obj.GetType());
            }
            catch (Exception e)
            {
                log.Error(e);
            }

            return obj;
        }

        /// <summary>
        /// Chequear tenga extensión, agregarla en caso de no tenerla.
        /// </summary>
        public void checkExtension()
        {
            if (!fullPath.EndsWith(Properties.Settings.Default.jsonExtension))
            {
                fullPath += Properties.Settings.Default.jsonExtension;
            }

        }
    }
}
