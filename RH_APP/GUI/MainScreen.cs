using Mallaca;
using Mallaca.Network;
using Mallaca.Usertypes;
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
using RH_APP.GUI;
using RH_APP.Classes;


namespace RH_APP.GUI
{
    public partial class MainScreen : Form
    {
        private Chat_Controller _chatController;
        private readonly RH_Controller _controller;
        public MainScreen(bool showElements, IBike b)
        {
            _controller = new RH_Controller(b);
            _controller.UpdatedList += updateGUI;
            
            InitializeComponent();

            if (!showElements)
            {
                menuStrip1.Visible = false;
                numericUpDown1.Visible = false;
                setPowerLabel.Visible = false;
            }
            
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

                Chat_Controller.SendMessage(message);

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

                    Chat_Controller.SendMessage(message);

                    _textBox.Text = "";
                }
            }
        }

        private void createConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void MainScreen_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_Click(object sender, EventArgs e)
        {
            _controller.SetPower((int)(numericUpDown1.Value));
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        public void updateGUI(object sender, EventArgs args)
        {
            //while (true)
            {
                //dataRPM.Text = _controller.LatestMeasurement.RPM + "";
                dataSPEED.Text = String.Format("{0:0.0}", _controller.LatestMeasurement.SPEED / 10.0);
                dataDISTANCE.Text = String.Format("{0:0.00}", _controller.LatestMeasurement.DISTANCE / 10.0);
                dataPOWER.Text = _controller.LatestMeasurement.POWER + "";
                dataPOWERPCT.Text = _controller.LatestMeasurement.POWERPCT + "%";
                dataENERGY.Text = _controller.LatestMeasurement.ENERGY + "";
                dataTIME.Text = _controller.LatestMeasurement.TIME;
                dataPULSE.Text = _controller.LatestMeasurement.PULSE + "";

                //if (!_writeToFile) return;
                //var protoLine = _controller.LatestMeasurement.toProtocolString();
                //_writer.WriteLine(protoLine);
            }

        }
    }
}
