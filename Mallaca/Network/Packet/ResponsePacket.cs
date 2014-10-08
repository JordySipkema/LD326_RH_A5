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
            Status = json["STATUS"].ToString();
            Description = json["DESCRIPTION"].ToString();

        }

        protected ResponseFields(string status, string disc)
        {
            this.Status = status;
            this.Description = disc;
        }

        public JObject GetJsonObject()
        {
            return new JObject(
                new JProperty("CMD", CMD),
                new JProperty("STATUS", Status),
                new JProperty("DESCRIPTION", Description)
                );
        }

        public string Status { get; set; }
        public string Description { get; set; }
        // ReSharper disable once InconsistentNaming
        public string CMD { get; set; }

        public override JObject ToJsonObject()
        {
            return GetJsonObject();
        }
    }

    public class ResponsePacket : ResponseFields
    {
        private string cmd;

        public ResponsePacket()
        {
            
        }

        public ResponsePacket(string cmd, string status, string desc)
        {
            Description = desc;
            this.Status = status;
            this.cmd = cmd;
        }
    }
}
