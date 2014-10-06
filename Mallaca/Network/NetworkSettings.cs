using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Mallaca.Network
{
    public static class NetworkSettings
    {
        public static string ServerIP = "127.0.0.1";
        public static int ServerPort = 9001;

        public static string ClientIP {
            get { 
                var clientip = Dns.GetHostEntry(Dns.GetHostName())
                .AddressList.First(o => o.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                .ToString();
                return clientip; 
            }
        }

        public static IPEndPoint ServerEndPoint = new IPEndPoint(IPAddress.Parse(ServerIP), ServerPort);
    }
}
