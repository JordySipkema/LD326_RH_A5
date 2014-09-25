using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace RH_Server.Server
{
    class Client
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

        private void SendPacket(Object packet)
        {
            string jsonData = packet.ToString();

            jsonData = jsonData.Length.ToString().PadRight(4, ' ') + jsonData;
            Socket.Send(ASCIIEncoding.Default.GetBytes(jsonData));
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

            var username = "test1";
            var password = "pass2";

            //Code to check user/pass here


            var authtoken = String.Format("{0}zZz{1}", username, password);
            var returnJson = 
                new JObject(
                    new JProperty("STATUS", 200),
                    new JProperty("DESC", "OK!"),
                    new JProperty("AUTHTOKEN", authtoken)
                );

            Console.WriteLine(returnJson.ToString());
        }

        public void HandleStatusPacket(Statuscode codeStatuscode)
        {
            int code = 0;
            String desc = "";
            switch (codeStatuscode)
            {
                case Statuscode.Ok:
                    code = 200;
                    desc = "OK!";
                    break;
                case Statuscode.Unauthorized:
                    code = 401;
                    desc = "UNAUTHORIZED";
                    break;
                case Statuscode.AccessDenied:
                    code = 403;
                    desc = "ACCESS DENIED";
                    break;
                case Statuscode.InvalidUsernameOrPassword:
                    code = 430;
                    desc = "INVALID USERNAME OR PASSWORD";
                    break;
                case Statuscode.CommandNotFound:
                    code = 500;
                    desc = "COMMAND NOT FOUND";
                    break;
                case Statuscode.SyntaxError:
                    code = 501;
                    desc = "SYNTAX ERROR";
                    break;
                case Statuscode.CommandNotImplemented:
                    code = 502;
                    desc = "COMMAND NOT IMPLEMENTED";
                    break;
                default:
                    return;
            }
        }


        public enum Statuscode
        {
            Ok = 200,
            Unauthorized = 401,
            AccessDenied = 403,
            InvalidUsernameOrPassword = 430,
            CommandNotFound = 500,
            SyntaxError = 501,
            CommandNotImplemented = 502
        }
    }
}
