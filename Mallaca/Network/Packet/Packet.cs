using System.Text;
using Newtonsoft.Json.Linq;
using System;

namespace Mallaca.Network.Packet
{
    public abstract class Packet
    {        
        protected Packet()
        { 
        
        }

        
        public static int getLengthOfPacket(string buffer)
        {
            if (buffer.Length < 4) return -1;
            //Continue means: if _totalBuffer.Lenght < 4, DO NOT PROCEED
            return int.Parse(buffer.Substring(0, 4));
        }

        public static int getLengthOfPacket(byte[] buffer)
        {
            if (buffer.Length < 4) return -1;

            int t = BitConverter.ToInt32(buffer, 0);
            
            return t;
        }

        /// <summary>
        ///  Tries to retrieve exactly one packet as a JSON object from a string.
        /// </summary>
        public static JObject RetrieveJSON(int packetSize, ref string buffer)
        {

            if (buffer.Length < packetSize + 4) return null;
            //Continue means: if statement == true, DO NOT PROCEED

            var jsonData = buffer.Substring(4, packetSize);
            buffer = buffer.Remove(0, packetSize + 4);
            return JObject.Parse(jsonData);
        }

        public static Packet RetrievePacket(int packetSize, ref string buffer)
        {

            if (buffer.Length < packetSize + 4) return null;
            //Continue means: if statement == true, DO NOT PROCEED


            var jsonData = buffer.Substring(4, packetSize);
            buffer = buffer.Remove(0, packetSize + 4);
            //Console.WriteLine(jsonData);

            JObject json = JObject.Parse(jsonData);
            Packet p;
            switch(json["CMD"].ToString().ToUpper())
            {
                case LoginPacket.cmd:
                    p = new LoginPacket(json["Username"].ToString(), json["passowrd"].ToString());
                    break;

                case LoginResponsePacket.cmd:

                    p = new LoginResponsePacket(json);
                    break;

                case PushMeasurementsPacket.cmd:
                    p = new PushMeasurementsPacket(json);
                    break;
                case PushMeasurementsPacket.serverCmd:
                    goto case PushMeasurementsPacket.cmd;
                    break;


                default:
                    p = null;
                    break;
            }

            return p;
        }

        public abstract JObject ToJsonObject();
    }
}
