using Microsoft.WindowsAPICodePack.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetectNetworkChanges.Objects
{
    internal class NetworkSummary : IEquatable<NetworkSummary>
    {

        internal Guid connID = new Guid();
        internal Guid netID = new Guid();
        internal Guid adapterID = new Guid();
        internal string IPAddress = string.Empty;
        internal string AdapterName = string.Empty;
        internal string NetworkName = string.Empty;
        internal Boolean IsConnected = false;
        internal Boolean IsConnectedToInternet = false;


        /// <summary>
        /// Get the network summary by the Network Name
        /// </summary>
        /// <param name="vNetworkName"></param>
        internal NetworkSummary(String vNetworkName)
        {
            netID = NetworkFunctions.getNetworkID(vNetworkName, NetworkConnectivityLevels.All);  //NetworkFunctions.getConnectedNetworkID();
            connID = NetworkFunctions.getConnectionID(netID, NetworkConnectivityLevels.All);            
            adapterID = NetworkFunctions.getAdapterID(netID.ToString(), NetworkConnectivityLevels.All);
            IPAddress = NetworkFunctions.getCurrentIP(adapterID);
            NetworkFunctions.getNetworkConnectionInfo(vNetworkName, NetworkConnectivityLevels.All, out IsConnected, out IsConnectedToInternet);

            NetworkName = NetworkFunctions.getNetworkName(netID, NetworkConnectivityLevels.All);
            AdapterName = NetworkFunctions.getAdapterDescription(adapterID);
        }


        /// <summary>
        /// Get the network summary by the Network ID
        /// </summary>
        /// <param name="vNetworkID"></param>
        internal NetworkSummary(Guid vNetworkID)
        {
            netID = vNetworkID;
            connID = NetworkFunctions.getConnectionID(netID, NetworkConnectivityLevels.All);
            adapterID = NetworkFunctions.getAdapterID(vNetworkID.ToString(), NetworkConnectivityLevels.All);
            IPAddress = NetworkFunctions.getCurrentIP(adapterID);
            NetworkFunctions.getNetworkConnectionInfo(NetworkFunctions.getNetworkName(vNetworkID, NetworkConnectivityLevels.All), NetworkConnectivityLevels.All, out IsConnected, out IsConnectedToInternet);

            NetworkName = NetworkFunctions.getNetworkName(netID, NetworkConnectivityLevels.All);
            AdapterName = NetworkFunctions.getAdapterDescription(adapterID);
        }


        public bool Equals(NetworkSummary other)
        {
            if (
                this.adapterID == other.adapterID
                && this.AdapterName == other.AdapterName
                && this.IPAddress == other.IPAddress
                && this.IsConnected == other.IsConnected
                && this.IsConnectedToInternet == other.IsConnectedToInternet
                && this.netID == other.netID
                && this.NetworkName == other.NetworkName                
                )
            {
                return true;
            }

            return false;
        }
    }
}
