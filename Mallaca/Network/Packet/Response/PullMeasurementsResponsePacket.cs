using System;
using System.Collections.Generic;
using Mallaca.Usertypes;
using Newtonsoft.Json.Linq;

namespace Mallaca.Network.Packet.Response
{
    public class PullMeasurementsResponsePacket : PullResponsePacket<Measurement>
    {
        public PullMeasurementsResponsePacket()
        {

        }

        public PullMeasurementsResponsePacket(List<Measurement> list, string dataType)
            : base(list, dataType)
        {

        }

        public PullMeasurementsResponsePacket(JObject json)
            : base(json, false)
        {
            List = new List<Measurement>();
            foreach (var token in json["data"].Children())
            {
                int type;
                var sType = token["UserType"].ToString();


                if (!(Int32.TryParse(sType, out type)))
                    continue;

                List.Add(token.ToObject<Measurement>());
            }
        }
    }
}
