using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mallaca;
using Mallaca.Network.Packet;
using Mallaca.Usertypes;
using Newtonsoft.Json.Linq;
using Xunit;

namespace UnitTests
{
    class Packets
    {
        private DBConnect db;
        public Packets()
        {
             db = new DBConnect();
        }
        public void UsersPacketToJsonAndBackToPacket()
        {
            
            //List<User> users = db.GetAllUsers();
            //users.RemoveRange(10, users.Count - 10);
            //var p = new ListUsersPacket(users);

            //var newPacket = new ListUsersPacket(JObject.Parse(p.ToString()));

            //Assert.True(newPacket.List.Count == 10);
        }
    }
}
