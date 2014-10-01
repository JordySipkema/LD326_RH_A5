using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mallaca;
using Mallaca.Network;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Application_Specialist.GUI
{
    public partial class LoginScreen : Form
    {
        

        public LoginScreen()
        {
            InitializeComponent();
            _passwordBox.UseSystemPasswordChar = true;
            
        }

        private void _loginButton_Click(object sender, EventArgs e)
        { 
            JObject loginPacket = new JObject(
                new JProperty("CMD", "LOGIN"),
                new JProperty("username", _usernameBox.Text),
                new JProperty("password", Hashing.CreateSHA256(_passwordBox.Text)));

            //if (_connection.ValidateUser(_usernameBox.Text, _passwordBox.Text))
            //TODO: send username and hashed password to server for authentication.
            
        }

        private void onLoginPacketResponse()
        {
            if (true)
            {
                this.Hide();
                var _mainScreen = new MainScreen();
                this.Hide();
                _mainScreen.ShowDialog();

            }
            else
            {
                MessageBox.Show("Invalid username/password!");
            }

        }

        

        private void _passwordBox_KeyPress(object sender, KeyPressEventArgs e)
        {
           if(e.KeyChar == (Char)Keys.Return)
                _loginButton_Click(this, null);
        }
    }
}
