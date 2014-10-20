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
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace RH_Server.Server
{
    // ReSharper disable LocalizableElement
    public class ClientHandler
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
                if (!_tcpclient.Connected)
                    break;
                try
                {
                    //new Socket().Receive(Buffer);
                    var receiveCount = _sslStream.Read(_buffer, 0, BufferSize);

                    var rawData = new byte[receiveCount];
                    Array.Copy(_buffer, 0, rawData, 0, receiveCount);
                    _totalBuffer = _totalBuffer.Concat(rawData).ToList();


                    var packetSize = Packet.GetLengthOfPacket(_totalBuffer);
                    if (packetSize == -1)
                        continue;

                    JObject json = null;
                    try
                    {
                        json = Packet.RetrieveJson(packetSize, ref _totalBuffer);
                    }
                    catch (JsonReaderException)
                    {
                        Console.WriteLine("Sending SyntaxError-packet to {0}", _tcpclient.Client.RemoteEndPoint);
                        Send(new ResponsePacket(Statuscode.Status.SyntaxError));
                    }

                    if (json == null)
                        continue;

                    JToken cmd;
                    JToken authToken = null;
                    if (!json.TryGetValue("CMD", out cmd))
                    {
                        Console.WriteLine("Got JSON that does not define a command.");
                        continue;
                    }


                    var packetType = cmd.ToString().ToLower();

                    if (packetType != "login" && !json.TryGetValue("AUTHTOKEN", out authToken))
                    {
                        Console.WriteLine("No authtoken found in packet.");
                        continue;
                    }
                    if (packetType != "login" && !Authentication.Authenticate(authToken.ToString()))
                    {
                        Console.WriteLine("Got a packet with an invalid authentication token.");
                        continue;
                    }

                    switch (packetType)
                    {
                        case "login":
                            HandleLoginPacket(json);
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
                    Console.WriteLine("Client with IP-address: {0} has been disconnected",
                        _tcpclient.Client.LocalEndPoint);
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    break;
                }
            }
        }

        public void Send(String s)
        {
            //byte[] data = Encoding.UTF8.GetBytes(s.Length.ToString("0000") + s).ToArray();

            _sslStream.Write(Packet.CreateByteData(s));
            _sslStream.Flush();
        }

        private void Send(Object s)
        {
            Send(s.ToString());
        }


        private void HandleLoginPacket(JObject json)
        {
            Console.WriteLine("HandleLoginPacket:");
            //Recieve the username and password from json.
            var username = json["username"].ToString();
            var password = json["password"].ToString();

            JObject returnJson;
            //Code to check user/pass here
            if (Authentication.Authenticate(username, password, this))
            {
                returnJson = new LoginResponsePacket(
                    Statuscode.Status.Ok,
                    Authentication.GetUser(username).UserType.ToString(),
                    Authentication.GetUser(username).AuthToken
                    ).ToJsonObject();

            }
            else //If the code reaches this point, the authentification has failed.
            {
                returnJson = new ResponsePacket(Statuscode.Status.InvalidUsernameOrPassword, "RESP-LOGIN");
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

            var s = Authentication.GetStream(username);
            s.Send(json["MESSAGE"]);


        }

        public void HandleResponseChatPacket(JObject json)
        {
            //TODO: Implement this method!
            throw new NotImplementedException();
        }

        public void HandlePullPacket(JObject json)
        {

            Packet resp;
            switch (json["dataType"].ToString())
            {
                case "user":
                    JToken userid;
                    json.TryGetValue("dataID", out userid);
                    int userID;
                    int.TryParse((string)userid,out userID);
                    List<User> useristList = new List<User> {_dbConnect.getUser(userID)};
                    resp = new PullUsersResponsePacket(useristList, "user");
                    break;

                case "users":
                    resp = new PullUsersResponsePacket(_database.GetAllUsers(), "user");
                    break;

                case "connected_clients":
                    resp = new PullUsersResponsePacket(Authentication.GetClients(), "connected_clients");
                    break;
                case "user_sessions":
                    resp = new PullResponsePacket<SessionData>(_database.GetTrainingSessions(),
                        "user_sessions");
                    break;
                case "measurements":
                    HandleLsmPacket(json);
                    return;
                    break;
                default:
                    Console.WriteLine("Non-implemented data type: " + json["dataType"].ToString());
                    return;
            }



            
            Console.WriteLine(json);
            string data = resp.ToString();
            Send(data);
            
        }

        public void HandleLsmPacket(JObject json)
        {
            JToken sessionId;
            JToken username;
            JToken UserId;
            json.TryGetValue("sessionID", out sessionId);
            json.TryGetValue("username", out username);
            json.TryGetValue("dataId", out UserId);

            var measurements = _dbConnect.getMeasurementsOfUser(username == null ? UserId.ToString() : username.ToString(), json["sessionID"].ToString());
            var i = measurements.Count;
            var m = JArray.FromObject(measurements);

            PullResponsePacket<Measurement> response = new PullResponsePacket<Measurement>(measurements,"measurements");

            //Send the result back to the specialist.
            Console.WriteLine(response.ToString());
            Send(response.ToString());
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
