using System;
using Newtonsoft.Json.Linq;

namespace Mallaca.Network.Packet.Response
{
    public class LoginResponsePacket : ResponsePacket
    {
        private const string LoginRcmd = "RESP-LOGIN";

        public string Usertype { get; set; }
        public string AuthToken { get; set; }

        #region Constructors
        public LoginResponsePacket(Statuscode.Status status, String usertype, String authtoken)
            : base(status, LoginRcmd)
        {
            Initialize(usertype, authtoken);
        }

        public LoginResponsePacket(String status, String description, String usertype, String authtoken) 
            : base(status, description, LoginRcmd)
        {
            Initialize(usertype, authtoken);
        }
        #endregion

        #region Initializers
        private void Initialize(String usertype, String authtoken)
        {
            Usertype = usertype;
            AuthToken = authtoken;
        }
        #endregion

        public override JObject ToJsonObject()
        {
            var returnJson = base.ToJsonObject();
            returnJson.Add("USERTYPE", Usertype);
            returnJson.Add("AUTHTOKEN", AuthToken);

            return returnJson;

        }

        public override string ToString()
        {
            return ToJsonObject().ToString();
        }
    }
}
