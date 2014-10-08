using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Mallaca.Network.Packet
{
    class PushResponsePacket : ResponseFields
    {
        public const string cmd = "RESP-PUSH";

        public PushResponsePacket()
        { 
        }

        public PushResponsePacket(JObject j) : base(j)
        {
            
        }

        public override JObject ToJsonObject()
        {
            JObject json = base.ToJsonObject();
            json.Add("CMD", cmd);
            return json;
        }
    }
}
