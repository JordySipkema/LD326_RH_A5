using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Mallaca.Network.Packet.Response
{
    public class PullResponsePacket<T> : ResponsePacket
    {
        public const string DefCmd = "RESP-PULL";
        public string DataType { get; private set; }
        public List<T> List { get; set; }

        public PullResponsePacket(List<T> lsit, string datatype, string cmd = DefCmd)
            : base(Statuscode.Status.Ok, cmd)
        {
            DataType = datatype;
            List = lsit;
        }

        public PullResponsePacket(string cmd = DefCmd) : base(Statuscode.Status.Ok, cmd)
        {
            
        }

        public PullResponsePacket(JObject json, bool dealWithContents = true) : base (json)
        {
            DataType = json["dataType"].ToString().ToLower();
            if (!dealWithContents)
                return;
            List = new List<T>();
            foreach (var token in json["data"].Children())
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
            json.Add("dataType", DataType);
            return json;
        }
    }
}
