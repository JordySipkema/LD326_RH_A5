using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mallaca
{
    public  enum UserType
    {
        User = -1, Client = 0, Specialist = 1, Administrator = 2, Govenor = 3, Commissioner = 4, High_Commissioner = 5
    }
    public class User
    {

        public int? Id { get; set; }
        public string Username { get; set; }
        public String PasswordToBeSaved { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public virtual UserType UserType  { get { return UserType.User;  } }

        

        public bool IsClient { get { return UserType == UserType.Client; } }
        public bool IsSpecialist { get { return UserType == UserType.Specialist; } }
        public bool IsAdministrator { get { return UserType == UserType.Administrator; } }

        public User() 
        { 
            
        }

        public User(int id, string username, string password, string name, DateTime dob, string surname, string gender)
        {
            this.Id = id;
            this.Username = username;
            this.Name = name;
            this.DateOfBirth = dob;
            this.Surname = surname;
            this.Gender = gender;
            this.PasswordToBeSaved = password;
        }


    }
}
