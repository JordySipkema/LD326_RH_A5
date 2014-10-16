using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            return JObject.Parse(Encoding.UTF8.GetString(GetPacketBytes(packetSize, ref buffer).ToArray()));
        }

        //TODO: BACK TO PRIVATE
        public static List<byte> GetPacketBytes(int packetSize, ref List<byte> buffer)
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
        {   Packet p = null;
            JObject json = RetrieveJson(packetSize, ref buffer);

            if (json == null)
                return null;
            
            switch (json["CMD"].ToString().ToUpper())
            {
                case LoginResponsePacket.LoginRcmd:
                    p = new LoginResponsePacket(json);
                    break;


                case PullResponsePacket<string>.Cmd: 
                switch (json["dataType"].ToString())
                {
                    case "users":
                    case "user":
                    case "connected_clients":
                        p = new PullUsersResponsePacket(json);
                        break;
                    case "measurements":
                        return new PullResponsePacket<Measurement>(json);
                        break;
                    case "user_sessions":
                        return new PullResponsePacket<SessionData>(json);
                        break;


                }
                break;
            }
                                

            return p;
        }

        public abstract JObject ToJsonObject();
    }
}
