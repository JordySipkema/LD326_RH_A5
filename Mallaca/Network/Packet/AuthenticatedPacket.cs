using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Mallaca.Network.Packet
{
    public class AuthenticatedPacket : Packet
    {
        public string AuthToken { get; private set; }

        public override JObject ToJsonObject()
        {
            return new JObject(new JProperty("authToken", AuthToken));
        }
    }
}
