using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mallaca.Network
{
    public class Packet
    {
        public static int getLengthOfPacket(string buffer)
        {
            if (buffer.Length < 4) return -1;
            //Continue means: if _totalBuffer.Lenght < 4, DO NOT PROCEED

            return int.Parse(buffer.Substring(0, 4));
        }

        /// <summary>
        ///  Tries to retrieve exactly one packet as a JSON object from a string.
        /// </summary>
        public static JObject RetrieveJSONPacket(int packetSize, string buffer)
        {

            if (buffer.Length < packetSize + 4) return null;
            //Continue means: if statement == true, DO NOT PROCEED

            var jsonData = buffer.Substring(4, packetSize);
            //Console.WriteLine(jsonData);

            return JObject.Parse(jsonData);
        }
    }
}
