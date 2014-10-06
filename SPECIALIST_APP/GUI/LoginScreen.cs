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
using Mallaca.Network.Packet;

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
            LoginPacket p = new LoginPacket(_usernameBox.Text, _passwordBox.Text);

            TCPController.RunClient();
            TCPController.OnPacketReceived += onLoginPacketResponse;
            TCPController.Send(p.ToString());

            TCPController.ReceiveTransmission();


        }

        private void onLoginPacketResponse(Packet p)
        {
            LoginResponsePacket resp = p as LoginResponsePacket;
            if (resp != null && resp.status == "200")
            {
                this.BeginInvoke((Action)(this.Hide));

                //TODO: Store auth token.
                TCPController.OnPacketReceived -= onLoginPacketResponse;
                var _mainScreen = new MainScreen();
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
