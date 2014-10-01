using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mallaca.Usertypes;
using MySql.Data.MySqlClient;
using System.Globalization;
namespace Mallaca
{
// ReSharper disable once InconsistentNaming
    public class DBConnect
    {
        public MySqlConnection Connection {get; private set;}
        private MySqlCommand _selectCommand;
        private MySqlDataReader _reader;

        private String _server;
        private String _database;
        private String _username;
        private String _password;


        public DBConnect()
        {
            initialize("deb58589n5_a5", "paullindelauf", "s121.webhostingserver.nl", "deb58589n5_healthcare");
        }

        public DBConnect(string username, string pass, string serverAdress, string dbname)
        {
            initialize(username, pass, serverAdress, dbname);
        }


        public String Server { 
            get { return _server; } set { _server = value; }
        }

        public String Database {
            get { return _database; } set { _database = value; }
        }

        public String Username {
            get { return _username; } set { _username = value; }
        }

        public String Password {
            get { return _password; } set { _password = value; }
        }

        public void initialize(string username, string pass, string server, string dbname)
        {
            this._username = username;
            this._password = pass;
            _server = server;
            _database = dbname;


            //String connectionString = "SERVER=" + _server + ";" 
             //   + "USERNAME= " + _username + ";" + "PASSWORD=" + _password + ";Convert Zero Datetime=True;";

            var connectionString = String.Format("SERVER={0}; USERNAME={1}; PASSWORD={2};Convert Zero Datetime=True;",
                _server, _username, _password);

            if (dbname != null)
                connectionString += "DATABASE=" + _database + ";";

            Connection = new MySqlConnection(connectionString);
            Connection.Open();
            
         }

        public Tuple<bool, UserType> ValidateUser(String username, String password, bool passIsHashedWithSha256) {
            OpenConnection();
            try
            { 
                if (!passIsHashedWithSha256)
                    password = Hashing.CreateSHA256(password);

                _selectCommand = new MySqlCommand(
                    String.Format("SELECT * FROM {0}.users WHERE username='{1}' AND password='{2}';", _database, _username
                        , _password) , Connection);
                _reader = _selectCommand.ExecuteReader();
                var rows = 0;
                var usertypeInt = -2;
                while (_reader.Read())
                {
                    var dr = (IDataRecord) _reader;
                    usertypeInt = (int)dr["user_type"];
                    rows++;
                }

                if (rows == 1 && Enum.IsDefined(typeof (UserType), usertypeInt))
                {
                    var usertype = (UserType) usertypeInt;
                    return new Tuple<bool, UserType>(true, usertype);
                }
            }
            catch(MySqlException e)
            {
                Console.WriteLine("Could not validate user. " + e.Message);
            }
            finally
            {
                Connection.Close();
            }

            return new Tuple<bool, UserType>(false, UserType.None);
        }

        public void OpenConnection()
        {
            if (Connection.State == System.Data.ConnectionState.Open)
                return;
            else
                Connection.Open();
        }

        public bool SaveMeasurement(Measurement m, int sessionId, int userId) 
        {
            var measurementQuery = String.Format("INSERT INTO {0}.measurement(session_id, RPM, speed, distance, power, energy, pulse, user_id, datetime, time) VALUES('{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}', '{9}', '{10}')",
                _database, sessionId, m.RPM, m.SPEED, m.DISTANCE, m.POWER, m.ENERGY,  m.PULSE, userId, m.DATE.ToString("yyyy-MM-dd HH:mm:ss.fff"),  ":00" + m.TIME);
            OpenConnection();
            _selectCommand = new MySqlCommand(measurementQuery, Connection);

            try
            {
                _reader = _selectCommand.ExecuteReader();
                _reader.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Exception: DBConnect.saveClient(): " + ex.Message);
                throw;
            }
            finally
            {
                Connection.Close();
            }
        }

