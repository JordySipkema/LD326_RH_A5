using System.Security;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json.Linq;

namespace Mallaca.Network.Packet.Request
{
    public class ListPacket : AuthenticatedPacket
    {
        public const string Cmd = "PULL";
        public string dataType { get; set; }
        public int dataId { get; set; }


        public ListPacket(string datatype, string authtoken, int id = -1) : base(Cmd, authtoken) // pull packet
        {
            dataType = datatype;
            dataId = id;
        }

        public ListPacket(JObject json) : base(json, Cmd)
        {
            dataType = json["dataType"].ToString();
            dataId = int.Parse(json["dataId"].ToString());
        }

        public override JObject ToJsonObject()
        {
            JObject json = base.ToJsonObject();
            json.Add("dataType", dataType.ToLower());
            if (dataId > 0)
                json.Add("dataId", dataId);
            return json;
        }

        public override string ToString()
        {
            return ToJsonObject().ToString();
        }
    }
}
