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
    public partial class chooseYourBikeUI : Form
    {
        public chooseYourBikeUI()
        {
            InitializeComponent();
        }

        private void TXTBikeButton_Click(object sender, EventArgs e)
        {
            RH_BIKE_GUI b;
            if(writeToFileCheckbox.Checked)
                b = new RH_BIKE_GUI(new TXT_Bike(readFromTextbox.Text), writeLocationTextbox.Text);
            else
                b = new RH_BIKE_GUI(new TXT_Bike(readFromTextbox.Text));
            b.Show();
            this.Hide();
            
        }

        private void randomizeButton_Click(object sender, EventArgs e)
        {
            RH_BIKE_GUI b;
            if (writeToFileCheckbox.Checked)
                b = new RH_BIKE_GUI(new STUB_Bike(), writeLocationTextbox.Text);
            else
                b = new RH_BIKE_GUI(new STUB_Bike());
            b.Show();
            this.Hide();
        }

        private void comButton_Click(object sender, EventArgs e)
        {
            RH_BIKE_GUI b;
            if (writeToFileCheckbox.Checked)
                b = new RH_BIKE_GUI(new COM_Bike(comPortTextbox.Text), writeLocationTextbox.Text);
            else
                b = new RH_BIKE_GUI(new COM_Bike(comPortTextbox.Text));
            b.Show();
            this.Hide();
        }

        private void chooseYourBikeUI_Load(object sender, EventArgs e)
        {
            readFromTextbox.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\measurements.txt";
            writeLocationTextbox.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\measurements.txt";
        }
    }
}
