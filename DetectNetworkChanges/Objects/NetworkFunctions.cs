using Microsoft.WindowsAPICodePack.Net;
using System;
using System.Linq;
using System.Net.NetworkInformation;


namespace DetectNetworkChanges.Objects
{
    static class NetworkFunctions
    {

        /// <summary>
        /// Get the network name from the ID
        /// </summary>
        /// <param name="vNetworkId"></param>
        /// <param name="vConnectivityLevels"></param>
        /// <returns></returns>
        public static string getNetworkName(Guid vNetworkId, NetworkConnectivityLevels vConnectivityLevels)
        {
            string output = string.Empty;

            NetworkCollection netCollection = NetworkListManager.GetNetworks(vConnectivityLevels);
            foreach (Network n in netCollection)
            {
                if (n.NetworkId == vNetworkId)
                {
                    output = n.Name;
                    break;
                }
            }

            return output;
        }


        /// <summary>
        /// Get the ID for the network from the name/ssid
        /// </summary>
        /// <param name="vNetworkName"></param>
        /// <param name="vConnectivityLevels"></param>
        /// <returns></returns>
        public static Guid getNetworkID(String vNetworkName, NetworkConnectivityLevels vConnectivityLevels)
        {
            Guid output = new Guid();

            NetworkCollection netCollection = NetworkListManager.GetNetworks(vConnectivityLevels);
            foreach (Network n in netCollection)
            {
                if (n.Name == vNetworkName)
                {
                    output = n.NetworkId;
                    break;
                }
            }

            return output;
        }


        /// <summary>
        /// Get the information on if the network is connected, and connected to the internet
        /// </summary>
        /// <param name="vNetworkName"></param>
        /// <param name="vConnectivityLevels"></param>
        /// <param name="vIsConnected"></param>
        /// <param name="vIsConnectedToInternet"></param>
        public static void getNetworkConnectionInfo(String vNetworkName, NetworkConnectivityLevels vConnectivityLevels, out bool vIsConnected, out bool vIsConnectedToInternet)
        {
            vIsConnected = false;
            vIsConnectedToInternet = false;

            NetworkCollection netCollection = NetworkListManager.GetNetworks(vConnectivityLevels);
            foreach (Network n in netCollection)
            {
                if (n.Name == vNetworkName)
                {
                    vIsConnected = n.IsConnected;
                    vIsConnectedToInternet = n.IsConnectedToInternet;
                    break;
                }
            }

        }


        /// <summary>
        /// Get the Adapter ID from the supplied network ID
        /// </summary>
        /// <param name="vNetworkID"></param>
        /// <param name="vConnectivityLevels"></param>
        /// <returns></returns>
        public static Guid getAdapterID(string vNetworkID, NetworkConnectivityLevels vConnectivityLevels)
        {
            Guid output = new Guid();

            NetworkCollection netCollection = NetworkListManager.GetNetworks(vConnectivityLevels);
            foreach (Network n in netCollection)
            {
                string nID = n.NetworkId.ToString();
                //if (nID.Equals(vNetworkID.ToString().ToUpper())) 
                if (nID == vNetworkID.ToString())
                    foreach (NetworkConnection c in n.Connections)
                    {
                        if (c.Network.NetworkId == n.NetworkId)
                        {
                            output = c.AdapterId;
                            break;
                        }
                    }
            }

            return output;
        }



        /// <summary>
        /// Get the Connection ID for the supplied network
        /// </summary>
        /// <param name="vNetworkID"></param>
        /// <param name="vConnectivityLevels"></param>
        /// <returns></returns>
        public static Guid getConnectionID(Guid vNetworkID, NetworkConnectivityLevels vConnectivityLevels)
        {
            Guid output = new Guid();

            NetworkCollection netCollection = NetworkListManager.GetNetworks(vConnectivityLevels);
            foreach (Network n in netCollection)
            {
                foreach (NetworkConnection c in n.Connections)
                {
                    if (c.Network.NetworkId == n.NetworkId && vNetworkID == c.Network.NetworkId)
                    {
                        output = c.ConnectionId;
                        break;
                    }
                }
            }

            return output;
        }


