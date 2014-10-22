using System;
using System.Net.Configuration;
using Mallaca.Usertypes;
using Newtonsoft.Json.Linq;

namespace Mallaca.Network.Packet.Response
{
    public class LoginResponsePacket : ResponsePacket
    {
        public const string LoginRcmd = "RESP-LOGIN";

        public string AuthToken { get; set; }
        public User User;

        #region Constructors
        public LoginResponsePacket(Statuscode.Status status, String authtoken, User u)
            : base(status, LoginRcmd)
        {
            Initialize(authtoken, u);
        }

        public LoginResponsePacket(String status, String description, User u, String authtoken) 
            : base(status, description, LoginRcmd)
        {
            Initialize(authtoken, u);
        }

        public LoginResponsePacket(JObject json) : base(json)
        {
            if(json["CMD"].ToString() != LoginRcmd)
                throw new InvalidOperationException("Wrong command type.");

            JToken token;
            JToken user;
            json.TryGetValue("User", out user);
            if (user != null)
            {
                int type = (int) user.Value<int>("UserType");
                if (type == 0)
                    User = user.ToObject<Client>();
                else if (type == 1)
                    User = user.ToObject<Specialist>();
                else if (type == 2)
                    User = user.ToObject<Administrator>();
                else if (type == 0)
                    User = user.ToObject<User>();
            }



            AuthToken = json.TryGetValue("AUTHTOKEN", out token) ? token.ToString() : null;
            string test = "";
        }
        #endregion

        #region Initializers
        private void Initialize(String authtoken, User user)
        {
            User = user;
            AuthToken = authtoken;
            User = user;
        }
        #endregion

        public override JObject ToJsonObject()
        {
            var returnJson = base.ToJsonObject();
            returnJson.Add("AUTHTOKEN", AuthToken);
            returnJson.Add("User", JObject.FromObject(User));
            return returnJson;

        }

        public override string ToString()
        {
            return ToJsonObject().ToString();
        }
    }
}
