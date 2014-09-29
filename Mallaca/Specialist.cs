using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mallaca
{
    class Specialist : User
    {

        public Specialist(int id, string username, string password, string name, DateTime dob, string surname, string gender, int userType)
            : base( id, username, password, name, dob, surname, gender, userType)
        {
            Clients = new List<User>();
        }

        public Specialist() 
        {
            Clients = new List<User>();
        }
        public List<User> Clients { get; set; }

        
    }
}
