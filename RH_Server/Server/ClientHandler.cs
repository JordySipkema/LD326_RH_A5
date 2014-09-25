﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Mallaca;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace RH_Server.Server
{
    class ClientHandler
    {
        private Thread _thread;

        public readonly byte[] Buffer = new byte[1024];
        public int BufferSize = 1024;
        public Socket Socket;

        private string _totalBuffer = "";

        //private string username;
        //private Boolean isLoggedIn;

        public ClientHandler()
        {
            _thread = new Thread(ThreadLoop);
            _thread.Start();
        }

        private void ThreadLoop()
        {
            while (true)
            {
                try
                {
                    var receiveCount = Socket.Receive(Buffer);
                    _totalBuffer += ASCIIEncoding.Default.GetString(Buffer, 0, receiveCount);

                    if (_totalBuffer.Length < 4) continue; 
                    //Continue means: if _totalBuffer.Lenght < 4, DO NOT PROCEED

                    var packetSize = int.Parse(_totalBuffer.Substring(0, 4));

                    if (_totalBuffer.Length < packetSize + 4) continue; 
                    //Continue means: if statement == true, DO NOT PROCEED

                    var jsonData = _totalBuffer.Substring(4, packetSize);
                    Console.WriteLine(jsonData);

                    var json = JObject.Parse(jsonData);

                    var packetType = (string)json["CMD"];

                    switch (packetType)
                    {
                        case "ping":
                            HandlePingPacket(json);
                            break;
                        case "dc":
                            //HandleDisconnectPacket(json);
                            Console.WriteLine("DC PACKET RECIEVED");
                            break;
                        case "push":
                            Console.WriteLine("This is a push packet!");
                            break;
                        default:
                            Console.WriteLine("Unknown packet");
                            break;
                    }




                    _totalBuffer = _totalBuffer.Substring(packetSize + 4);
                    //_totalBuffer = String.Empty;
                }
                catch (SocketException e)
                {
                    Console.WriteLine("Client has been disconnected.");
                    Console.WriteLine(e.Message);
                }
            }
        }

        private void SendPacket(String packet)
        {
            packet = packet.Length.ToString().PadRight(4, ' ') + packet;
            Socket.Send(ASCIIEncoding.Default.GetBytes(packet));
        }

        private void HandlePingPacket(JObject json)
        {
            //String time = json.time;
            Console.WriteLine("PING: Packet recieved");

        }

        public void HandleLoginPacket(JObject json)
        {
            //var username = (string)json["USER"];
            //var password = (string)json["PASSWORD"];

            const string username = "test1";
            const string password = "pass2";

            //Code to check user/pass here

            var authtoken = String.Format("{0}zZz{1}", username, password);
            var returnJson =
                new JObject(
                    new JProperty("STATUS", Statuscode.GetCode(Statuscode.Status.Ok)),
                    new JProperty("DESC", Statuscode.GetDescription(Statuscode.Status.Ok)),
                    new JProperty("AUTHTOKEN", authtoken)
                );
            
            Console.WriteLine(returnJson.ToString());
        }

        public void HandleDisconnectPacket(JObject json)
        {
            //var authtoken = (string)json["AUTHTOKEN"];

            //TODO: Code for saving data to DB/FileIO
            //code to release the authtoken
        }
    }
}
