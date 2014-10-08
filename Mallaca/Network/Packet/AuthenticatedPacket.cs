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
        public string AuthToken { get; protected set; }

        public AuthenticatedPacket(JObject j)
        {
            JToken auth;
            if (j.TryGetValue("authToken", out auth))
                AuthToken = auth.ToString();
            else
            {
                AuthToken = null;
            }
        }

        public AuthenticatedPacket(string s)
        {
            AuthToken = s;
        }

        public AuthenticatedPacket()
        {
            AuthToken = null;
        }

        public override JObject ToJsonObject()
        {
            if(AuthToken != null)
                return new JObject(new JProperty("authToken", AuthToken));
            else
            {
                return new JObject();
            }
        }
    }
}
