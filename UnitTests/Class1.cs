using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Mallaca;
using System.IO;
using MySql.Data.MySqlClient;
using MySql;
using Mallaca.Usertypes;

namespace UnitTests 
{
    public class DBIntegration : IDisposable
    {

        DBConnect db;
        public DBIntegration()
        {
            db = new DBConnect("root", "", "localhost", "Healthcare_test");
            exterminateDB();
            string dbStructureSQL;
            try
            {
                using (StreamReader sr = new StreamReader("deb58589n5_healthcare.mysql"))
                {
                    dbStructureSQL = sr.ReadToEnd();
                    MySqlCommand createDB = new MySqlCommand(dbStructureSQL, db.Connection);
                    createDB.ExecuteNonQuery();
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, Add(2, 2));
        }

        int Add(int x, int y)
        {
            return x + y;
        }

        [Fact]
        public void saveSpecialistWithClient()
        {
            Specialist c = new Specialist()
            {
                DateOfBirth = DateTime.Now,
                Gender = "M",
                Name = "Richard",
                Surname = "boudewijn",
                PasswordToBeSaved = "dsffafsad", 
                Username = "Boudewijn de Groot"
            };
            
            Client client = new Client()
            {
                Username = "wololololololo"
            };
            int type = (int) c.UserType;

            bool saveClient = db.saveUser(client);
            c.Clients.Add(client);
            bool saveSpecialist = db.saveUser(c);
            Assert.True(saveSpecialist);            
        }

        [Fact]
        public void saveClient()
        {
            Client c = new Client()
            {
                Username = "Customer No. 15893762",
                PasswordToBeSaved = "welcome",
                Surname = "Dinkelburg",
                Name = "Unknown",
                DateOfBirth = DateTime.Now,
                Gender = "m"
            };

            bool clientHasBeenSaved = db.saveUser(c);
            Assert.True(clientHasBeenSaved);
        }

        [Fact]
        public void validateUserHighAnsiTest()
        {
            Assert.NotNull(db);
            string password = "Ò¿0ír}æ5u4¨±«³9CKÓgó-^¬NhÇ6¤ÿ¹ä`Ä'E/þö¼m9Ð&á,xk¿½+CÐezá×Sç^UñIèÒ";
            Tuple<bool, UserType> passGood = db.ValidateUser("selfridge", password, false);
            Tuple<bool, UserType> passWrong = db.ValidateUser("selfridge", "Wan Shi Tong", false);
            Assert.True(passGood.Item1);
            Assert.False(passWrong.Item1);
            Assert.True(passGood.Item2 == UserType.Specialist);
        }

        [Fact]
        public void getUsersTest()
        {
            List<User> users = db.GetAllUsers();

            Assert.True(users.Count >= 30);

            User louis = users.First(x => x.Name == "Louis XVIII");
            Assert.NotNull(louis);
            Assert.True(louis.Surname == "Bourbon");
            Assert.True(louis.Gender == "m");
            Assert.True(louis.UserType == UserType.Client);
            Assert.True(louis.Id == 6);

        }

        [Fact]
        public void getSingleClientByID()
        {
            User s = db.getUser(7);
            Assert.NotNull(s);
            Assert.True(s.Surname == "Valois");

        }

        [Fact]
        public void getSingleClientByUsername()
        {
            User u = db.getUser("abdullah");

        }

        [Fact]
        public void getSpecialistById()
        {
            User s = db.getUser(8);
            Assert.True(s is Specialist);
            Specialist f = (Specialist)s;

            Assert.True(f.Clients.Count == 1);

        }

        [Fact]
        public void getSpecialistByName()
        {
            User s = db.getUser("Sancho");
            Assert.True(s is Specialist);
            Specialist f = (Specialist)s;

            Assert.True(f.Clients.Count == 1);

        }

        [Fact]
        public void getSingleNonExistentUser()
        {
            Assert.Null(db.getUser("34567890"));
        }

        public void Dispose()
        {
            exterminateDB();
        }

        public void exterminateDB()
        {
            try
            {


                string t = "SET FOREIGN_KEY_CHECKS=0;TRUNCATE TABLE specialist_has_client;TRUNCATE TABLE measurement;TRUNCATE TABLE client_bmi_info;TRUNCATE TABLE users;";
                string d = "DROP TABLE specialist_has_client;DROP TABLE measurement;DROP TABLE client_bmi_info;DROP TABLE users;";
                string rmf = @"DROP DATABASE Healthcare_test; CREATE DATABASE Healthcare_test;USE Healthcare_test";


                MySqlCommand truncate = new MySqlCommand(t, db.Connection);
                MySqlCommand drop = new MySqlCommand(d, db.Connection);
                truncate.ExecuteNonQuery();
                drop.ExecuteNonQuery();
                new MySqlCommand(rmf, db.Connection).ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Could not exterminate the database.");
            }
            string test = "";
        }
    }
}
