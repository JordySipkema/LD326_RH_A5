using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mallaca;
using Mallaca.Network;
using Mallaca.Network.Packet.Request;
using Mallaca.Network.Packet.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Mallaca.Network.Packet;
using System.IO.Ports;
using RH_APP.Classes;

namespace RH_APP.GUI
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
            _passwordBox.UseSystemPasswordChar = true;
            TCPController.RunClient();
            TCPController.OnPacketReceived += onLoginPacketResponse;
            TCPController.ReceiveTransmission();
        }

        private void _loginButton_Click(object sender, EventArgs e)
        { 

            var p = new LoginPacket(_usernameBox.Text, Hashing.CreateSHA256(_passwordBox.Text));
            TCPController.Send(p.ToString());
        }

        private void onLoginPacketResponse(Packet p)
        {
            if (this.InvokeRequired)
                this.Invoke((new Action(() => onLoginPacketResponse(p))));

            var resp = p as LoginResponsePacket;

            if (resp != null && resp.Status == "200")
            {
                this.Invoke((Action)(this.Hide));

                RH_APP.Classes.Settings.GetInstance().authToken = resp.AuthToken;
                TCPController.OnPacketReceived -= onLoginPacketResponse;
                bool stuff = false;
                if (resp.Usertype.Equals("Specialist") || resp.Usertype.Equals("Administrator"))
                {
                    stuff = true;
                }
                else if (resp.Usertype.Equals("Client"))
                {
                    
                }
                var _mainScreen = new MainScreen(stuff);
                //IAsyncResult result = this.BeginInvoke(new Action(() => _mainScreen.ShowDialog()));
                //this.BeginInvoke((new Action(() =>_mainScreen.Show())));
                //uiContext.Send((state => _mainScreen.Show()), null);
                _mainScreen.ShowDialog();
            }
            else
            {
                MessageBox.Show("Valid papers are required to open the Specialist Application. The server/inspector gave the following reasons for rejecting your documents: " + Environment.NewLine + resp.Description, "Your application has been reviewed");
            }

            

        }

        

        private void _passwordBox_KeyPress(object sender, KeyPressEventArgs e)
        {
           if(e.KeyChar == (Char)Keys.Return)
                _loginButton_Click(this, null);
        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {

        }

        private string getCOMPort()
        {

            var portNames = SerialPort.GetPortNames();
            foreach(string i in portNames){
               var serial = new SerialPort();
                serial.PortName = i;

                serial.DataBits = 8;
                serial.StopBits = StopBits.One;
                serial.ReadTimeout = 2000;
                serial.WriteTimeout = 50;

                serial.Open();

                serial.WriteLine("ID");
                var output = serial.ReadLine();
                if (!String.IsNullOrEmpty(output))
                {
                    serial.Close();
                    return i;
                }
            }
            return null;
          
        }
    }
}
