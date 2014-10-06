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
    public class PushMeasurementsPacket : AuthenticatedPacket
    {
        public const string cmd = "PUSH";
        public const string serverCmd = "RESP-LSM";
        public List<Measurement> Measurements { get; set; }
        private bool clientToServer;

        public PushMeasurementsPacket(bool clientToServer)
        {
            this.clientToServer = clientToServer;
            Measurements = new List<Measurement>();
        }

        public PushMeasurementsPacket(JObject json)
        {
            Measurements = new List<Measurement>();
            bool client = (json["CMD"].ToString() != cmd);
            bool server = (json["CMD"].ToString() != serverCmd);
            if (!client && !server ) 
                throw new InvalidOperationException("Invalid CMD type.");


            foreach (JToken token in json["measurements"].Children())
            {
                Measurements.Add(token.ToObject<Measurement>());
            }
        }

        public override JObject ToJsonObject()
        {
            JObject json;
            if (!clientToServer)
            {
                json = base.ToJsonObject();
                json.Add("CMD", cmd);
            }
            else
            {               
                json = new JObject();
                json.Add("CMD", serverCmd);
            }

            json.Add("count", Measurements.Count);
            JArray jsonArray = new JArray();

            JArray j = JArray.FromObject(Measurements);
            json.Add("measurements", j);
            

            
            return json;
        }

        public override string ToString()
        {
            return ToJsonObject().ToString();
        }
    }
}
