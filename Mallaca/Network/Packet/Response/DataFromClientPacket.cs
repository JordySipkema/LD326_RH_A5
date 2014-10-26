using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Mallaca.Network.Packet.Response
{
    public class DataFromClientPacket<T> : PullResponsePacket<T>
    {
        public int ClientId { get; private set; }
        public const string dCmd = "HERESAHOTPAPAYA"; 
        public DataFromClientPacket(List<T> lsit, string dataType, int clientId)
            : base(lsit, dataType, dCmd)
        {
            ClientId = clientId;
        }

        public DataFromClientPacket(JObject json) : base(json)
        {
            ClientId = int.Parse(json["clientid"].ToString());
        }

        public override JObject ToJsonObject()
        {
            JObject json = base.ToJsonObject();
            json.Add(new JProperty("clientid"));
            return json;
        }

        public override string ToString()
        {
            return ToJsonObject().ToString();
        }
    }
}
