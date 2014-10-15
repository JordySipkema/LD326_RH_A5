using System;
using Newtonsoft.Json.Linq;

namespace Mallaca.Network.Packet.Request
{
    public class AuthenticatedPacket : RequestPacket
    {
        //Inherited field: CMD
        //Introduced fields: AuthToken

        public String AuthToken { get; private set; }
        protected AuthenticatedPacket(string cmd, string authtoken) : base(cmd)
        {
            Initialize(authtoken);
        }

        protected AuthenticatedPacket(JObject json, string cmd) : base(cmd)
        {
            Initialize(json["AUTHTOKEN"].ToString());
        }

        private void Initialize(string authtoken)
        {
            AuthToken = authtoken;
        }

        public override JObject ToJsonObject()
        {
            var x = base.ToJsonObject();
            x.Add("AUTHTOKEN", AuthToken);
            return x;
        }

        public override string ToString()
        {
            return ToJsonObject().ToString();
        }
    }
}
