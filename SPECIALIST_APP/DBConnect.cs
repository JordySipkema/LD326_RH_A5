using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace SQL_Tutorial
{
    class DBConnect
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
            
            
         }

        public bool userValidation(String _username, String _password) {

            try
            {
                _connection.Open();
                _selectCommand = new MySqlCommand("SELECT * FROM " + _database + ".users WHERE isSpecialist=1 AND username=\"" + _username + "\" AND password=\"" + _password + "\";", _connection);
                
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
                MessageBox.Show(ex.Message);
            }
            return _isValid;
        }


        public void saveUser(String name, String surname, String gender)
        {
            String _query = "INSERT into " + _database + ".users (name,surname,gender) values('" + name + "','" + surname + "','" + gender + "') ;";
            initialize();
            _selectCommand = new MySqlCommand(_query, _connection);

            try
            {
                _connection.Open();
                _reader = _selectCommand.ExecuteReader();
                MessageBox.Show("User added!");
                while (_reader.Read())
                {

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

 
        }
    }
}
