using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Mallaca.Network.Packet
{
    class PushResponsePacket : ResponsePacket
    {
        public const string cmd = "RESP-PUSH";

        public override JObject ToJsonObject()
        {
            JObject json = base.ToJsonObject();
            json.Add("CMD", cmd);
            return json;
        }
    }
}
