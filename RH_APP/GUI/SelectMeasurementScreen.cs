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
using Mallaca.Network.Packet;
using Mallaca.Network.Packet.Request;
using Mallaca.Network.Packet.Response;
using Mallaca.Usertypes;
using Newtonsoft.Json.Linq;
using RH_APP.Classes;

namespace RH_APP.GUI
{
    public partial class SelectMeasurementScreen : Form
    {
        private List<SessionData> sessions;
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
            if (!(datecombobox.SelectedItem is SessionData))
                return;
            SessionData data = (SessionData)datecombobox.SelectedItem;
            
            LSMPacket request = new LSMPacket(data.userId, data.sessionId, Settings.GetInstance().authToken);
            TCPController.Send(request.ToString());

        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SelectMeasurementScreen_Load(object sender, EventArgs e)
        {

        }

        private void handleIncomingPackets(Packet p)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => handleIncomingPackets(p)));
                return;
            }

            // Tuple<userId, SessionId, DateOfSession>()
            if (p is PullResponsePacket<SessionData>)
            {
                var response = p as PullResponsePacket<SessionData>;

                if (response.DataType == "user_sessions")
                {
                    Console.WriteLine("Sessions loaded");
                    sessions = response.List;
                    usersCombobox_SelectedIndexChanged(this, EventArgs.Empty);

                }
            }
            else if (p is PullUsersResponsePacket)
            {
                var response = p as PullUsersResponsePacket;
                users = response.List.Where(x => x.IsClient).ToList();
                BindingSource bs = new BindingSource();
                bs.DataSource = users;
                usersCombobox.DataSource = bs;
                usersCombobox.DisplayMember = "Fullname";
                usersCombobox.ValueMember = "Id";
            }
            else if (p is PullResponsePacket<Measurement>)
            {
                TCPController.OnPacketReceived -= handleIncomingPackets;
                this.Close();
                GraphResultUI ui = new GraphResultUI(((PullResponsePacket<Measurement>)p).List);
                ui.Show();
            }
        }

        private void usersCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            User user = usersCombobox.SelectedItem as User;
            datecombobox.Items.Clear();
            
            if (user == null || sessions == null)
            {
                datecombobox.Items.Add("No sessions found.");
                datecombobox.SelectedIndex = 0;
                return;
            }

            datecombobox.Items.Clear();
            var q = sessions.Where(x => x.userId == user.Id).ToList();

            if (q.Count < 1)
            {
                datecombobox.Items.Add("No sessions found.");
                datecombobox.SelectedIndex = 0;
                return;
            }
                
            q.ForEach(x => datecombobox.Items.Add(x));
            datecombobox.SelectedIndex = 0;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


    }
}
