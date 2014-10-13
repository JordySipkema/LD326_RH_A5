using System;
using Newtonsoft.Json.Linq;

namespace Mallaca.Network.Packet
{
    class ChatPacket : AuthenticatedPacket
    {
        public const string cmd = "CHAT";
        public string Message { get; set; }
        public string UsernameDestination { get; set; }

        public ChatPacket(string message, string username, string authtoken) : base(authtoken)
        {
            Message = message;
            UsernameDestination = username;
        }

        public ChatPacket(JObject j) : base(j)
        {
            if(j["CMD"].ToString() != cmd)
                throw new InvalidOperationException("Wrong command type. Expected CHAT.");
            Message = j["message"].ToString();
            UsernameDestination = j["usernameDestination"].ToString();
        }

        public override JObject ToJsonObject()
        {
            JObject j = base.ToJsonObject();
            j.Add(new JProperty("message", Message));
            j.Add(new JProperty("usernameDestination", UsernameDestination));
            return j;
        }
    }
}
