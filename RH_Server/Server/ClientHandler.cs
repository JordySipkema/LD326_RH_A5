using System.CodeDom;
using System.Collections;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Mallaca;
using Mallaca.Network;
using Mallaca.Network.Packet;
using Mallaca.Network.Packet.Request;
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
    internal class ClientHandler
    {
        private readonly byte[] _buffer = new byte[1024];
        private const int BufferSize = 1024;
        private readonly TcpClient _tcpclient;
        private readonly SslStream _sslStream;
        private readonly DBConnect _database;
        private List<byte> _totalBuffer;

        private readonly List<Measurement> _measurementsList = new List<Measurement>();

        private readonly DBConnect _dbConnect = new DBConnect();

        private User currentUser;
        private int currentSession = -1;
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
                    catch (JsonReaderException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine(Resources.ClientHandler_Sending_SyntaxError_packet_to, _tcpclient.Client.RemoteEndPoint);
                        Send(new ResponsePacket(Statuscode.Status.SyntaxError));
                    }

                    if (json == null)
                        continue;

                    JToken cmd;
                    JToken authToken = null;
                    if (!json.TryGetValue("CMD", out cmd))
                    {
                        Console.WriteLine(Resources.ClientHandler_Got_JSON_that_does_not_define_a_command);
                        continue;
                    }


                    var packetType = cmd.ToString().ToLower();

                    if (packetType != "login" && !json.TryGetValue("AUTHTOKEN", out authToken))
                    {
                        Console.WriteLine(Resources.ClientHandler_No_authtoken_found);
                        Send(new ResponsePacket(Statuscode.Status.Unauthorized));
                        continue;
                    }
                    // ReSharper disable once PossibleNullReferenceException
                    if (packetType != "login" && !Authentication.Authenticate(authToken.ToString()))
                    {
                        Console.WriteLine(Resources.ClientHandler_Recieved_Packet_Invalid_AuthToken);
                        Send(new ResponsePacket(Statuscode.Status.AccessDenied));
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
                        case "subscr":
                            HandleSubscribePacket(json);
                            break;
                        case "endtraining":
                            HandleEndTrainingPacket(json);
                            break;
                        case "notify":
                            HandleNotifyPacket(json);
                            break;


                        default:
                            Console.WriteLine(Resources.ClientHandler_Unknown_packet);
                            break;
                    }




                    //_totalBuffer = _totalBuffer.Substring(packetSize + 4);
                    //_totalBuffer = String.Empty;
                }
                catch (SocketException e)
                {
                    Console.WriteLine(Resources.ClientHandler_Client_Disconnected,
                        _tcpclient.Client.LocalEndPoint);
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    //break;
                }
            }
        }

        private void HandleNotifyPacket(JObject json)
        {
            NotifyPacket p = new NotifyPacket(json);

            switch (p.NotifySubject)
            {
                case NotifyPacket.Subject.StartTraining:
                case NotifyPacket.Subject.StopTraining:
                    if (currentUser.IsSpecialist || currentUser.IsAdministrator)
                    {
                        var clients = Notifier.Instance.GetListeners((Specialist)currentUser);
                        Client client = clients.First(x => x.Id == int.Parse(p.PrimaryValue));
                        Authentication.GetStream(client).Send(p);
                    }
                    break;
                default:
                    Console.WriteLine("Unsupported notify subject type: {0}", p.NotifySubject);
                    break;
            }
        }

        private void HandleEndTrainingPacket(JObject json)
        {
            currentSession = -1;
            _measurementsList.Clear();

                Send(new ResponsePacket(Statuscode.Status.Ok, "RESP-ENDTRAINING"));

        }

        public void Send(String s)
        {
            //byte[] data = Encoding.UTF8.GetBytes(s.Length.ToString("0000") + s).ToArray();

            _sslStream.Write(Packet.CreateByteData(s));
            _sslStream.Flush();
        }

        //private void Send(Object s)
        //{
        //    Send(s.ToString());
        //}

        private void Send(Packet p)
        {
            Send(p.ToString());
        }


        private void HandleLoginPacket(JObject json)
        {
            Console.WriteLine(Resources.ClientHandler_Debug_HandleLoginPacket);
            //Recieve the username and password from json.
            var username = json["username"].ToString();
            var password = json["password"].ToString();

            JObject returnJson;
            //Code to check User/pass here
            if (Authentication.Authenticate(username, password, this))
            {
                currentUser = _database.getUser(username);
                returnJson = new LoginResponsePacket(
                    Statuscode.Status.Ok,
                    Authentication.GetUser(username).AuthToken,
                    currentUser
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
            var measurements = json["DataSource"].Children();
            var datatype = (string)json["Datatype"];
            var authtoken = (string) json["AUTHTOKEN"];

            if (!Authentication.Authenticate(authtoken))
            {
                Send(new ResponsePacket(Statuscode.Status.Unauthorized));
                return;
            }

            int id = currentUser.Id ?? -1;
            if (currentSession == -1)
            {
                currentSession = _database.getNewTrainingSessionId(id);
                var notifyPacket = new NotifyPacket(NotifyPacket.Subject.NewTrainingId, currentSession.ToString(),
    currentUser.NonNullId.ToString(), "");
                Send(notifyPacket);
                var specs = Notifier.Instance.GetListeners((Client) currentUser).ToList();
                specs.ForEach(x => Authentication.GetStream(x).Send(notifyPacket));
            }

            if (datatype == "Measurements")
            {

                List<Measurement> measurementsL = new List<Measurement>();
                foreach (var m in measurements.Select(
                    jtoken => jtoken.ToObject<Measurement>())
                    )
                {
                    measurementsL.Add(m);
                    Console.WriteLine(Resources.ClientHandler_HandlePushPacked_Recieved, measurements.FirstOrDefault());
                }

                _database.SaveMeasurements(measurementsL, currentSession, id);

                var senderU = Authentication.GetUserByAuthToken(authtoken);
                // Check that sender is a client. if its not, return.
                if (!(senderU is Client)) return;

                var senderC = senderU as Client;
                //Should we notify anyone for this sender? If not, return.
                if (!Notifier.Instance.ShouldNotify(senderC)) return;

                // Get all handlers based on all listeners their username.
                var handlers =
                    Notifier.Instance.GetListeners(senderC)
                        .Select(listener => Authentication.GetStream(listener.Username));

                var mList = measurements.Select(m => JsonConvert.DeserializeObject<Measurement>(m.ToString())).ToList();

                // Building new json


                foreach (var handler in handlers)
                {
                    Console.WriteLine("Notified " + handler.currentUser.Fullname);
                    var returnJson = new DataFromClientPacket<Measurement>(mList, "measurements", currentUser.NonNullId);
                    //new PullResponsePacket<Measurement>(mList, "measurements");
                    handler.Send(returnJson);
                }
                //Console.WriteLine("Notified the listeners");
            }
            else if (datatype.Equals("Configuration", StringComparison.CurrentCultureIgnoreCase))
            {
                var p = new PushPacket<Configuaration>(json);
                var config = p.DataSource.FirstOrDefault();
                if (config == null)
                    return;

                Console.WriteLine("Sending config-push-packet");
                var stream = Authentication.GetStream(config.Username);
                stream.Send(p);
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
            var p = new ChatPacket(json);
            //var destinationClientHandler = Authentication.GetStream(p.UsernameDestination);


            var newPacket = new ChatPacket(p.Message, currentUser.Username, "SERVER");
            if (currentUser.IsSpecialist || currentUser.IsAdministrator)
            {
                if (p.IsBroadcast)
                {
                    var broadcast = new ChatPacket(p.Message, p.UsernameDestination, "", true);
                    Authentication.GetAllUsers().ForEach(x => x.Send(broadcast));
                }
                else
                {

                    var spec = currentUser as Specialist;
                    var clients = Notifier.Instance.GetListeners(spec);
                    //get all other specialist subscribed to this client, excluding the sending specialist
                    var specialists =
                        Notifier.Instance.GetListeners((Client) _database.getUser(p.UsernameDestination))
                            .Where(x => x.Username != currentUser.Username);

                    var allReceivers = clients.Concat<User>(specialists).Distinct(new User.UserComparer());
                    allReceivers.ToList().ForEach(x => Authentication.GetStream(x).Send(newPacket));
                }


            }
            else
            {
                var clie = currentUser as Client;
                var specialists = Notifier.Instance.GetListeners(clie).ToList();

                specialists.ForEach(x => Authentication.GetStream(x.Username).Send(newPacket));
            }

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
                    int userId;
                    int.TryParse((string)userid,out userId);
                    var useristList = new List<User> {_dbConnect.getUser(userId)};
                    resp = new PullUsersResponsePacket(useristList, "user");
                    break;

                case "users":
                    resp = new PullUsersResponsePacket(_database.GetAllUsers(), "User");
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
                default:
                    Console.WriteLine(Resources.ClientHandler_HandlePullPacket_Non_implemented_data_type + json["dataType"].ToString());
                    return;
            }



            
            //Console.WriteLine(json);
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

            var response = new PullResponsePacket<Measurement>(measurements,"measurements");

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

        public void HandleSubscribePacket(JObject json)
        {
            var notifier = Notifier.Instance;
            var packet = SubscribePacket.GetSubscribePacket(json);

            if (packet == null)
            {
                Send(new ResponsePacket(Statuscode.Status.SyntaxError, "resp-subscr"));
                return;
            }

            var specialist = Authentication.GetUserByAuthToken(packet.AuthToken) as Specialist;
            var client = Authentication.GetUser(packet.Client) as Client;

            var success = packet.Subscribe ? notifier.Subscribe(specialist, client) : notifier.Unsubscribe(specialist, client);

            
            if (packet.Subscribe)
            {
                ChatPacket serverToClientMessage = new ChatPacket(String.Format("{0} has connected to your training and is monitoring your progress.", specialist.Fullname),"","");
                ChatPacket serverToSpecMessage = new ChatPacket(String.Format("You have sucessfully connected to {0}", client.Fullname), "", "");    
                Authentication.GetStream(client).Send(serverToClientMessage);
                Authentication.GetStream(specialist).Send(serverToSpecMessage);
            }
            else
            {
                ChatPacket serverToClientMessage = new ChatPacket(String.Format("{0} has deemed you unworthy of his time and has disconnected.", specialist.Fullname), "", "");
                ChatPacket serverToSpecMessage = new ChatPacket(String.Format("You have sucessfully abandoned {0}'s training.", client.Username), "", "");
                Authentication.GetStream(client).Send(serverToClientMessage);
                Authentication.GetStream(specialist).Send(serverToSpecMessage);
            }

            Send(new ResponsePacket(Statuscode.Status.Ok, "resp-subscr"));

        }
    }
}
