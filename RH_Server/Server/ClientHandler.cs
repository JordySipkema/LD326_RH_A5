using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Mallaca;
using Newtonsoft.Json.Linq;

namespace RH_Server.Server
{
    class ClientHandler
    {
        public readonly byte[] Buffer = new byte[1024];
        public int BufferSize = 1024;
        public Socket Socket;

        private string _totalBuffer = "";

        //private string username;
        //private Boolean isLoggedIn;
        int totalReceived = 0;

        public void OnRead(IAsyncResult ar)
        {
            try
            {
                
                int receiveCount = Socket.EndReceive(ar);
                totalReceived += receiveCount;
                _totalBuffer += ASCIIEncoding.Default.GetString(Buffer, 0, receiveCount);
                
                
                if (_totalBuffer.Length >= 4)
                {
                    int packetSize = int.Parse(_totalBuffer.Substring(0, 4));
                    if (_totalBuffer.Length >= packetSize + 4)
                    {
                        Console.WriteLine(_totalBuffer);
                        string jsonData = _totalBuffer.Substring(4, packetSize);
                        var json = JObject.Parse(jsonData);

                        var packetType = (string)json["CMD"];

                        switch (packetType)
                        {
                            case "ping":
                                HandlePingPacket(json);
                                break;
                            case "dc":
                                HandleDisconnectPacket(json);
                                break;
                            default:
                                Console.WriteLine("Unknown packet");
                                break;
                        }




                        _totalBuffer = _totalBuffer.Substring(packetSize + 4);
                    }
                }


                Socket.BeginReceive(Buffer, 0, 1024, 0, OnRead, null);
            }
            catch (SocketException)
            {
                Console.WriteLine("Client has been disconnected.");
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
                    new JProperty("DESC",Statuscode.GetDescription(Statuscode.Status.Ok)),
                    new JProperty("AUTHTOKEN", authtoken)
                );

            Console.WriteLine(returnJson.ToString());
        }

        public void HandleDisconnectPacket(JObject json)
        {
            //var authtoken = (string)json["AUTHTOKEN"];

            //TODO: Code for saving data to DB/FileIO
            //code to release the authtoken

            var returnJson =
                new JObject(
                       
                    );
        }
    }
}
