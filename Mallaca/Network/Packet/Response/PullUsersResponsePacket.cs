using System;
using System.Collections.Generic;
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
            foreach (var token in json["data"].Children())
            {
                int type;
                var sType = token["UserType"].ToString();


                if (!(Int32.TryParse(sType, out type)))
                    continue;

                switch (type)
                {
                    case (int)UserType.Administrator:
                        List.Add(token.ToObject<Administrator>());
                        break;
                    case (int)UserType.Specialist:
                        List.Add(token.ToObject<Specialist>());
                        break;
                    case (int)UserType.Client:
                        List.Add(token.ToObject<Client>());
                        break;
                    default:
                        List.Add(token.ToObject<User>());
                        break;
                }
            }
        }
    }
}
