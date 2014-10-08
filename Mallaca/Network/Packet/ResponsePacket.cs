using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Mallaca.Network.Packet
{
    public abstract class ResponseFields : Packet
    {


        protected ResponseFields()
        {
            
        }


        protected ResponseFields(JObject json)
        {
            status = json["STATUS"].ToString();
            description = json["DESCRIPTION"].ToString();

        }

        protected ResponseFields(string status, string disc)
        {
            this.status = status;
            this.description = disc;
        }

        public JObject GetJsonObject()
        {
            return new JObject(new JProperty("STATUS", status),
                                new JProperty("DESCRIPTION", description));
        }

        public string status { get; set; }
        public string description { get; set; }
        public string cmd { get; set; }

        public override JObject ToJsonObject()
        {
            return GetJsonObject();
        }
    }

    public class ResponsePacket : ResponseFields
    {
        private string cmd;

        public ResponsePacket(string cmd, string status, string desc)
        {
            description = desc;
            this.status = status;
            this.cmd = cmd;
        }
    }
}
