using System;
using Newtonsoft.Json.Linq;

namespace Mallaca.Network.Packet.Request
{
    public class ChatPacket : AuthenticatedPacket
    {
        //Inherited fields: CMD, AUTHTOKEN
        //Introduced fields: Message, UsernameDestination

        public const string DefCmd = "CHAT";

        public String Message { get; private set; }
        public String UsernameDestination { get; private set; }

        public ChatPacket(string message, string usernameDestination, string authtoken)
            : base(DefCmd, authtoken)
        {
            Initialize(message, usernameDestination);
        }

        private void Initialize(string message, string usernameDestination)
        {
            Message = message;
            UsernameDestination = usernameDestination;
        }

        public ChatPacket(JObject json) : base(json, DefCmd)
        {
            Initialize(json["Message"].ToString() ,json["UsernameDestination"].ToString());    

        }

        public override JObject ToJsonObject()
        {
            var json = base.ToJsonObject();
            json.Add("Message", Message);
            json.Add("UsernameDestination", UsernameDestination);
            return json;
        }

        public override string ToString()
        {
            return ToJsonObject().ToString();
        }
    }
}
