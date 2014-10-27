using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mallaca.Usertypes;
using Newtonsoft.Json.Linq;

namespace Mallaca.Network.Packet.Response
{
    public class DataFromClientPacket<T> : PullResponsePacket<T>
    {
        public int ClientId { get; private set; }
        public const string DefCmd = "DFCLIENT"; 
        public DataFromClientPacket(List<T> lsit, string dataType, int clientId)
            : base(lsit, dataType, DefCmd)
        {
            ClientId = clientId;
        }

        public DataFromClientPacket(JObject json) : base(json)
        {
            JToken clientToken;
            if (json.TryGetValue("clientid", StringComparison.CurrentCultureIgnoreCase, out clientToken))
            {
                ClientId = (int) clientToken;
            }
        }

        public override JObject ToJsonObject()
        {
            var json = base.ToJsonObject();
            json.Add("clientid", ClientId);
            return json;
        }

        public override string ToString()
        {
            return ToJsonObject().ToString();
        }
    }
}