        public List<User> GetAllUsers()
        {
            string usersQuery = String.Format("SELECT user_type, {0}.users.id, username, name, dateOfBirth, surname, gender, password, length, weight FROM {0}.users LEFT JOIN {0}.client_bmi_info on {0}.users.id = {0}.client_bmi_info.users_id  ", _database);
            OpenConnection();
            _selectCommand = new MySqlCommand(usersQuery, Connection);

            var users = new List<User>();

            _reader = _selectCommand.ExecuteReader();
            while (_reader.Read())
            {
                User u;
                if (_reader.GetInt32(0) == 1)
                {
                    u = new Specialist
                    {
                        Username = _reader.IsDBNull(2) ? null : _reader.GetString(2),
                        Surname = _reader.IsDBNull(5) ? null : _reader.GetString(5),
                        Name = _reader.IsDBNull(3) ? null : _reader.GetString(3),
                        DateOfBirth = _reader.IsDBNull(4) ? DateTime.MinValue : (DateTime)_reader.GetMySqlDateTime(4),
                        Id = _reader.IsDBNull(1) ? 0 : _reader.GetInt32(1),
                        Gender = _reader.IsDBNull(6) ? null : _reader.GetString(6)
                    };
                }
                else if (_reader.GetInt32(0) == 0)
                {
                    u = new Client
                    {
                        Username = _reader.IsDBNull(2) ? null : _reader.GetString(2),
                        Surname = _reader.IsDBNull(5) ? null : _reader.GetString(5),
                        Name = _reader.IsDBNull(3) ? null : _reader.GetString(3),
                        DateOfBirth = _reader.IsDBNull(4) ? DateTime.MinValue : (DateTime)_reader.GetMySqlDateTime(4),
                        Id = _reader.IsDBNull(1) ? 0 : _reader.GetInt32(1),
                        Gender = _reader.IsDBNull(6) ? null : _reader.GetString(6),
                        Lenght = _reader.IsDBNull(8) ? -1 : _reader.GetDecimal(8),
                        Weight = _reader.IsDBNull(9) ? -1 : _reader.GetDecimal(9)
                    };
                }
                else
                    continue;
                users.Add(u);
            }
                
            _reader.Close();

            
            if (users.Count == 0)
                return users;

            string clientsQuery = String.Format("Select specialistId, clientId FROM {0}.specialist_has_client", _database);
            _selectCommand = new MySqlCommand(clientsQuery, Connection);

            var specialists = new List<Specialist>();
            try
            {
                _reader = _selectCommand.ExecuteReader();
                while(_reader.Read())
                {
                    
                    int specialistId = _reader.GetInt32(0);
                    int clientId = _reader.GetInt32(1);
                    Specialist specialist;
                    if (specialists.Any(p => p.Id == specialistId))
                    {
                        specialist = specialists.First(p => p.Id == specialistId);
                    }
                    else
                    {
                        User userSpecialist = users.First(q => q.Id == specialistId);
                        if(!(userSpecialist is Specialist))
                            continue;

                        users.Remove(userSpecialist);
                        specialist = (Specialist)userSpecialist;
                        specialists.Add(specialist);
                    }

                    User client = users.First(z => z.Id == clientId);
                    if (!(client is Client))
                        continue;

                    specialist.Clients.Add((Client) client);
                }

                
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Exception when adding clients to a specialist: " + ex.Message);
                throw;
            }

            List<User> specialistUsers = specialists.Cast<User>().ToList();
            List<User> finalList = users.Union(specialistUsers).ToList();

            return finalList;
        }

