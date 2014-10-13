
namespace Mallaca.Network.Packet.Request
{
    public class LoginPacket : RequestPacket
    {
        //Inherited fields: CMD
        //Introduced fields: -

        private const string DefCmd = "LOGIN";

        public LoginPacket()
            : base(DefCmd)
        {

        }

    }
}
