using Newtonsoft.Json.Linq;

namespace Mallaca.Network.Packet.Request
{
    public class SubscribePacket : AuthenticatedPacket
    {
        //Inherited field: CMD, AuthToken
        //Introduced fields: Client, Subscribe (bool)

        //Note: Subscribe is true for subscribing, false for unsubscribing.

        public string Client { get; private set; }
        public bool Subscribe { get; private set; }

        public SubscribePacket(string usernameClient, bool subscribe, string cmd, string authtoken) : base(cmd, authtoken)
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
