using System;
using Newtonsoft.Json.Linq;

namespace Mallaca.Network.Packet.Request
{
    public class LoginPacket : RequestPacket
    {
        //Inherited fields: CMD
        //Introduced fields: Username, Password (hash)

        private const string Cmd = "LOGIN";

        public String Username { get; private set; }
        public String Passhash { get; private set; }

        public LoginPacket(string username, string passhash)
            : base(Cmd)
        {
            Initialize(username, passhash);
        }

        private void Initialize(string user, string passhash)
        {
            Username = user;
            Passhash = passhash;
        }

        public override JObject ToJsonObject()
        {
            var json = base.ToJsonObject();
            json.Add("username", Username);
            json.Add("password", Passhash);
            return json;
        }

        public override string ToString()
        {
            return ToJsonObject().ToString();
        }
    }
}
