using System.Collections.Generic;
using System.Linq;
using Mallaca;
using Mallaca.Network;
using Mallaca.Network.Packet.Request;
using Mallaca.Network.Packet.Response;
using Newtonsoft.Json.Linq;
using RH_Server.Properties;
using RH_Server.Server;
using System;
using System.Net;
using System.Net.Sockets;

namespace RH_Server
{
    internal class Program
    {
        static void Main()
        {
            RunServer();
        }

        static void RunServer()
        {
            Console.WriteLine(RH_Server_Resources.RH_Server_initializing);
            var serverListener = new TcpListener(IPAddress.Any, NetworkSettings.ServerPort); //Its over 9000!!!

            //Code for getting server IP
            var serverip = Dns.GetHostEntry(Dns.GetHostName())
                .AddressList.First(o => o.AddressFamily == AddressFamily.InterNetwork)
                .ToString();
            //Display server IP:
            Console.WriteLine(RH_Server_Resources.Message_RH_Server_IP, serverip);

            Console.WriteLine(RH_Server_Resources.RH_Server_READY);
            serverListener.Start();
            while (true)
            {
                var tcpclient = serverListener.AcceptTcpClient();
                Console.WriteLine(RH_Server_Resources.RH_Server_TCP_Client_accepted);
                var client = new ClientHandler(tcpclient);
            }
        }
    }
}
