using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Mallaca;
using Mallaca.Network;
using Mallaca.Network.Packet;
using Mallaca.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using RH_Server.Classes;

namespace RH_Server.Server
{
    class ClientHandler
    {
        private readonly byte[] Buffer = new byte[1024];
        private const int _bufferSize = 1024;
        private readonly TcpClient _tcpclient;
        private readonly SslStream _sslStream;

        private string _totalBuffer = "";

        private readonly List<Measurement> _measurementsList = new List<Measurement>();

        private DBConnect _dbConnect = new DBConnect();

        //private string username;
        //private Boolean isLoggedIn;

        public ClientHandler(TcpClient client)
        {
            _tcpclient = client;
            var certificate = new X509Certificate2(Resources._23tia5_centificate, "AvansHogeschool23ti2a5");
            //var certificate = new X509Certificate2(Resources.invalid_certificate, "apeture");

            _sslStream = new SslStream(_tcpclient.GetStream());
            _sslStream.AuthenticateAsServer(certificate);

            var thread = new Thread(ThreadLoop);
            thread.Start();

        }

        private void ThreadLoop()
        {
            while (true)
            {
                try
                {
                    //new Socket().Receive(Buffer);
                    var receiveCount = _sslStream.Read(Buffer, 0, _bufferSize);
                    _totalBuffer += ASCIIEncoding.Default.GetString(Buffer, 0, receiveCount);


                    var packetSize = Packet.getLengthOfPacket(_totalBuffer);
                    if (packetSize == -1)
                        continue;

                    JObject json = Packet.RetrieveJSON(packetSize, _totalBuffer);

                    if (json == null)
                        continue;

                    var packetType = (string)json["CMD"];

                    switch (packetType)
                    {
                        case "login":
                            HandleLoginPacket(json);
                            break;
                        case "ping":
                            HandlePingPacket(json);
                            break;
                        case "dc":
                            HandleDisconnectPacket(json);
                            break;
                        case "push":
                            HandlePushPacket(json);
                            break;
                        case "chat":
                            HandleChatPacket(json);
                            break;
                        case "pull":
                            HandlePullPacket(json);
                            break;
                        case "lsm":
                            HandleLsmPacket(json);
                            break;
                        case "lsu":
                            HandleLsuPacket(json);
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
                    Console.WriteLine("Client with IP-address: " + _tcpclient.Client.LocalEndPoint + " has been disconnected.");
                    Console.WriteLine(e.Message);
                }
            }
        }


        private void SendPacket(String packet)
        {
            packet = packet.Length.ToString().PadRight(4, ' ') + packet;
            _sslStream.Write(ASCIIEncoding.Default.GetBytes(packet));
        }

        private void HandlePingPacket(JObject json)
        {
            //String time = json.time;
            Console.WriteLine("PING: Packet recieved");

        }

        private void HandleLoginPacket(JObject json)
        {
            //Recieve the username and password from json.
            var username = (string)json["USER"];
            var password = (string)json["PASSWORD"];

            JObject returnJson;
            //Code to check user/pass here
            if (Authentication.Authenticate(username, password, _sslStream))
            {

                returnJson =
                    new JObject(
                        new JProperty("STATUS", Statuscode.GetCode(Statuscode.Status.Ok)),
                        new JProperty("DESC", Statuscode.GetDescription(Statuscode.Status.Ok)),
                        new JProperty("AUTHTOKEN", Authentication.GetUser(username).AuthToken)
                        );

            }
            else //If the code reaches this point, the authentification has failed.
            {
                returnJson =
                    new JObject(
                        new JProperty("STATUS", Statuscode.GetCode(Statuscode.Status.InvalidUsernameOrPassword)),
                        new JProperty("DESC", Statuscode.GetDescription(Statuscode.Status.InvalidUsernameOrPassword))
                        );
            }

            //Send the result back to the client.
            Console.WriteLine(returnJson.ToString());
            SendPacket(returnJson.ToString());
        }

        private void HandlePushPacket(JObject json)
        {
            var size = json["count"];
            var measurements = json["measurements"].Children();

            foreach (var m in measurements.Select(
                jtoken => JsonConvert.DeserializeObject<Measurement>(jtoken.ToString())
                ))
            {
                _measurementsList.Add(m);
                Console.WriteLine("Recieved: \n {0}", json["measurements"]);
            }

        }

        public void HandleDisconnectPacket(JObject json)
        {
            //var authtoken = (string)json["AUTHTOKEN"];

            var filepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (var writer = new StreamWriter(filepath + "\\RH_SERVER_DATA.txt", append: false))
            {
                foreach (var measurement in _measurementsList)
                {
                    writer.WriteLine(measurement.toProtocolString());
                }
                writer.Flush();
            }
            Console.WriteLine("Written {0} measurements to file", _measurementsList.Count);

            //code to release the authtoken
        }

        public void HandleChatPacket(JObject json)
        {
            var authToken = (string) json["AUTHTOKEN"];
            var username = (string) json["USERNAMEDESTINATION"];
            var message = (string) json["MESSAGE"];

            //Check if the authToken is valid:
            if (Authentication.Authenticate(authToken))
            {
                
            }
        }

        public void HandleResponseChatPacket(JObject json)
        {
            String message;
            StreamReader reader = null;
            //StreamReader reader = new StreamReader();

            try
            {
                 message = reader.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                reader.Close();
                reader = null;
            }
        }

        public void HandlePullPacket(JObject json)
        {
            JToken userId;
            JToken username;
            JToken measurementID;
            JToken measurmentStart;

            json.TryGetValue("userID", out userId);
            json.TryGetValue("username", out username);
            json.TryGetValue("measurementID", out measurementID);
            json.TryGetValue("measurmentStart", out measurmentStart);

            _dbConnect.getMeasurement(userId, username, measurementID, measurmentStart);

        }

        public void HandleLsmPacket(JObject json)
        {
            // moet nog code komen
        }

        public void HandleLsuPacket(JObject json)
        {
            // moet nog code komen
        }
    }
}
