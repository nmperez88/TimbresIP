
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace STA.Utils
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
        /// Nombre de clase. Incluir espacio de nombres.
        /// Ej: 
        ///     Clase: BaseUtils 
        /// className: STA.Utils.BaseUtils
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


        /// <summary>
        /// Obtener JSON simplificado dado objeto
        /// </summary>
        /// <param name="o"></param>
        public static JArray getSimplifiedObject(object o)
        {
            JObject jo = JObject.FromObject(o);
            JArray ja = new JArray();
            foreach (var value in jo.Values())
            {

                if (value.Type == JTokenType.Array)
                {
                    getValues(value, ja);
                }
                else
                    ja.Add(value);
            }

            return ja;
        }

        /// <summary>
        /// Completar JSON simplificado recursivamente dado JToken
        /// </summary>
        /// <param name="jt"></param>
        /// <param name="jaRef"></param>
        private static void getValues(JToken jt, JArray jaRef)
        {
            JArray ja = new JArray();
            foreach (var value in jt.Values())
            {
                var tmp = value;
                if (tmp.Type == JTokenType.Property)
                {
                    tmp = value.First;
                    if (tmp.Type == JTokenType.Object || tmp.Type == JTokenType.Array)
                    {
                        getValues(tmp, ja);
                    }
                    else
                    {
                        ja.Add(tmp);
                    }
                }
                else
                {
                    if (tmp.Type == JTokenType.Object || tmp.Type == JTokenType.Array)
                    {
                        getValues(tmp, ja);
                    }
                    else
                    {
                        ja.Add(tmp);
                    }
                }
            }
            jaRef.Add(ja);
        }

        /// <summary>
        /// Completar JSON simplificado recursivamente dado JObjeto
        /// </summary>
        /// <param name="jo"></param>
        /// <param name="jaRef"></param>
        private static void getValues(JObject jo, JArray jaRef)
        {
            JArray ja = new JArray();
            foreach (var value in jo.Values())
            {
                if (value.Type == JTokenType.Object || value.Type == JTokenType.Array)
                {
                    getValues(value, ja);
                }
                else
                {
                    ja.Add(value);
                }
            }
            jaRef.Add(ja);
        }
    }
}
