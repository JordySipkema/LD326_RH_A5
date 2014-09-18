using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            DBConnect _connection = new DBConnect();
            if (_connection.userValidation(_usernameBox.Text, _passwordBox.Text))
            {
                this.Hide();
                MainScreen _mainScreen = new MainScreen();
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
