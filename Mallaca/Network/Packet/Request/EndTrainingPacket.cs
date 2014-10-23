using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mallaca.Network.Packet.Request
{
    public class EndTrainingPacket : AuthenticatedPacket
    {
        public const string cmd = "ENDTRAINING";

        public EndTrainingPacket(string auth) : base(cmd, auth)
        {
            
        }
    }
}
