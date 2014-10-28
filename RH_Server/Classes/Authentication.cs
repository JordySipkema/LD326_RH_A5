using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Mallaca;
using Mallaca.Usertypes;
using RH_Server.Server;

namespace RH_Server.Classes
{
    internal static class Authentication
    {
        //ConcurrentDictionary to enhance thread safety.
        private static readonly ConcurrentDictionary<User, ClientHandler> AuthUsers = new ConcurrentDictionary<User, ClientHandler>();

        public static Boolean Authenticate(String username, String passhash, ClientHandler handler)
        {
            //check that user and passhash are valid.
            var database = new DBConnect();
            var tuple = database.ValidateUser(username, passhash, true);

            if (!tuple.Item1) // if the tuple.Item1 equals false, return false and exit this method.
                return false;

            //Creating the hash (AuthToken)
            //1. Prepare the string for hashing (user-passhash-milliseconds_since_epoch)
            var millis = DateTime.Now.ToUniversalTime().Subtract(
                new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                ).TotalMilliseconds;
            var aboutToHash = String.Format("{0}-{1}-{2}", username, passhash, millis);

            //2. Hash the string.
            var hash = Hashing.CreateSHA256(aboutToHash);

            //3. Create the user :D
            var user = database.getUser(username);

            //if user == null, exit this method!
            if (user == null) return false;

            user.AuthToken = hash;

            //4. Remove the user if existing in the list.
            var searchQuery =
                from kvPair in AuthUsers
                where kvPair.Key.Username == username
                select kvPair.Key;

            // Above query (searchQuery) is exactly the same as:
            // var search2 = AuthUsers
            //     .Where(kvPair => kvPair.Key.Username == username)
            //     .Select(kvPair => kvPair.Key); 

            foreach (var key in searchQuery)
            {
                ClientHandler tempClientHandler;
                AuthUsers.TryRemove(key, out tempClientHandler);
            }

            //5. Add the user to the AuthUsers class.
            AuthUsers.GetOrAdd(user, handler);

            return true;
        }

        public static List<ClientHandler> GetAllUsers()
        {
            return AuthUsers.Values.ToList();
        }



        public static Boolean Authenticate(String authToken)
        {
            return (AuthUsers.Count(x => x.Key.AuthToken == authToken) == 1);
        }
        public static void ReleaseAuthToken(String authToken)
        {
            var users = AuthUsers.Keys.Where(user => user.AuthToken == authToken);
            foreach (var user in users)
            {
                ClientHandler s;
                AuthUsers.TryRemove(user, out s);
            }
        }

        public static ClientHandler GetStream(User u)
        {
            return GetStream(u.Username);
        }

        public static ClientHandler GetStream(String username)
        {
            //return AuthUsers.First(x => x.Key.Username == username).Value;
            return AuthUsers.Where(user => user.Key.Username == username).Select(user => user.Value).FirstOrDefault();
        }

        public static User GetUser(String username)
        {
            return AuthUsers.Where(user => user.Key.Username == username).Select(user => user.Key).FirstOrDefault();
        }

        public static User GetUserByAuthToken(string authtoken)
        {
            return AuthUsers.Where(user => user.Key.AuthToken == authtoken).Select(user => user.Key).FirstOrDefault();
        }

        public static List<User> GetClients()
        {
            //var z = AuthUsers.Keys.ToList().Where(x => x.IsClient).ToList();
            //var u = new Client {Name = "Henk", Username = "Henk2"};
            //z.Add(u);
            //return z;
            return AuthUsers.Keys.ToList().Where(x => x.IsClient).ToList();
        }
    }
}
