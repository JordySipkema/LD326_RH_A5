using System.Linq;
using Mallaca.Network;
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
            //TestCode();
            RunServer();
        }

        static void TestCode()
        {
            //Implecit type-cast test!
            JObject test1 = new LoginResponsePacket(
                Statuscode.Status.Ok,
                "Test1",
                "Test2");

            JObject test2 = new ResponsePacket(Statuscode.Status.InvalidUsernameOrPassword, "RESP-LOGIN");

            Console.WriteLine(test1.ToString());
            Console.WriteLine(test2.ToString());
            Console.ReadKey();
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
