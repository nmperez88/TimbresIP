using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace TimbresIP
{
    class PCFeatures
    {
        public static PhysicalAddress GetMacAddress()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                // Only consider Ethernet network interfaces
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet &&
                    nic.OperationalStatus == OperationalStatus.Up)
                {
                    return nic.GetPhysicalAddress();
                }
            }
            return null;
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        public static string GetExternalIP()
        {
            string externalip = new WebClient().DownloadString("http://icanhazip.com");
            return externalip;
        }
        public Array pcFeatures()
        {
           string[] pcFeatures = new string[] {Environment.OSVersion.ToString(),Environment.OSVersion.ServicePack,Environment.MachineName,Environment.UserDomainName,Environment.UserName,GetMacAddress().ToString(),GetLocalIPAddress(),GetExternalIP()};
           return pcFeatures; 
        }
    }
}
