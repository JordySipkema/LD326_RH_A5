using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Mallaca.Network.Packet.Response
{
    public class PullResponsePacket<T> : ResponsePacket
    {
        public const string Cmd = "RESP-PULL";
        public string dataType { get; protected set; }
        public List<T> List { get; set; }

        public PullResponsePacket(List<T> lsit) : base(Statuscode.Status.Ok, Cmd)
        {
            List = lsit;
        }

        public PullResponsePacket() : base(Statuscode.Status.Ok, Cmd)
        {
            
        }

        public PullResponsePacket(JObject json)
        {
            List = new List<T>();
            foreach (JToken token in json["data"].Children())
            {
                List.Add(token.ToObject<T>());
            }
        }

        public override string ToString()
        {
            return ToJsonObject().ToString();
        }

        public override JObject ToJsonObject()
        {
            JObject json =  base.ToJsonObject();
            json.Add("data", JArray.FromObject(List));
            json.Add("dataType", dataType);
            return json;
        }
    }
}
