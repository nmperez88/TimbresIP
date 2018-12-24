using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using utils;

namespace TimbresIP
{
    class ConfigurationParametersUtils
    {
        ConfigurationParametersModel jsonconfigurationParameters = new ConfigurationParametersModel();

        /// <summary>
        /// Se establecen los parametros de configuracion del sistema y se asignan a jsonObject
        /// </summary>
        public void getJsonConfigurationParameters()
        {
            try
            {
                jsonconfigurationParameters = new ConfigurationParametersModel()
                {
                    numberHours = 25,
                    numberschedules=5,
                    sendedEMail= jsonconfigurationParameters.sendedEMail
                };
            }
            catch (Exception e)
            {
                log.WriteError(e);
            }

        }

        public string getConfigurationParameters()
        {
            getJsonConfigurationParameters();
            return JsonConvert.SerializeObject(jsonconfigurationParameters, Formatting.Indented);
        }
    }
}
