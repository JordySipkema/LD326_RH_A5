using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Mallaca.Network.Packet.Request
{
    public class LSMPacket : ListPacket
    {
        public int sessionID { get; set; }

        public LSMPacket(int userId, int sessionID, string authtoken) : base("measurements", authtoken, userId)
        {
            this.sessionID = sessionID;
        }

        public LSMPacket(JObject json) : base(json)
        {
            sessionID = int.Parse(json["sessionID"].ToString());
        }

        public override JObject ToJsonObject()
        {
            JObject json = base.ToJsonObject();
            json.Add("sessionID", sessionID);
            return json;
        }

        public override string ToString()
        {
            return ToJsonObject().ToString();
        }
    }
}
