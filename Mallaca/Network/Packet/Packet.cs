using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Mallaca.Network.Packet
{
    public abstract class Packet
    {
        
        public Packet()
        { 
        
        }

        

        public static int getLengthOfPacket(string buffer)
        {
            if (buffer.Length < 4) return -1;
            //Continue means: if _totalBuffer.Lenght < 4, DO NOT PROCEED

            //return int.Parse(buffer.Substring(0, 4));

            char[] chars = buffer.Substring(0, 4).ToCharArray();
            byte[] bytes = new byte[4];

            for (int i = 0; i < chars.Length; i++)
                bytes[i] = (byte)chars[i];
            
            return BitConverter.ToInt32(bytes,0);
        }

        /// <summary>
        ///  Tries to retrieve exactly one packet as a JSON object from a string.
        /// </summary>
        public static JObject RetrieveJSON(int packetSize, string buffer)
        {

            if (buffer.Length < packetSize + 4) return null;
            //Continue means: if statement == true, DO NOT PROCEED

            var jsonData = buffer.Substring(4, packetSize);
            //Console.WriteLine(jsonData);

            return JObject.Parse(jsonData);
        }

        public static Packet RetrievePacket(int packetSize, ref string buffer)
        {

            if (buffer.Length < packetSize + 4) return null;
            //Continue means: if statement == true, DO NOT PROCEED

            var jsonData = buffer.Substring(4, packetSize);
            //Console.WriteLine(jsonData);

            JObject json = JObject.Parse(jsonData);
            Packet p;
            switch(json["CMD"].ToString())
            {
                case LoginPacket.cmd:
                    p = new LoginPacket(json["username"].ToString(), json["passowrd"].ToString());
                    break;

                default:
                    p = null;
                    break;
            }

            return p;
        }
    }
}
