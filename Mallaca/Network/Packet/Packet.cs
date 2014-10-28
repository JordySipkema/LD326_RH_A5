using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Mallaca.Network.Packet.Request;
using Mallaca.Network.Packet.Response;
using Newtonsoft.Json.Linq;

namespace Mallaca.Network.Packet
{
    public abstract class Packet
    {

        public static int GetLengthOfPacket(string buffer)
        {
            if (buffer.Length < 4) return -1;
            //Continue means: if _totalBuffer.Lenght < 4, DO NOT PROCEED
            return int.Parse(buffer.Substring(0, 4));
        }

        public static int GetLengthOfPacket(List<byte> buffer)
        {
            if (buffer.Count < 4) return -1;
            int t = BitConverter.ToInt32(buffer.ToArray(), 0);
            return t;
        }

        /// <summary>
        ///  Tries to retrieve exactly one packet as a JSON object from a byte list.
        /// </summary>
        public static JObject RetrieveJson(int packetSize, ref List<byte> buffer)
        {
            if (buffer.Count < packetSize + 4) return null;
            var q = Encoding.UTF8.GetString(GetPacketBytes(packetSize, ref buffer).ToArray());
            return JObject.Parse(q);
        }

        private static List<byte> GetPacketBytes(int packetSize, ref List<byte> buffer)
        {
            List<byte> jsonData = buffer.GetRange(4, packetSize);
            buffer.RemoveRange(0, packetSize + 4);
            return jsonData;
        }

        /// <summary>
        ///  Creates a byte array from the specified string. First four bytes contains the lengh the data. The remainder of the bytes is the data bytes created from the given string.
        /// </summary>
        public static byte[] CreateByteData(string s)
        {
            // 4 bytes  1 - 2,147,483,647 byte(s) 
            // lenght   data
            //[][][][] [][][][][][][][][][]][][][][]
            byte[] bytes = Encoding.UTF8.GetBytes(s);
            byte[] length = BitConverter.GetBytes(bytes.Length);
            byte[] data = length.Concat(bytes).ToArray();
            return data;
        }

        public static Packet RetrievePacket(int packetSize, ref List<byte> buffer)
        {  
            Packet p = null;
            JObject json = RetrieveJson(packetSize, ref buffer);

            if (json == null)
                return null;

            //Console.WriteLine("Got " + json["CMD"].ToString().ToUpper() + " packet.");

            switch (json["CMD"].ToString().ToUpper())
            {
                case LoginResponsePacket.LoginRcmd:
                    p = new LoginResponsePacket(json);
                    break;
                case ChatPacket.DefCmd:
                    p = new ChatPacket(json);
                    break;
                case SubscribePacket.DefCmd:
                    p = SubscribePacket.GetSubscribePacket(json);
                    break;
                case DataFromClientPacket<Object>.DefCmd:
                    //only measurements are supported.
                    p = new DataFromClientPacket<Measurement>(json);
                    break;
                case PullResponsePacket<Object>.DefCmd:
                    p = HandlePullResponsePacket(json);
                    break;
                case PushPacket<Object>.DefCmd:
                    p = HandlePushPacket(json);
                    break;
                case NotifyPacket.Cmd:
                    p = new NotifyPacket(json);
                    break;
                default:
                    Console.WriteLine("Unsupported packet type: {0}", json["CMD"].ToString());
                    break;
            }
                                

            return p;
        }

        private static Packet HandlePushPacket(JObject json)
        {
            Packet p = null;

            JToken datatypeToken;
            if (!json.TryGetValue("Datatype", StringComparison.OrdinalIgnoreCase, out datatypeToken)) return null;

            var type = (PushPacket<Object>.DataType)Enum.Parse(typeof (PushPacket<Object>.DataType), (string) datatypeToken);
            switch (type)
            {
                case PushPacket<Object>.DataType.Configuration:
                    p = new PushPacket<Configuaration>(json);
                    break;
            }

            return p;
        }

        private static Packet HandlePullResponsePacket(JObject json)
        {
            Packet p;
            switch (json["dataType"].ToString().ToLower())
            {
                case "users":
                case "user":
                case "connected_clients":
                    p = new PullUsersResponsePacket(json);
                    break;
                case "measurements":
                    p = new PullResponsePacket<Measurement>(json);
                    break;
                case "user_sessions":
                    p = new PullResponsePacket<SessionData>(json);
                    break;
                default:
                    return null;
                    break;
            }
            return p;
        }

        public abstract JObject ToJsonObject();

        
        public static implicit operator JObject(Packet value)
        {
            return value.ToJsonObject();
        }

        public static implicit operator String(Packet value)
        {
            return value.ToString();
        }
    }
}
