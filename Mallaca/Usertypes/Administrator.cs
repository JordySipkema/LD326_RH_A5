using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mallaca.Usertypes
{
    class Administrator : User
    {
        public Administrator(int id, string username, string password, string name, DateTime dob, string surname, string gender, int userType)
            : base( id, username, password, name, dob, surname, gender)
        {
            
        }

        public Administrator() 
        {
        }

        public override UserType UserType
        {
            get
            {
                return UserType.Administrator;
            }
        }
    }
}
