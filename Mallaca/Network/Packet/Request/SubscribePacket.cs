using Newtonsoft.Json.Linq;

namespace Mallaca.Network.Packet.Request
{
    public class SubscribePacket : AuthenticatedPacket
    {
        //Inherited field: CMD, AuthToken
        //Introduced fields: Client, Subscribe (bool)

        //Note: Subscribe is true for subscribing, false for unsubscribing.

        public const string DefCmd = "SUBSCR";

        public string Client { get; private set; }
        public bool Subscribe { get; private set; }

        public static SubscribePacket GetSubscribePacket(JObject json)
        {
            if ((string) json["CMD"] != DefCmd) return null;

            var client = (string) json["Client"];
            var subscribe = (bool) json["Subscribe"];
            var authtoken = (string) json["AUTHTOKEN"];

            return new SubscribePacket(client, subscribe, authtoken);
        }

        public SubscribePacket(string usernameClient, bool subscribe, string authtoken) : base(DefCmd, authtoken)
        {
            Initialize(usernameClient, subscribe);
        }

        private void Initialize(string usernameClient, bool subscribe)
        {
            Client = usernameClient;
            Subscribe = subscribe;
        }

        public override JObject ToJsonObject()
        {
            var json = base.ToJsonObject();
            json.Add("Client", Client);
            json.Add("Subscribe", Subscribe);
            return json;
        }

        public override string ToString()
        {
            return ToJsonObject().ToString();
        }
    }
}
