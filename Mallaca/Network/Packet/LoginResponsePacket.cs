using Newtonsoft.Json.Linq;
using Mallaca.Usertypes;

namespace Mallaca.Network.Packet
{
    public class LoginResponsePacket : ResponseFields
    {
        private const string cmd = "RESP-LOGIN";
        public string authtoken { get; set; }
        public UserType type { get; set; }

        public LoginResponsePacket()
        {
            base.CMD = cmd;
        }

        public LoginResponsePacket(JObject j) : base(j)
        {
            JToken auth;
            if (j.TryGetValue("AUTHTOKEN", out auth))
                authtoken = auth.ToString();

        }

        public LoginResponsePacket(string status, string desc, UserType u, string authToken) : base(status, desc)
        {
            this.authtoken = authToken;
            this.type = u;
        }

        public override string ToString()
        {
            JObject json = base.GetJsonObject();
            json.Add("CMD", cmd);
            if(authtoken != null)
                json.Add("AUTHTOKEN", authtoken);
            
            return json.ToString();
        }

        public override JObject ToJsonObject()
        {
            JObject json = GetJsonObject();
            json.Add("CMD", cmd);
            return null;
        }
    }
}
