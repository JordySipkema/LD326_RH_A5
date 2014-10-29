using Mallaca.Network;
using Mallaca.Network.Packet;
using Mallaca.Network.Packet.Request;
using Mallaca.Network.Packet.Response;
using Mallaca.Usertypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RH_APP.Classes;

namespace RH_APP.GUI
{
    public partial class CreateConnectionScreen : Form
    {
        public CreateConnectionScreen()
        {
            InitializeComponent();
            var p = new ListPacket("connected_clients", Settings.GetInstance().authToken);
            TCPController.OnPacketReceived += ReceiveHonoredGuests;
            TCPController.Send(p);

        }

        private void readClients(List<User> clients)
        {
            bool isEmpty = !clients.Any();
            _clientList.Items.Clear();
            if (isEmpty)
            {
                _clientList.Items.Add("No clients are connected!");
            }
            else
            {
                foreach (User user in clients)
                {
                    _clientList.Items.Add(user);
                }
                _clientList.DisplayMember = "Fullname";
                
            }     
        }


        private void _cancelButton_Click(object sender, EventArgs e)
        {
            //DialogResult dialog = dialog = MessageBox.Show("Are you sure you want to cancel?", "Alert", MessageBoxButtons.YesNo);
            //if (dialog == DialogResult.Yes)
            //{
                this.Close();
            //}
        }

        private void _clientList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void _connectButton_Click(object sender, EventArgs e)
        {
            // Loop through all items the ListBox. 

            foreach (User u in _clientList.SelectedItems)
            {                
               //var mainScreen = new MainScreen(u);
               var mainScreen = new TrainingScreen(u);
               
               mainScreen.Show();
            }
            this.Dispose();
        }

        private void CreateConnectionScreen_Load(object sender, EventArgs e)
        {

        }

        private void ReceiveHonoredGuests(Packet p)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((new Action(() => ReceiveHonoredGuests(p))));
                return;
            }

            if (p is PullResponsePacket<User>)
            {
                var response = p as PullResponsePacket<User>;

                if (response.DataType == "connected_clients")
                    readClients(response.List);
                TCPController.OnPacketReceived -= ReceiveHonoredGuests;

            }
        }
    }
}
