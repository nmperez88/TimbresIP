using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;
using TimbresIP.Model;
using Newtonsoft.Json;

namespace TimbresIP.Utils
{
    class FeaturesUtils : BaseUtils
    {
        /// <summary>
        /// Metodo para obtener la MACADDR del cliente
        /// </summary>
        /// <returns>Direccion MAC del PC</returns>
        public static PhysicalAddress getMacAddress()
        {
            foreach (NetworkInterface nicInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                // Only consider Ethernet network interfaces
                if (nicInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet && nicInterface.OperationalStatus == OperationalStatus.Up)
                {
                    return nicInterface.GetPhysicalAddress();
                }
            }
            return null;
        }

        /// <summary>
        /// Metodo para obtener la IPADDR interna del cliente
        /// </summary>
        /// <returns>Direccion IP Local</returns>
        public static string getLocalIPAddress()
        {
            var hostName = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ipAddr in hostName.AddressList)
            {
                if (ipAddr.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ipAddr.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        /// <summary>
        /// Metodo para obtener la IPADDR externa del cliente
        /// </summary>
        /// <returns>Direccion IP externa</returns>
        public static string getExternalIP()
        {
            string externalIp = new WebClient().DownloadString(Properties.Settings.Default.dnsExternalConsult);
            return externalIp;
        }
        /// <summary>
        /// Se capturan las caracteristicas del PC y se asignan a jsonObject
        /// </summary>
        FeaturesModel jsonFeatures = new FeaturesModel();
        //{
        //    osVersion = Environment.OSVersion.ToString(),
        //    servicePack = Environment.OSVersion.ServicePack,
        //    machineName = Environment.MachineName,
        //    userDomain = Environment.UserDomainName,
        //    localUserName = Environment.UserName,
        //    macAddr = getMacAddress().ToString(),
        //    localIPAddr = getLocalIPAddress().ToString(),
        //    externalIPAddr = getExternalIP().ToString()
        //};

        public void getJsonFeatures()
        {
            try
            {
                jsonFeatures = new FeaturesModel()
                {
                    osVersion = Environment.OSVersion.ToString(),
                    servicePack = Environment.OSVersion.ServicePack,
                    machineName = Environment.MachineName,
                    userDomain = Environment.UserDomainName,
                    localUserName = Environment.UserName,
                    macAddr = getMacAddress().ToString(),
                    localIPAddr = getLocalIPAddress().ToString(),
                    externalIPAddr = getExternalIP().ToString()
                };
            }
            catch (Exception e)
            {
                log.Error(e);
            }

        }

        public string getFeatures()
        {
            getJsonFeatures();
            return Newtonsoft.Json.JsonConvert.SerializeObject(jsonFeatures, Formatting.Indented);
        }
    }
}
