using Mallaca.Network;
using RH_APP.Controller;
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
    public partial class MainScreen : Form
    {
        private Chat_Controller _chatController;


        public MainScreen()
        {
            InitializeComponent();
            _chatController = new Chat_Controller();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This application is made by Group 23TI2A5! \n Farid Amali \n Jordy Sipkema \n Engin Can \n George de Coo \n Kevin van den Akkerveken \n Gerjan Holsappel ");
        }

        private void MainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = dialog = MessageBox.Show("Do you really want to close the program?", "Alert", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Application.ExitThread();
            }
            else if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateScreen _createScreen = new CreateScreen();
            _createScreen.ShowDialog();
        }

        private void _sendButton_Click(object sender, EventArgs e)
        {
            if (_textBox.Text == "")
            {
                MessageBox.Show("No message has been sent");
            }
            else
            {

                String message = _textBox.Text;

                _chatLogBox.AppendText("You say: " + message);
                _chatLogBox.AppendText(Environment.NewLine);

                _chatController.SendMessage(message);

                _textBox.Text = "";
            }
        }

        private void _textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (_textBox.Text == "")
                {
                    MessageBox.Show("No message has been sent");
                }
                else
                {

                    String message = _textBox.Text;

                    _chatLogBox.AppendText("You say: " + message);
                    _chatLogBox.AppendText(Environment.NewLine);

                    _chatController.SendMessage(message);

                    _textBox.Text = "";
                }
            }
        }
    }
}
