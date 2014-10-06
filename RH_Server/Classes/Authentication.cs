using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using Mallaca;
using Mallaca.Usertypes;

namespace RH_Server.Classes
{
    public static class Authentication
    {
        //ConcurrentDictionary to enhance thread safety.
        private static readonly ConcurrentDictionary<User, Stream> AuthUsers = new ConcurrentDictionary<User, Stream>();

        public static Boolean Authenticate(String user, String passhash, Stream socketStream)
        {
            //check that user and passhash are valid.
            var database = new DBConnect();
            var tuple = database.ValidateUser(user, passhash, true);

            if (!tuple.Item1) // if the tuple.Item1 equals false, return false and exit this method.
                return false;

            //Creating the hash
            //1. Prepare the string for hashing (user-passhash-milliseconds_since_epoch)
            var millis = DateTime.Now.ToUniversalTime().Subtract(
                new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                ).TotalMilliseconds;
            var aboutToHash = String.Format("{0}-{1}-{2}", user, passhash, millis);

            //2. Hash the string.
            var hash = Hashing.CreateSHA256(aboutToHash);

            //3. Create the user :D
            var u = new User {Name = user, PasswordToBeSaved = passhash, AuthToken = hash};

            //4. Add the user to the AuthUsers class.
            AuthUsers.GetOrAdd(u, socketStream);
            return true;
        }

        public static Boolean Authenticate(String authToken)
        {
            return (AuthUsers.Count(x => x.Key.AuthToken == authToken) == 1);
        }

        public static Stream GetStream(String username)
        {
            return AuthUsers.First(x => x.Key.Username == username).Value;
        }

        public static User GetUser(String username)
        {
            return AuthUsers.First(x => x.Key.Username == username).Key;
        }
    }
}
