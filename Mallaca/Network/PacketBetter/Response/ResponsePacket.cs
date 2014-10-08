using System.Runtime.InteropServices;
using Newtonsoft.Json.Linq;

namespace Mallaca.Network.PacketBetter.Response
{
    public class ResponsePacket : Packet
    {
        public string Status { get; set; }
        public string Description { get; set; }
        // ReSharper disable once InconsistentNaming
        public string CMD { get; set; }

        public ResponsePacket()
        {
            CMD = "Response";
        }

        public ResponsePacket(string status, string description, string cmd)
        {
            Status = status;
            Description = description;
            CMD = cmd;
        }

        public override JObject ToJsonObject()
        {
            return new JObject(
                    new JProperty("CMD", CMD),
                    new JProperty("STATUS", Status),
                    new JProperty("DESCRIPTION", Description)
                    );
        }

        public override string ToString()
        {
            return ToJsonObject().ToString();
        }
    }
}
