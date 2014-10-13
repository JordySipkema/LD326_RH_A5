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
namespace RH_APP.GUI
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

            const string pleaseFillIntext = "Please fill in all fields";
            if(string.IsNullOrEmpty(_nameBox.Text) || string.IsNullOrEmpty(_surnameBox.Text) || !_genderMaleRadioButton.Checked && !_genderFemaleRadioButton.Checked ){
                MessageBox.Show(pleaseFillIntext);
                return;
            }
            else if (clientRadioButton.Checked && String.IsNullOrEmpty(_lengthBox.Text) || clientRadioButton.Checked && string.IsNullOrEmpty(_weightBox.Text))
            {
                MessageBox.Show(pleaseFillIntext);
                return;
            }

            var gender = _genderMaleRadioButton.Checked ? "m" : "f";

            bool succes;

            //TODO create user with given data, save into db
            //if (clientRadioButton.Checked)
            //    succes = _connection.SaveClient(_nameBox.Text, _surnameBox.Text, Usernamebox.Text, passwordBox.Text,  gender, dateOfBirthPicker.Value, Decimal.Parse(_lengthBox.Text), Decimal.Parse(_weightBox.Text));
            //else
            //    succes = _connection.saveSpecialist(_nameBox.Text, _surnameBox.Text, gender, Usernamebox.Text, passwordBox.Text, dateOfBirthPicker.Value);


            //if (succes)
            //{
            //    MessageBox.Show("Success: the user has been added.");
            //    this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("Could not add the user.");
            //}

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

        private void clientRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (clientRadioButton.Checked)
            {
                _lengthBox.Enabled = true;
                _weightBox.Enabled = true;
            }
            else
            {
                _lengthBox.Enabled = false;
                _weightBox.Enabled = false;
            }
        }
    }
}
