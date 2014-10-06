using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Mallaca.Network.Packet
{
    public class ResponsePacket : Packet
    {
        public ResponsePacket()
        {
            
        }

        public ResponsePacket(string status, string disc)
        {
            this.status = status;
            this.description = disc;
        }

        public JObject GetJsonObject()
        {
            return new JObject(new JProperty("status", status),
                                new JProperty("description", description));
        }

        public string status { get; set; }
        public string description { get; set; }

        public override JObject ToJsonObject()
        {
            return GetJsonObject();
        }
    }
}
