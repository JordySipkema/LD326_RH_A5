﻿using Newtonsoft.Json.Linq;

namespace Mallaca.Network.Packet
{
    public abstract class Packet
    {
        protected Packet(string type)
        { 
        
        }

        

        public static int getLengthOfPacket(string buffer)
        {
            if (buffer.Length < 4) return -1;
            //Continue means: if _totalBuffer.Lenght < 4, DO NOT PROCEED

            return int.Parse(buffer.Substring(0, 4));
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

        public static Packet RetrievePacket(int packetSize, string buffer)
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
