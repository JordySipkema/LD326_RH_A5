using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mallaca.Network.PacketBetter.Request
{
    public class ListPacket : AuthenticatedPacket
    {
        private ListPacket(string cmd, string authtoken) : base(cmd, authtoken)
        {
//TODO: CREATE THIS CLASS
            //TODO: DERIVE: ListUsers, ListMeasurements
        }
    }
}
