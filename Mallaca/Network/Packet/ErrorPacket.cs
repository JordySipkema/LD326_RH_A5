using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Mallaca.Network.Packet
{
    public class ErrorPacket : Packet
    {
        private Statuscode.Status _status;

        public ErrorPacket(Statuscode.Status status)
        {
            _status = status;
        }

        public override string ToString()
        {
            return ToJsonObject().ToString();
        }

        public override JObject ToJsonObject()
        {
             return new JObject(
                        new JProperty("STATUS", Statuscode.GetCode(_status)),
                        new JProperty("DESC", Statuscode.GetDescription(_status))
                        );
        }

    }
}
