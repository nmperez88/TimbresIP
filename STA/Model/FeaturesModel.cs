using System;
using System.Windows.Forms;
using STA.Utils;

namespace STA.Model
{
    /// <summary>
    /// Caracteristicas de la PC cliente
    /// </summary>
    class FeaturesModel
    {
        /// <summary>
        /// Version del SO del cliente
        /// </summary>
        public String osVersion { get; set; }
        /// <summary>
        /// Version de Service Pack en caso de aplicar
        /// </summary>
        public String servicePack { get; set; }
        /// <summary>
        /// Nombre del equipo cliente
        /// </summary>
        public String machineName { get; set; }
        /// <summary>
        /// Nombre de usuario en caso del pc cliente pertenecer a un dominio
        /// </summary>
        public String userDomain { get; set; }
        /// <summary>
        /// Nombre de usuario local en la pc cliente
        /// </summary>
        public String localUserName { get; set; }
        /// <summary>
        /// Direccion MAC del pc cliente
        /// </summary>
        public String macAddr { get; set; }
        /// <summary>
        /// Direccion IP local del pc cliente
        /// </summary>
        public String localIPAddr { get; set; }
        /// <summary>
        /// Direccion IP publica del pc cliente
        /// </summary>
        public String externalIPAddr { get; set; }
        /// <summary>
        /// Version de la aplicacion
        /// </summary>
        public String appVersion { get; set; }
        /// <summary>
        /// Instancia de la clase FeaturesUtils
        /// </summary>
        FeaturesUtils featuresUtils = new FeaturesUtils();
        /// <summary>
        /// Constructor de la clase features
        /// </summary>
        public FeaturesModel()
        {
            osVersion = Environment.OSVersion.ToString();
            servicePack = Environment.OSVersion.ServicePack;
            machineName = Environment.MachineName;
            userDomain = Environment.UserDomainName;
            localUserName = Environment.UserName;
            macAddr = featuresUtils.getMacAddress() == null ? "" : featuresUtils.getMacAddress().ToString();
            localIPAddr = featuresUtils.getLocalIPAddress().ToString();
            externalIPAddr = featuresUtils.getExternalIP().ToString();
            appVersion = Application.ProductVersion;
        }
    }
}
