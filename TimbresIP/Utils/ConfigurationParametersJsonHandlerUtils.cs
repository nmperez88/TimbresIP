
using System;
using System.IO;
using Newtonsoft.Json;

namespace TimbresIP.Utils
{
    /// <summary>
    /// Crear y actualizar archivo JSON.
    /// </summary>
    class ConfigurationParametersJsonHandlerUtils : JsonHandlerUtils
    {
        /// <summary>
        /// Contenido.
        /// </summary>
        private ConfigurationParametersModel content;


        /// <summary>
        /// Contructor.
        /// </summary>
        /// <param name="fullPath">
        /// Ruta completa.
        /// </param>
        public ConfigurationParametersJsonHandlerUtils(string fullPath)
        {

            this.fullPath = fullPath;
            checkExtension();
        }

        public ConfigurationParametersJsonHandlerUtils(){}

        /// <summary>
        /// Crear o actualizar.
        /// </summary>
        /// <param name="content">
        /// Contenido del archivo.
        /// </param>
        public void serialize(ConfigurationParametersModel content)
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
        public ConfigurationParametersModel deserialize()
        {
            ConfigurationParametersModel obj = new ConfigurationParametersModel();
            try
            {
                string outputJSON = File.ReadAllText(fullPath);
                obj = (ConfigurationParametersModel)JsonConvert.DeserializeObject(outputJSON);
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
