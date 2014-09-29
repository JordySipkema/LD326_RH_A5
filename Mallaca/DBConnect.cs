using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Globalization;
namespace Mallaca
{
    public class DBConnect
    {
        private MySqlConnection _connection;
        private MySqlCommand _selectCommand;
        private MySqlDataReader _reader;

        private String _server;
        private String _database;
        private String _username;
        private String _password;


        public DBConnect()
        {
            initialize();
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

        public void initialize()
        {
            this._username = "deb58589n5_a5";
            this._password = "paullindelauf";
            _server     = "s121.webhostingserver.nl";
            _database = "deb58589n5_healthcare";


            String _connectionString;

            _connectionString = "SERVER=" + _server + ";" + "DATABASE=" + _database + ";"
                + "USERNAME= " + _username + ";" + "PASSWORD=" + _password + ";";

            _connection = new MySqlConnection(_connectionString);
            _connection.Open();
            
         }

        public bool ValidateUser(String _username, String _password, UserType userType, bool passIsHashedWithSHA256) {
            openConnection();
            try
            { 
                if (!passIsHashedWithSHA256)
                    _password = Hashing.CreateSHA256(_password);

                _selectCommand = new MySqlCommand("SELECT * FROM " + _database + ".users WHERE user_type = "+ ((int)userType) + " AND username=\"" + _username + "\" AND password=\"" + _password + "\";", _connection);
                
                _reader = _selectCommand.ExecuteReader();
                int rows = 0;
                while (_reader.Read())
                    rows++;
                
                if(rows == 1)
                    return true ;
            }
            catch(MySqlException e)
            {
                Console.WriteLine("Could not validate user. " + e.Message);
                return false;
            }
            finally
            {
                _connection.Close();
            }
            return false;
        }

        public void openConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
                return;
            else
                _connection.Open();
        }

        public bool SaveMeasurement(Measurement m, int sessionId, int userId) 
        {
            var measurementQuery = String.Format("INSERT INTO {0}.measurement(session_id, RPM, speed, distance, power, energy, pulse, user_id, datetime, time) VALUES('{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}', '{9}', '{10}')",
                _database, sessionId, m.RPM, m.SPEED, m.DISTANCE, m.POWER, m.ENERGY,  m.PULSE, userId, m.DATE.ToString("yyyy-MM-dd HH:mm:ss.fff"),  ":00" + m.TIME);
            openConnection();
            _selectCommand = new MySqlCommand(measurementQuery, _connection);

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
                _connection.Close();
            }
        }

        public List<User> GetAllUsers()
        {
            string usersQuery = String.Format("SELECT user_type, {0}.users.id, username, name, dateOfBirth, surname, gender, password, length, weight FROM {0}.users LEFT JOIN {0}.client_bmi_info on {0}.users.id = {0}.client_bmi_info.users_id  ", _database);
            openConnection();
            _selectCommand = new MySqlCommand(usersQuery, _connection);

            List<User> users = new List<User>();

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
            _selectCommand = new MySqlCommand(clientsQuery, _connection);

            List<Specialist> specialists = new List<Specialist>();
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
            }

            List<User> specialistUsers = specialists.Cast<User>().ToList();
            List<User> finalList = users.Union(specialistUsers).ToList();

            return finalList;
        }

        public bool saveUser(User user)
        {
            openConnection();
            
            MySqlTransaction trans = _connection.BeginTransaction();
            try
            {
                string userQuery;
                if (user.Id == null)
                {
                    userQuery = string.Format("INSERT INTO {7}.users(username, dateOfBirth, surname, gender, name, user_type) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')",
                         user.Username, user.DateOfBirth.ToString("yyyy-mm-dd"), user.Surname, user.Gender, user.Name,((int) user.UserType), _database);
                    _selectCommand = new MySqlCommand(userQuery, _connection);
                    _selectCommand.ExecuteNonQuery();
                    user.Id = getLastInsertId(); 
                }
                else
                {
                    string date = user.DateOfBirth.ToString("yyyy-MM-dd");
                    userQuery = string.Format("UPDATE {7}.users SET username='{0}', dateOfBirth='{1}',surname='{2}',gender='{3}', name='{4}', user_type='{5}' WHERE id = {6}",
                        user.Username, date, user.Surname, user.Gender, user.Name, ((int)user.UserType), user.Id, _database);
                    _selectCommand = new MySqlCommand(userQuery, _connection);
                    _selectCommand.ExecuteNonQuery();
                }

                if(!string.IsNullOrWhiteSpace(user.PasswordToBeSaved))
                {
                    string queryPass = String.Format("UPDATE {1}.users SET password= '{0}' WHERE id = {3}", Hashing.CreateSHA256(user.PasswordToBeSaved), _database, user.Id);
                    MySqlCommand command = new MySqlCommand(queryPass, _connection);
                    user.PasswordToBeSaved = null;
                    command.ExecuteNonQuery();
                }

                if (user is Client)
                {
                    Client c = (Client)user;
                    string clientQuery = string.Format("INSERT INTO {3}.client_bmi_info(users_id, length, weight) VALUES('{0}','{1}','{2}') ON DUPLICATE KEY " +
                        "UPDATE length =  '{1}', weight = '{2}'", c.Id, c.Lenght.ToString("0.000", CultureInfo.InvariantCulture), c.Weight.ToString("0.000", CultureInfo.InvariantCulture), _database);
                    _selectCommand = new MySqlCommand(clientQuery, _connection);
                    _selectCommand.ExecuteNonQuery();
                }
                else if (user is Specialist)
                {
                    Specialist s = (Specialist)user;
                    string removeClients = string.Format("DELETE FROM {1}.specialist_has_client WHERE specialistId= {0}", user.Id, _database);
                    _selectCommand = new MySqlCommand(removeClients, _connection);
                    _selectCommand.ExecuteNonQuery();
                    foreach (Client client in s.Clients)
                    {
                        string addclient = string.Format("INSERT INTO {2}.specialist_has_client(specialistId ,clientId) VALUES('{0}', '{1}')", s.Id, client.Id, _database);
                        _selectCommand = new MySqlCommand(addclient, _connection);
                        _selectCommand.ExecuteNonQuery();
                    }
                }

                trans.Commit();
            }
            catch (MySqlException ex)
            {
                trans.Rollback(); // rollback all changes 
                return false;
            }
            finally
            {
                _connection.Close();
            }
            return true;
        }

        public bool removeUser(User user) 
        { 
            if(user.Id == null)
                return false;
            string remove = string.Format("DELETE FROM users WHERE id='{0}'", user.Id);
            openConnection();
            try
            {
                MySqlCommand removeCommand = new MySqlCommand(remove);
                removeCommand.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                return false;
            }
            finally
            {
                _connection.Close();
            }
            return true;
        }

        public int getNewTrainingSessionId(int userId)
        {
            string countQuery = String.Format("SELECT COUNT(DISTINCT session_id) FROM {0}.measurement WHERE user_id = {1}", _database, userId);
            openConnection();
            _selectCommand = new MySqlCommand(countQuery, _connection);

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
                _connection.Close();
            }
            
            
        }



        private int getLastInsertId() 
        {
            MySqlCommand query = new MySqlCommand("SELECT last_insert_id();", _connection);
            
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
