namespace Mallaca.Network.Packet.Request
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
