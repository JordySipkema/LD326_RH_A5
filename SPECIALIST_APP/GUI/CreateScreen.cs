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

            string pleaseFillIntext = "Please fill in all fields";
            if(string.IsNullOrEmpty(_nameBox.Text) || string.IsNullOrEmpty(_surnameBox.Text) || _genderMaleRadioButton.Checked == false || _genderFemaleRadioButton.Checked == false){
                MessageBox.Show(pleaseFillIntext);
                return;
            }
            else if (clientRadioButton.Checked && String.IsNullOrEmpty(_lengthBox.Text) || clientRadioButton.Checked && string.IsNullOrEmpty(_weightBox.Text))
            {
                MessageBox.Show(pleaseFillIntext);
                return;
            }

            String gender;

            if (_genderMaleRadioButton.Checked)
            {
                gender = "m";
            }
            else
            {
                gender = "f";
            }
            

            if (clientRadioButton.Checked)
                _connection.saveClient(_nameBox.Text, _surnameBox.Text, gender, dateOfBirthPicker.Value, Decimal.Parse(_lengthBox.Text), Decimal.Parse(_weightBox.Text));
            else
                _connection.saveSpecialist(_nameBox.Text, _surnameBox.Text, gender, Usernamebox.Text, passwordBox.Text, dateOfBirthPicker.Value);
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
            _lengthBox.Enabled = false;
            _weightBox.Enabled = false;
        }
    }
}
