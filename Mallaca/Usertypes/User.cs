using System;
using System.Collections.Generic;

namespace Mallaca.Usertypes
{
    public enum UserType
    {
        None = -2, User = -1, Client = 0, Specialist = 1, Administrator = 2, Govenor = 3, Commissioner = 4, HighCommissioner = 5
    }
    public class User
    {

        public int? Id { get; set; }
        public int NonNullId { get
            {
                return Id ?? -1;
            }}
        public string Username { get; set; }
        public String PasswordToBeSaved { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string AuthToken { get; set; }
        public virtual UserType UserType  { get { return UserType.User;  } }
        public string Fullname { get { return Name + " " + Surname; } }
        
        public bool IsClient { get { return UserType == UserType.Client; } }
        public bool IsSpecialist { get { return UserType == UserType.Specialist; } }
        public bool IsAdministrator { get { return UserType == UserType.Administrator; } }

        public User()
        {
        }

        public User(int id, string username, string password, string name, DateTime dob, string surname, string gender)
        {
            Id = id;
            Username = username;
            Name = name;
            DateOfBirth = dob;
            Surname = surname;
            Gender = gender;
            PasswordToBeSaved = password;
        }

        public override int GetHashCode()
        {
            var hash = 13;
            hash = (hash * 7) + UserType.GetHashCode();
            hash = (hash * 7) + Username.GetHashCode();
            return hash;
        }

        public class UserComparer : IEqualityComparer<User>
        {
            public bool Equals(User x, User y)
            {
                return x.Username == y.Username;
            }

            public int GetHashCode(User obj)
            {
                return obj.GetHashCode();
            }
        }

    }
}