        public bool saveUser(User user)
        {
            OpenConnection();
            
            MySqlTransaction trans = Connection.BeginTransaction();
            try
            {
                string userQuery;
                if (user.Id == null)
                {
                    userQuery = string.Format("INSERT INTO {6}.users(username, dateOfBirth, surname, gender, name, user_type) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')",
                         user.Username, user.DateOfBirth.ToString("yyyy-mm-dd"), user.Surname, user.Gender, user.Name,((int) user.UserType), _database);
                    _selectCommand = new MySqlCommand(userQuery, Connection);
                    _selectCommand.ExecuteNonQuery();
                    user.Id = getLastInsertId(); 
                }
                else
                {
                    string date = user.DateOfBirth.ToString("yyyy-MM-dd");
                    userQuery = string.Format("UPDATE {7}.users SET username='{0}', dateOfBirth='{1}',surname='{2}',gender='{3}', name='{4}', user_type='{5}' WHERE id = {6}",
                        user.Username, date, user.Surname, user.Gender, user.Name, ((int)user.UserType), user.Id, _database);
                    _selectCommand = new MySqlCommand(userQuery, Connection);
                    _selectCommand.ExecuteNonQuery();
                }

                if(!string.IsNullOrWhiteSpace(user.PasswordToBeSaved))
                {
                    string queryPass = String.Format("UPDATE {1}.users SET password= '{0}' WHERE id = {2}", Hashing.CreateSHA256(user.PasswordToBeSaved), _database, user.Id);
                    MySqlCommand command = new MySqlCommand(queryPass, Connection);
                    user.PasswordToBeSaved = null;
                    command.ExecuteNonQuery();
                }

                if (user is Client)
                {
                    var c = (Client)user;
                    var clientQuery = string.Format("INSERT INTO {3}.client_bmi_info(users_id, length, weight) VALUES('{0}','{1}','{2}') ON DUPLICATE KEY " +
                        "UPDATE length =  '{1}', weight = '{2}'", c.Id, c.Lenght.ToString("0.000", CultureInfo.InvariantCulture), c.Weight.ToString("0.000", CultureInfo.InvariantCulture), _database);
                    _selectCommand = new MySqlCommand(clientQuery, Connection);
                    _selectCommand.ExecuteNonQuery();
                }
                else if (user is Specialist)
                {
                    var s = (Specialist)user;
                    var removeClients = string.Format("DELETE FROM {1}.specialist_has_client WHERE specialistId= {0}", user.Id, _database);
                    _selectCommand = new MySqlCommand(removeClients, Connection);
                    _selectCommand.ExecuteNonQuery();

                    foreach (var addclient in s.Clients.Select(client => 
                        string.Format("INSERT INTO {2}.specialist_has_client(specialistId ,clientId) VALUES('{0}', '{1}')",
                        s.Id, client.Id, _database)))
                    {
                        _selectCommand = new MySqlCommand(addclient, Connection);
                        _selectCommand.ExecuteNonQuery();
                    }
                }

                trans.Commit();
            }
            catch (MySqlException)
            {
                trans.Rollback(); // rollback all changes 
                //return false;
                throw;
            }
            finally
            {
                Connection.Close();
            }
            return true;
        }

        public bool removeUser(User user) 
        { 
            if(user.Id == null)
                return false;
            string remove = string.Format("DELETE FROM users WHERE id='{0}'", user.Id);
            OpenConnection();
            try
            {
                var removeCommand = new MySqlCommand(remove);
                removeCommand.ExecuteNonQuery();
            }
            catch (MySqlException)
            {
                return false;
            }
            finally
            {
                Connection.Close();
            }
            return true;
        }

        public int getNewTrainingSessionId(int userId)
        {
            string countQuery = String.Format("SELECT COUNT(DISTINCT session_id) FROM {0}.measurement WHERE user_id = {1}", _database, userId);
            OpenConnection();
            _selectCommand = new MySqlCommand(countQuery, Connection);

            try
            {
                _reader = _selectCommand.ExecuteReader();
                _reader.Read();
                int retval = _reader.GetInt32(0);
                _reader.Close();
                return retval;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Exception: DBConnect.saveClient(): " + ex.Message);
                return -1;
            }
            finally
            {
                Connection.Close();
            }
            
            
        }



        private int getLastInsertId() 
        {
            var query = new MySqlCommand("SELECT last_insert_id();", Connection);
            
            try
            {
                _reader = query.ExecuteReader();
                _reader.Read();
                
                int retval = _reader.GetInt32(0);;
                _reader.Close();
                return retval;

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Exception: DBConnect.getLastInsertId(): " + ex.Message);
                throw;
            }

        }
    }
}
