using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
namespace Mallaca.Network.Packet
{
    class LoginPacket : Packet
    {
        public LoginPacket(string username, string password) : base(cmd)
        {

        }

        public LoginPacket(JObject j)
            : base(cmd)
        {
            if (j["CMD"].ToString() != cmd)
                throw new InvalidOperationException("Given JSON defines the wrong packet.");
            username = j["username"].ToString();
            password = j["password"].ToString();
        }

        public const string cmd = "LOGIN";
        public string username { get; set; }
        public string password { get; set; }

        public override string ToString()
        {
            return new JObject(
                new JProperty("CMD", "LOGIN"),
                new JProperty("username", username),
                new JProperty("password", password)).ToString();
        }
    }
}
