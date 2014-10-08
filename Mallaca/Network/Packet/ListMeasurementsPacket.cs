using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Mallaca.Network.Packet
{
    public class ListMeasurementsPacket : AuthenticatedPacket
    {
        public int SessionId { get; set; }
        public string Username { get; set; }
        public int UserId { get; set; }
        public const string Cmd = "LSM";

        public ListMeasurementsPacket()
        {
            SessionId = -1;
            UserId = -1;
        }

        public ListMeasurementsPacket(int userId)
        {
            SessionId = -1;
            this.UserId = userId;
        }

        public ListMeasurementsPacket(int userId, int sessionId)
        {
            this.SessionId = sessionId;
            this.UserId = userId;
        }

        public override JObject ToJsonObject()
        {
            JObject json = base.ToJsonObject();
            json.Add(new JProperty("CMD", Cmd));
            if(UserId != -1)
                json.Add("userID", UserId);
            else if (Username != null)
                json.Add("Username", Username);
            else
                throw new InvalidOperationException("Neither user id and usename have a valid value other than null.");

            if(SessionId != -1)
                json.Add("sessionID", SessionId);

            return json;
        }

        public override string ToString()
        {
            return ToJsonObject().ToString();
        }
    }
}
