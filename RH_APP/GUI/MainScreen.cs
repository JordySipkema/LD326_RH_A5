using Mallaca;
using Mallaca.Network;
using Mallaca.Network.Packet;
using Mallaca.Network.Packet.Request;
using Mallaca.Network.Packet.Response;
using Mallaca.Usertypes;
using RH_APP.Classes;
using RH_APP.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RH_APP.GUI;


namespace RH_APP.GUI
{
    public partial class MainScreen : Form
    {
        private Chat_Controller _chatController;
        private List<User> connectedClients = new List<User>();
        private readonly RH_Controller _controller;
        public MainScreen(Boolean showMenu)
        {

            
            InitializeComponent();

            if (!showMenu)
            {
                menuStrip1.Visible = false;
                numericUpDown1.Visible = false;
                setPowerLabel.Visible = false;
            }
            
            _chatController = new Chat_Controller();

            ListPacket p = new ListPacket("connected_clients", Settings.GetInstance().authToken);
            TCPController.OnPacketReceived += handleIncomingPackets;
            TCPController.Send(p.ToString());
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This application is made by Group 23TI2A5! \n Farid Amali \n Jordy Sipkema \n Engin Can \n George de Coo \n Kevin van den Akkerveken \n Gerjan Holsappel ");
        }

        private void MainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = dialog = MessageBox.Show("Do you really want to close the program?", "Alert", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Application.ExitThread();
            }
            else if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateScreen _createScreen = new CreateScreen();
            _createScreen.ShowDialog();
        }

        private void _sendButton_Click(object sender, EventArgs e)
        {
            if (_textBox.Text == "")
            {
                MessageBox.Show("No message has been sent");
            }
            else
            {

                String message = _textBox.Text;

                _chatLogBox.AppendText("You say: " + message);
                _chatLogBox.AppendText(Environment.NewLine);

                Chat_Controller.SendMessage(message);

                _textBox.Text = "";
            }
        }

        private void _textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (_textBox.Text == "")
                {
                    MessageBox.Show("No message has been sent");
                }
                else
                {

                    String message = _textBox.Text;

                    _chatLogBox.AppendText("You say: " + message);
                    _chatLogBox.AppendText(Environment.NewLine);

                    Chat_Controller.SendMessage(message);

                    _textBox.Text = "";
                }
            }
        }

        private void createConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void MainScreen_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_Click(object sender, EventArgs e)
        {
            
            _controller.SetPower((int)(numericUpDown1.Value));
        }

        private void handleIncomingPackets(Packet p)
        {
            if (p is PullResponsePacket<User>)
            {
                PullResponsePacket<User> response = p as PullResponsePacket<User>;

                if(response.DataType == "connected_clients")
                    connectedClients = response.List;
            }
        }

        private void connectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var createScreen = new CreateConnectionScreen();
            createScreen.readClients(connectedClients);
            
            createScreen.ShowDialog();
        }

        private void loadClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var measurementScreen = new SelectMeasurementScreen();
            measurementScreen.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = dialog = MessageBox.Show("Are you sure you want to quit?", "Alert", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("© 23TI2A5 \n Kevin van de Akkerveken \n Farid Amali \n Engin Can \n George de Coo \n Gerjan Holsappel \n Jordy Sipkema");
        }
    }
}
