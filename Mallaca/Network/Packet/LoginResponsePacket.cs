using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Mallaca.Network.Packet
{
    public class LoginResponsePacket : ResponsePacket
    {
        public const string cmd = "RESP-LOGIN";
        public string authtoken { get; set; }

        public LoginResponsePacket()
        {
            
        }

        public LoginResponsePacket(JObject j) : base(j)
        {
            JToken auth;
            if (j.TryGetValue("AUTHTOKEN", out auth))
                authtoken = auth.ToString();

        }

        public LoginResponsePacket(string status, string desc, string authToken) : base(status, desc)
        {
            this.authtoken = authToken;
        }

        public override string ToString()
        {
            JObject json = base.GetJsonObject();
            json.Add("CMD", cmd);
            if(authtoken != null)
                json.Add("AUTHTOKEN", authtoken);
            
            return json.ToString();
        }
    }
}
