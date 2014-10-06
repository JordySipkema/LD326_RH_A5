using System.Linq;
using System.Net;

namespace Mallaca.Network
{
    public static class NetworkSettings
    {
        public static string ServerIP = "127.0.0.1";
        public static int ServerPort = 9001;

        public static string ClientIP
        {
            get
            {
                var clientip =
                    Dns.GetHostEntry(Dns.GetHostName())
                        .AddressList.First(o => o.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        .ToString();
                return clientip;
            }
        }

        public static IPEndPoint ServrEndPoint = new IPEndPoint(IPAddress.Parse(ServerIP), ServerPort);
    }
}
