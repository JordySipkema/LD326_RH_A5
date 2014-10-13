using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Mallaca.Network.PacketBetter.Request
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
