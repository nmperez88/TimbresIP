using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;

namespace TimbresIP
{
    class FeaturesUtils
    {
        //Metodo para obtener la MACADDR del cliente
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

        //Metodo para obtener la IPADDR interna del cliente
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

        //Metodo para obtener la IPADDR externa del cliente
        public static string getExternalIP()
        {
            string externalIp = new WebClient().DownloadString(Properties.Settings.Default.dnsExternalConsult);
            return externalIp;
        }

        //Devuelve todas las caracteristicas de interes del PC
        public string[] pcFeatures { get; set; } = new string[]
        {      "The OSVersion is: " + Environment.OSVersion.ToString(),
               "The ServicePack is: " +Environment.OSVersion.ServicePack,
               "The Machine Name is: " +Environment.MachineName,
               "The User Domain is: " +Environment.UserDomainName,
               "The Local User Name is: " +Environment.UserName,
               "The MAC Address is: " +getMacAddress().ToString(),
               "The Local IP Address is: " +getLocalIPAddress(),
               "The External IP Address is: " +getExternalIP()
        };
    }
}
