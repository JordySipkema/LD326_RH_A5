using System;
using System.Collections.Generic;

namespace Mallaca.Usertypes
{
    public class Specialist : User
    {
        public override UserType UserType
        {
            get
            {
                return UserType.Specialist;
            }
        }
        public Specialist(int id, string username, string password, string name, DateTime dob, string surname, string gender, int userType)
            : base( id, username, password, name, dob, surname, gender)
        {
            Clients = new List<Client>();
        }

        public Specialist() 
        {
            Clients = new List<Client>();
        }
        public List<Client> Clients { get; set; }
    }
}
