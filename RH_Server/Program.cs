using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json.Linq;
using RH_Server.Server;

namespace RH_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestCode();
            RunServer();
        }

        static void TestCode()
        {
            var c = new ClientHandler();
            c.HandleLoginPacket(new JObject());
            Console.ReadKey();
        }

        static void RunServer()
        {
            Console.WriteLine("RH_Server initializing");
            var serverListener = new TcpListener(IPAddress.Any, 9001); //Its over 9000!!!
            Console.WriteLine("RH_Server READY! Now listening.");
            serverListener.Start();
            while (true)
            {
                var newSocket = serverListener.AcceptSocket();
                var client = new ClientHandler() { Socket = newSocket };
                newSocket.BeginReceive(client.Buffer, 0, client.BufferSize, 0, client.OnRead, null); //This is an async call!
            }
        }
    }
}
