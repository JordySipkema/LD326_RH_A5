using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL_Tutorial.GUI
    //Test
{
    public partial class CreateScreen : Form
    {
        private DBConnect _connection;
        public CreateScreen()
        {
            InitializeComponent();
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _createButton_Click(object sender, EventArgs e)
        {
            _connection = new DBConnect();

            if(string.IsNullOrEmpty(_nameBox.Text) || string.IsNullOrEmpty(_surnameBox.Text) || string.IsNullOrEmpty(_genderBox.Text)){ 
                if(clientRadioButton.Checked)
                    MessageBox.Show("Please fill in all fields");
            }
            else if(string.IsNullOrEmpty(Usernamebox.Text) || string.IsNullOrEmpty(passwordBox.Text))
                MessageBox.Show("Please fill in all fields");

            

            if (clientRadioButton.Checked)
                _connection.saveClient(_nameBox.Text, _surnameBox.Text, _genderBox.Text.ToLower(), dateOfBirthPicker.Value);
            else
                _connection.saveSpecialist(_nameBox.Text, _surnameBox.Text, _genderBox.Text.ToLower(), Usernamebox.Text, passwordBox.Text, dateOfBirthPicker.Value);
            this.Close();
        }

        private void _genderBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void _nameBox_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(_nameBox.Text)) {
                Usernamebox.Text = _nameBox.Text;
            }
        }

        private void CreateScreen_Load(object sender, EventArgs e)
        {
            Usernamebox.Enabled = false;
            passwordBox.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (specialistRadioButton.Checked)
            {
                Usernamebox.Enabled = true;
                passwordBox.Enabled = true;
            }
            else {
                Usernamebox.Enabled = false;
                passwordBox.Enabled = false;
            }
        }

    }
}
