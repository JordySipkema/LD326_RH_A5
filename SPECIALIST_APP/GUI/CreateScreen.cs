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
            _connection.saveUser(_nameBox.Text, _surnameBox.Text, _genderBox.Text);
            this.Close();
        }

    }
}
