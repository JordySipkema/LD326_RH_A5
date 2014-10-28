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
        public bool IsBroadcast { get; set; }

        public ChatPacket(string message, string usernameDestination, string authtoken, bool broadcast = false)
            : base(DefCmd, authtoken)
        {
            Initialize(message, usernameDestination, broadcast);
        }

        private void Initialize(string message, string usernameDestination, bool b )
        {
            Message = message;
            UsernameDestination = usernameDestination;
            IsBroadcast = b;
        }

        public ChatPacket(JObject json) : base(json, DefCmd)
        {
            JToken b;
            bool br = json.TryGetValue("isbroadcast", StringComparison.InvariantCultureIgnoreCase, out b) && b.ToObject<bool>();

            Initialize(json["Message"].ToString(), json["UsernameDestination"].ToString(), br);    

        }

        public override JObject ToJsonObject()
        {
            var json = base.ToJsonObject();
            json.Add("Message", Message);
            json.Add("UsernameDestination", UsernameDestination);
            json.Add("isbroadcast", IsBroadcast);
            return json;
        }

        public override string ToString()
        {
            return ToJsonObject().ToString();
        }
    }
}
