using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimbresIP.Model
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

    }
}
