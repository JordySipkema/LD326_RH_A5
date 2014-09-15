using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application_Specialist.GUI
{
    public partial class ExitScreen : Form
    {
        public ExitScreen()
        {
            InitializeComponent();
        }

        private void _noButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _yesButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
