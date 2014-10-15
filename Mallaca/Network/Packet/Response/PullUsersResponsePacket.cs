using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mallaca.Network.Packet.Request;
using Mallaca.Usertypes;
using Newtonsoft.Json.Linq;

namespace Mallaca.Network.Packet.Response
{
    public class PullUsersResponsePacket : PullResponsePacket<User>
    {
        public PullUsersResponsePacket()
        {
            
        }

        public PullUsersResponsePacket(List<User> list, string dataType) : base(list, dataType)
        {
            
        }

        public PullUsersResponsePacket(JObject json) : base(json, false)
        {
            List = new List<User>();
            foreach (JToken token in json["data"].Children())
            {
                int type;
                string sType = token["UserType"].ToString();


                if (!(Int32.TryParse(sType, out type)))
                    continue;

                if (type == (int)UserType.Administrator || type == (int)UserType.Specialist)
                    List.Add(token.ToObject<Specialist>());
                else if (type == (int)UserType.Client)
                    List.Add(token.ToObject<Client>());
                else
                    List.Add(token.ToObject<User>());
            }
        }
    }
}
