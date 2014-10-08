using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Mallaca.Usertypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mallaca.Network.Packet
{
    public class PushMeasurementsPacket : ListPacket<Measurement>
    {
        public const string cmd = "PUSH";
        public const string serverCmd = "RESP-LSM";
        public const string listField = "measurements";
        private bool clientToServer;

        public PushMeasurementsPacket() :  base(listField)
        {
            this.clientToServer = false;
        }

        public PushMeasurementsPacket(string authtoken) : base(authtoken, listField)
        {
            this.AuthToken = authtoken;
            this.clientToServer = true;
        }

        public PushMeasurementsPacket(JObject json) : base(listField)
        {
            bool client = (json["CMD"].ToString() != cmd);
            bool server = (json["CMD"].ToString() != serverCmd);
            if (!client && !server ) 
                throw new InvalidOperationException("Invalid CMD type.");
        }

        public override JObject ToJsonObject()
        {
            JObject json = base.ToJsonObject();
            json.Add("CMD", clientToServer ? cmd : serverCmd);
            return json;
        }

        public override string ToString()
        {
            return ToJsonObject().ToString();
        }
    }
}
