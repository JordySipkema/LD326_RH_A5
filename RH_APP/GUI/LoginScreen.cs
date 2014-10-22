﻿using System;
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
using Mallaca.Usertypes;
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
            TCPController.OnPacketReceived += LoginPacketResponse;
            TCPController.ReceiveTransmission();
        }

        private void _loginButton_Click(object sender, EventArgs e)
        { 

            var p = new LoginPacket(_usernameBox.Text, Hashing.CreateSHA256(_passwordBox.Text));
            TCPController.Send(p.ToString());
        }

        private void LoginPacketResponse(Packet p)
        {
            var resp = p as LoginResponsePacket;

            if (resp == null)
                return;

            if (this.InvokeRequired)
            {
                this.Invoke((new Action(() => LoginPacketResponse(p))));
                return;
            }



            Console.WriteLine(p.ToString());



            if (resp.Status == "200")
            {

                RH_APP.Classes.Settings.GetInstance().authToken = resp.AuthToken;
                RH_APP.Classes.Settings.GetInstance().CurrentUser = resp.User;
                if (resp.User.IsSpecialist || resp.User.IsAdministrator)
                {
                    var mainScreen = new MainScreen(true);
                    TCPController.OnPacketReceived -= LoginPacketResponse;
                    mainScreen.ShowDialog();
                }
                else if (resp.User.IsClient)
                {

                    if (checkCOMPort())
                    {
                        this.Hide();
                        COM_Bike b = new COM_Bike(getCOMPort());
                        var mainScreen = new MainScreen(false, b);
                        TCPController.OnPacketReceived -= LoginPacketResponse;
                        mainScreen.Text = " Remote Healthcare - Client Edition";
                        mainScreen.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("No connection with a bike, try again!");
                    }

                    
                }
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
                    serial.WriteLine("RS");
                    Thread.Sleep(10);
                    serial.Close();
                    return i;
                }
            }
            return null;
          
        }

        private bool checkCOMPort()
        {
            String result = getCOMPort();
            if (result != null)
            {
                return true;
            }
            return false;
        }
    }
}
