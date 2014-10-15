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
    public partial class SelectMeasurementScreen : Form
    {
        public SelectMeasurementScreen()
        {
            InitializeComponent();
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
    }
}
