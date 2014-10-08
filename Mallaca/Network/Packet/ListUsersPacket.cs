using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mallaca.Usertypes;
using Newtonsoft.Json.Linq;

namespace Mallaca.Network.Packet
{
    public class ListUsersPacket : ListPacket<User>
    {
        public const string Cmd = "RESP-LSU";
        public const string fieldName = "users";
        public ListUsersPacket(string authToken) : base(authToken)
        {
        }

        public ListUsersPacket(List<User> users)
            : base(users, fieldName)
        {
        }

        public ListUsersPacket(JObject j) : base(j,fieldName)
        {
            List = new List<User>();
            foreach (JToken token in j[fieldName].Children())
            {
                int type;
                string sType = token["UserType"].ToString();


                if(!(Int32.TryParse(sType, out type)))
                    continue;

                if(type == (int)UserType.Administrator || type == (int) UserType.Specialist)
                    List.Add(token.ToObject<Specialist>());
                else if (type == (int) UserType.Client)
                    List.Add(token.ToObject<Client>());
                else
                    List.Add(token.ToObject<User>());
            }
        }

        public ListUsersPacket() : base("")
        {
        }

        public override JObject ToJsonObject()
        {
            JObject json = base.ToJsonObject();
            json.Add("CMD", Cmd);
            return json;
        }

        public override string ToString()
        {
            return ToJsonObject().ToString();
        }
    }
}
