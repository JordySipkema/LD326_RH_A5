using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Mallaca.Network.Packet
{
    public class ListUsersPacket : AuthenticatedPacket
    {
        public const string Cmd = "LSU";
        public ListUsersPacket()
        {

        }

        public override JObject ToJsonObject()
        {
            JObject json = base.ToJsonObject();
            json.Add("CMD", Cmd);
            return json;
        }

        public override string ToString()
        {
            return ToJsonObject().ToString();
        }
    }
}
