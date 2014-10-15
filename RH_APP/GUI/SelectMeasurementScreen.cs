using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mallaca.Network;
using Mallaca.Network.Packet;
using Mallaca.Network.Packet.Request;
using Mallaca.Network.Packet.Response;
using Mallaca.Usertypes;
using RH_APP.Classes;

namespace RH_APP.GUI
{
    public partial class SelectMeasurementScreen : Form
    {
        private List<User> connectedClients = new List<User>();

        public SelectMeasurementScreen()
        {
            InitializeComponent();

            TCPController.OnPacketReceived += handleIncomingPackets;
            UpdateConnectedUsersList();
        }

        private void UpdateConnectedUsersList()
        {
            ListPacket p = new ListPacket("user_sessions", Settings.GetInstance().authToken);
            TCPController.Send(p.ToString());
        }

        private void _displayButton_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult dialog = dialog = MessageBox.Show("Are you sure you want to cancel?", "Alert", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void SelectMeasurementScreen_Load(object sender, EventArgs e)
        {

        }

        private void handleIncomingPackets(Packet p)
        {
            if (p is PullResponsePacket<User>)
            {
                PullResponsePacket<User> response = p as PullResponsePacket<User>;

                if (response.DataType == "user_sessions") ;
            }
        }
    }
}
