using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Mallaca.Network.PacketBetter.Response
{
    public class LoginResponsePacket : ResponsePacket
    {
        private const string LoginRcmd = "RESP-LOGIN";

        public string AuthToken { get; set; }

        public LoginResponsePacket()
        {
            CMD = LoginRcmd;
        }

        public LoginResponsePacket(String status, String description, String authtoken) 
            : base(status, description, LoginRcmd)
        {
            AuthToken = authtoken;
        }

        public override JObject ToJsonObject()
        {
            var returnJson = base.ToJsonObject();
            returnJson.Add("AUTHTOKEN", AuthToken);

            return returnJson;

        }

        public override string ToString()
        {
            return ToJsonObject().ToString();
        }
    }
}
