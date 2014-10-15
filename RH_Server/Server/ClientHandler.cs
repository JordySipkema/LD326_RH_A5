using Mallaca;
using Mallaca.Network;
using Mallaca.Network.Packet;
using Mallaca.Network.Packet.Response;
using Mallaca.Properties;
using Mallaca.Usertypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RH_Server.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace RH_Server.Server
{
    // ReSharper disable LocalizableElement
    class ClientHandler
    {
        private readonly byte[] _buffer = new byte[1024];
        private const int BufferSize = 1024;
        private readonly TcpClient _tcpclient;
        private readonly SslStream _sslStream;
        private readonly DBConnect _database;
        private List<byte> _totalBuffer;

        private readonly List<Measurement> _measurementsList = new List<Measurement>();

        private readonly DBConnect _dbConnect = new DBConnect();

        //private string username;
        //private Boolean isLoggedIn;

        public ClientHandler(TcpClient client)
        {
            _tcpclient = client;
            var certificate = new X509Certificate2(Resources._23tia5_centificate, "AvansHogeschool23ti2a5");
            //var certificate = new X509Certificate2(Resources.invalid_certificate, "apeture");

            _sslStream = new SslStream(_tcpclient.GetStream());
            _sslStream.AuthenticateAsServer(certificate);
            _totalBuffer = new List<byte>();
            _database = new DBConnect();
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
                    var receiveCount = _sslStream.Read(_buffer, 0, BufferSize);

                    var rawData = new byte[receiveCount];
                    Array.Copy(_buffer, 0, rawData, 0, receiveCount);
                    _totalBuffer = _totalBuffer.Concat(rawData).ToList();


                    int packetSize = Packet.GetLengthOfPacket(_totalBuffer);
                    if (packetSize == -1)
                        continue;

                    JObject json = Packet.RetrieveJson(packetSize, ref _totalBuffer);

                    if (json == null)
                        continue;

                    JToken cmd;
                    if (!json.TryGetValue("CMD", out cmd))
                    {
                        Console.WriteLine("Got JSON that does not define a command.");
                        continue;
                    }

                    var packetType = cmd.ToString().ToLower();

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




                    //_totalBuffer = _totalBuffer.Substring(packetSize + 4);
                    //_totalBuffer = String.Empty;
                }
                catch (SocketException e)
                {
                    Console.WriteLine("Client with IP-address: {0} has been disconnected", _tcpclient.Client.LocalEndPoint);
                    Console.WriteLine(e.Message);
                }
            }
        }

        private void Send(String s)
        {
            //byte[] data = Encoding.UTF8.GetBytes(s.Length.ToString("0000") + s).ToArray();

            _sslStream.Write(Packet.CreateByteData(s));
        }

        private void Send(Packet s)
        {
            Send(s.ToString());
        }

        private void HandlePingPacket(JObject json)
        {
            //String time = json.time;
            Console.WriteLine("PING: Packet recieved");
        }


        private void HandleListUsersPacket(JObject j)
        {
            throw new NotImplementedException();
            //var p = new ListUsersPacket();
            //Send(p);
        }

        private void HandleLoginPacket(JObject json)
        {
            Console.WriteLine("HandleLoginPacket:");
            //Recieve the username and password from json.
            var username = json["username"].ToString();
            var password = json["password"].ToString();

            JObject returnJson;
            //Code to check user/pass here
            if (Authentication.Authenticate(username, password, _sslStream))
            {
                returnJson = new LoginResponsePacket(
                    Statuscode.Status.Ok,
                    Authentication.GetUser(username).UserType.ToString(),
                    Authentication.GetUser(username).AuthToken
                    ).ToJsonObject();

            }
            else //If the code reaches this point, the authentification has failed.
            {
                returnJson =
                    new JObject(
                        new JProperty("CMD", "RESP-LOGIN"),
                        new JProperty("STATUS", Statuscode.GetCode(Statuscode.Status.InvalidUsernameOrPassword)),
                        new JProperty("DESCRIPTION", Statuscode.GetDescription(Statuscode.Status.InvalidUsernameOrPassword))
                        );
            }

            //Send the result back to the client.
            Console.WriteLine(returnJson.ToString());
            Send(returnJson.ToString());
        }

        private void HandlePushPacket(JObject json)
        {
            //var size = json["count"];
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
            var authtoken = (string)json["AUTHTOKEN"];

            //Release the authtoken
            Authentication.ReleaseAuthToken(authtoken);

            //Send a response:
            var resp = new ResponsePacket(Statuscode.Status.Ok, "resp-dc");
            Send(resp);
        }

        public void HandleChatPacket(JObject json)
        {
            var authToken = (string) json["AUTHTOKEN"];
            var username = (string) json["USERNAMEDESTINATION"];
            //var message = (string) json["MESSAGE"];

            //Check if the authToken is valid:
            if (Authentication.Authenticate(authToken))
            {
                var s = Authentication.GetStream(username);
                //TODO: Create and send json-object to the destination
                //HINT: use: Stream s
            }
            else
            {
                Send(new ResponsePacket(Statuscode.Status.Unauthorized));
            }
        }

        public void HandleResponseChatPacket(JObject json)
        {
            //TODO: Implement this method!
            throw new NotImplementedException();
        }

        public void HandlePullPacket(JObject json)
        {
            //WIP
            var returnJson = new JObject(new JProperty("CMD", "RESP-PULL"));
            switch (json["dataType"].ToString())
            {
                case "user":
                    JToken userid;
                    json.TryGetValue("dataID", out userid);
                    int userId;
                    int.TryParse((string)userid,out userId);

                    returnJson =
                            new JObject(
                                new JProperty("CMD", "resp-pull"),
                                new JProperty("data", _dbConnect.getUser(userId))
                                );
                    break;

                case "connectedclients":
                    Authentication.GetClients();
                    break;
                default:
                    return;
            }



            

            Send(returnJson.ToString());
            
        }

        public void HandleLsmPacket(JObject json)
        {
            JToken sessionId;

            json.TryGetValue("sessionID", out sessionId);

            var measurements = _dbConnect.getMeasurementsOfUser((string)json["username"], (string)json["sessionID"]);
            var i = measurements.Count;
            var m = JArray.FromObject(measurements);

            var returnJson = new JObject(
                new JProperty("CMD", "resp-lsm"),
                new JProperty("COUNT", i),
                new JProperty("MEASURMENTS", m)
                );

            //Send the result back to the specialist.
            Console.WriteLine(returnJson.ToString());
            Send(returnJson.ToString());
        }

        public void HandleLsuPacket(JObject json)
        {
            var users = _dbConnect.GetAllUsers();
            var i = users.Count;
            var u = JArray.FromObject(users);

            var returnJson = new JObject(
                new JProperty("CMD", "resp-lsu"),
                new JProperty("COUNT", i),
                new JProperty("MEASURMENTS", u)
                );

            //Send the result back to the specialist.
            Console.WriteLine(returnJson.ToString());
            Send(returnJson.ToString());
        }
    }
    // ReSharper restore LocalizableElement
}