        /// <summary>
        /// Get the IP address for the supplied adapter ID
        /// </summary>
        /// <param name="vAdapterID"></param>
        /// <returns></returns>
        public static string getCurrentIP(Guid vAdapterID)
        {
            string output = string.Empty;

            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                //if (ni.Id.ToUpper().Replace("{", "").Replace("}", "") == vNicID.ToUpper())
                if (ni.Id.Contains(vAdapterID.ToString().ToUpper()))
                    if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet || ni.NetworkInterfaceType == NetworkInterfaceType.GigabitEthernet)
                    {
                        //Console.WriteLine(ni.Name);
                        foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                            {
                                //Console.WriteLine(ip.Address.ToString());
                                output = ip.Address.ToString();
                                break;
                            }
                        }
                    }
            }

            return output;
        }


        /// <summary>
        /// Get the description of the adapter from the Adapter ID
        /// </summary>
        /// <param name="vAdapterID"></param>
        /// <returns></returns>
        public static string getAdapterDescription(Guid vAdapterID)
        {
            string output = string.Empty;

            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters.Where(a => a.OperationalStatus == OperationalStatus.Up))
            {
                if (adapter.Id.Contains(vAdapterID.ToString().ToUpper()))
                {
                    output = adapter.Description;
                    break;
                }
            }

            return output;
        }




        /// <summary>
        /// Get the name of the adapater from its ID
        /// </summary>
        /// <param name="vAdapterID"></param>
        /// <returns></returns>
        public static string getAdapterName(Guid vAdapterID)
        {
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();

            //foreach (NetworkInterface adapter in adapters.Where(a => a.OperationalStatus == OperationalStatus.Up))
            foreach (NetworkInterface adapter in adapters)
            {
                if (adapter.Id.Contains(vAdapterID.ToString().ToUpper()))
                {
                    return adapter.Name;
                }

            }

            return string.Empty;
        }


        /// <summary>
        /// Test function to get network info
        /// </summary>
        public static void DisplayUpNetworkAdaptersInfo()
        {
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters.Where(a => a.OperationalStatus == OperationalStatus.Up))
            {
                Console.WriteLine("\nDescription: {0} \nId: {1} \nIsReceiveOnly: {2} \nName: {3} \nNetworkInterfaceType: {4} " +
                    "\nOperationalStatus: {5} " +
                    "\nSpeed (bits per second): {6} " +
                    "\nSpeed (kilobits per second): {7} " +
                    "\nSpeed (megabits per second): {8} " +
                    "\nSpeed (gigabits per second): {9} " +
                    "\nSupportsMulticast: {10}",
                    adapter.Description,
                    adapter.Id,
                    adapter.IsReceiveOnly,
                    adapter.Name,
                    adapter.NetworkInterfaceType,
                    adapter.OperationalStatus,
                    adapter.Speed,
                    adapter.Speed / 1000,
                    adapter.Speed / 1000 / 1000,
                    adapter.Speed / 1000 / 1000 / 1000,
                    adapter.SupportsMulticast);

                var ipv4Info = adapter.GetIPv4Statistics();
                Console.WriteLine("OutputQueueLength: {0}", ipv4Info.OutputQueueLength);
                Console.WriteLine("BytesReceived: {0}", ipv4Info.BytesReceived);
                Console.WriteLine("BytesSent: {0}", ipv4Info.BytesSent);

                if (adapter.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 ||
                    adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {

                    Console.WriteLine("*** Ethernet or WiFi Network - Speed (bits per seconde): {0}", adapter.Speed);
                }
            }
            Console.WriteLine();

        }


        /// <summary>
        /// Test function to get network ID and signal strength
        /// </summary>
        private static void showConnectedId()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "netsh.exe";
            p.StartInfo.Arguments = "wlan show interfaces";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();

            string s = p.StandardOutput.ReadToEnd();
            string s1 = s.Substring(s.IndexOf("SSID"));
            s1 = s1.Substring(s1.IndexOf(":"));
            s1 = s1.Substring(2, s1.IndexOf("\n")).Trim();

            string s2 = s.Substring(s.IndexOf("Signal"));
            s2 = s2.Substring(s2.IndexOf(":"));
            s2 = s2.Substring(2, s2.IndexOf("\n")).Trim();

            Console.WriteLine("WIFI connected to " + s1 + "  " + s2);
            p.WaitForExit();
        }




    }
}
