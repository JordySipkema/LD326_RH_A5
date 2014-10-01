using System.Linq;
using Newtonsoft.Json.Linq;
using RH_Server.Classes;
using RH_Server.Server;
using System;
using System.Net;
using System.Net.Sockets;

namespace RH_Server
{
    class Program
    {
        static void Main()
        {
            TestCode();
            //RunServer();
        }

        static void TestCode()
        {
            var x = Authentication.Authenticate("Jordy", "Sipkema");
            Console.ReadKey();
        }

        static void RunServer()
        {
            Console.WriteLine("RH_Server initializing");
            var serverListener = new TcpListener(IPAddress.Any, 9001); //Its over 9000!!!

            //Code for getting server IP
            var serverip = Dns.GetHostEntry(Dns.GetHostName())
                .AddressList.First(o => o.AddressFamily == AddressFamily.InterNetwork)
                .ToString();
            //Display server IP:
            Console.WriteLine("RH_Server IP: {0}", serverip);

            Console.WriteLine("RH_Server READY! Now listening.");
            serverListener.Start();
            while (true)
            {
                var newSocket = serverListener.AcceptSocket();
                Console.WriteLine("Socket accepted");
                var client = new ClientHandler() {Socket = newSocket};
            }
        }
    }
}
