using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Mallaca;

namespace RH_Server.Classes
{
    public static class Authentication
    {
        private static readonly List<User> AuthUsers = new List<User>(); 

        public static Boolean Authenticate(String user, String passhash)
        {
            //check that user and passhash are valid.

            //Creating the hash
            //1. Prepare the string for hashing (user-passhash-milliseconds_since_epoch)
            var millis = DateTime.Now.ToUniversalTime().Subtract(
                new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                ).TotalMilliseconds;
            var aboutToHash = String.Format("{0}-{1}-{2}", user, passhash, millis);

            //2. Hash the string.
           var hash = Hashing.CreateSHA256(aboutToHash);

            Console.WriteLine(hash);

            return true;
        }
    }
}
