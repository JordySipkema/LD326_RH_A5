using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mallaca
{
    public class User
    {

        public int Id { get; set; }
        public string Username { get; set; }
        public String Password { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public int UserType { get; set; }

        public bool IsClient { get { return UserType == 0; } }
        public bool IsSpecialist { get { return UserType == 1; } }
        public bool IsAdministrator { get { return UserType == 2; } }

        public User() 
        { 
        
        }

        public User(int id, string username, string password, string name, DateTime dob, string surname, string gender, int userType)
        {
            this.Id = id;
            this.UserType = userType;
            this.Username = username;
            this.Name = name;
            this.DateOfBirth = dob;
            this.Surname = surname;
            this.Gender = gender;
            this.Password = password;
        }


    }
}
