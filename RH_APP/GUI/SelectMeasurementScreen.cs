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
        private List<Tuple<int, int, DateTime>> sessions;
        private List<User> users; 
        public SelectMeasurementScreen()
        {
            InitializeComponent();

            TCPController.OnPacketReceived += handleIncomingPackets;
            ListPacket p = new ListPacket("users", Settings.GetInstance().authToken);
            TCPController.Send(p.ToString());

            UpdateConnectedUsersList();
        }

        private void UpdateConnectedUsersList()
        {
            ListPacket p = new ListPacket("user_sessions", Settings.GetInstance().authToken);
            TCPController.Send(p.ToString());
            users = new List<User>();

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
            if (p is PullResponsePacket<Tuple<int, int, DateTime>>)
            {
                var response = p as PullResponsePacket<Tuple<int, int, DateTime>>;

                if (response.DataType == "user_sessions")
                    sessions = response.List;
            }
            else if (p is PullUsersResponsePacket)
            {
                var response = p as PullUsersResponsePacket;
                users = response.List.Where(x => x.IsClient).ToList();
                BindingSource bs = new BindingSource();
                bs.DataSource = users;
                usersCombobox.Invoke((new Action(() => usersCombobox.DataSource = bs)));
                usersCombobox.Invoke((new Action(() => usersCombobox.DisplayMember = "Name")));
                usersCombobox.Invoke((new Action(() => usersCombobox.ValueMember = "Id")));
            }
        }
    }
}
