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

namespace RH_APP.GUI
{
    public partial class CreateConnectionScreen : Form
    {
        public CreateConnectionScreen()
        {
            InitializeComponent();
        }

        public void readClients(List<User> clients)
        {
            bool isEmpty = !clients.Any();

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
            DialogResult dialog = dialog = MessageBox.Show("Are you sure you want to cancel?", "Alert", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void _clientList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
