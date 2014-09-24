using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace RH_Server.Database
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

        private bool _isValid;


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

        public bool userValidation(String _username, String _password) {

            try
            {
                
                _selectCommand = new MySqlCommand("SELECT * FROM " + _database + ".users WHERE user_type > 0 AND username=\"" + _username + "\" AND password=\"" + _password + "\";", _connection);
                
                _reader = _selectCommand.ExecuteReader();

                int _counter = 0;

                while (_reader.Read())
                {
                    _counter += 1;
                }
                if (_counter == 1)
                {
                    _isValid = true;

                }
                else if (_counter > 1)
                {
                    _isValid = false;
                }
                else
                {
                    _connection.Close();
                    _isValid = false;
                }
                
            }
            catch (MySqlException ex)
            {
                throw;
                //MessageBox.Show(ex.Message);
            }
            return _isValid;
        }

        public void openConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
                return;
            else
                _connection.Open();
        }


        public bool SaveClient(String name, String surname, string username, string pass, String gender, DateTime dob, decimal length, decimal weight)
        {

            string query = String.Format("INSERT into {0}.users (name,surname, username, password, gender, dateOfBirth) values('{1}','{2}','{3}','{4}', '{5}', '{6}') ;",
                _database, name, surname, username, pass, gender, dob.Date.ToString("yyyy-MM-dd"));

            openConnection();
            _selectCommand = new MySqlCommand(query, _connection);
            
            try
            {
                _reader = _selectCommand.ExecuteReader();
                _reader.Close();


                String queryBMI = String.Format("INSERT into {0}.client_bmi_info (length, weight, users_id) values('{1}','{2}', '{3}') ;", _database, length.ToString("0.000", CultureInfo.InvariantCulture), weight.ToString("0.000", CultureInfo.InvariantCulture), getLastInsertId());
                _selectCommand = new MySqlCommand(queryBMI, _connection);
                MySqlDataReader reader = _selectCommand.ExecuteReader();
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
            return true;
 
        }

        public bool SaveMeasurement(Measurement m, int sessionId, int userId) 
        {
            string measurementQuery = String.Format("INSERT INTO {0}.measurement(session_id, RPM, speed, distance, power, energy, pulse, user_id, datetime, time) VALUES('{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}', '{9}', '{10}')",
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
            return false;
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
                throw;
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

        public bool saveSpecialist(String name, String surname, String gender, string username, string pass, DateTime dob)
        {
            String query = string.Format("INSERT into {0}.users (name,surname,gender, username, password, dateOfBirth, user_type) values('{1}','{2}','{3}','{4}','{5}','{6}', 1)",
                _database, name, surname, gender,  username, pass, dob.Date.ToString("yyyy-MM-dd")) ;
            initialize();
            _selectCommand = new MySqlCommand(query, _connection);

            try
            {
                _connection.Open();
                _reader = _selectCommand.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Exception: DBConnect.saveSpecialist(): " + ex.Message);
                return false;
            }
            return true;

        }
    }
}
