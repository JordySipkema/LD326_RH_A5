using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mallaca.Network.PacketBetter.Response
{
    public class PushResponsePacket : ResponsePacket
    {
        private const string PushRcmd = "RESP-PUSH";

        #region Constructors
        //The contstuctors are empty
        //PushResponsePacket is a plain ResponsePacket, only the "CMD" has changed.
        public PushResponsePacket() : base(PushRcmd)
        {
        }

        public PushResponsePacket(Statuscode.Status status)
            : base(status, PushRcmd)
        {
        }

        public PushResponsePacket(string status, string description) 
            : base(status, description, PushRcmd)
        {
        }
        #endregion

        //No initializers (because there are no new fields introduced)

        //No overridden ToString/ToJsonObject methods (no new fields)



    }
}
