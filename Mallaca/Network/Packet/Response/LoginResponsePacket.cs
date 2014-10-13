using System;
using Newtonsoft.Json.Linq;

namespace Mallaca.Network.Packet.Response
{
    public class LoginResponsePacket : ResponsePacket
    {
        private const string LoginRcmd = "RESP-LOGIN";

        public string AuthToken { get; set; }

        #region Constructors
        public LoginResponsePacket() : base(LoginRcmd)
        {
            Initialize(String.Empty); //Initialize without an authtoken.
        }

        public LoginResponsePacket(Statuscode.Status status, String authtoken)
            : base(status, LoginRcmd)
        {
            Initialize(authtoken);
        }

        public LoginResponsePacket(String status, String description, String authtoken) 
            : base(status, description, LoginRcmd)
        {
            Initialize(authtoken);
        }
        #endregion

        #region Initializers
        private void Initialize(String authtoken)
        {
            AuthToken = authtoken;
        }
        #endregion

        public override JObject ToJsonObject()
        {
            var returnJson = base.ToJsonObject();
            returnJson.Add("AUTHTOKEN", AuthToken);

            return returnJson;

        }

        public override string ToString()
        {
            return ToJsonObject().ToString();
        }
    }
}
