using System.IO.Ports;
using System.Threading;
using Mallaca;
using Mallaca.Network;
using Mallaca.Network.Packet;
using Mallaca.Network.Packet.Request;
using Mallaca.Network.Packet.Response;
using Mallaca.Usertypes;
using Newtonsoft.Json.Linq;
using RH_APP.Classes;
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


namespace RH_APP.GUI
{
    public partial class MainScreen : Form
    {
        private Chat_Controller _chatController;
        private Specialist_Controller _spController;
        private RH_Controller _controller; 
        private bool _inTraining = false;
        private bool isSpecialist;
        private User client;

        public MainScreen(Boolean showSpecialistItems)
        {

            TCPController.OnPacketReceived += HandleIncomingPackets;
           

            InitializeComponent();
            _quitButton.Enabled = false;
            isSpecialist = showSpecialistItems;
            if (!isSpecialist)
            {
                menuStrip1.Visible = false;
                numericUpDown1.Visible = false;
                setPowerLabel.Visible = false;
                
            }

            // updateGraph();
        }

        private void startTraining(object sender, EventArgs e)
        {
            if (_inTraining)
                return;
            _inTraining = true;

            if (isSpecialist)
            {
                _spController = new Specialist_Controller();
            }
            else
            {
                //var port = getCOMPort();
                //if (port == null)
                //{
                //    MessageBox.Show("No COM port found. Please connect your pc to a Kettler x700");
                //    return;
                //}
                //_controller = new RH_Controller(new COM_Bike(port), true);
                _controller = new RH_Controller(new STUB_Bike(), true);
                _controller.UpdatedList += UpdateGUI;
            }
            startTrainingButton.Enabled = false;
            _quitButton.Enabled = true;

        }

        private void _quitButton_Click(object sender, EventArgs e)
        {

            //this.Hide();            
            //_controller.UpdatedList -= updateGUI;
            _controller.Stop();
            TCPController.Send(new EndTrainingPacket(Settings.GetInstance().authToken));
            _inTraining = false;
                
            
        }


        public MainScreen(User client)
        {
            this.client = client;
            _spController = new Specialist_Controller();
            _spController.UpdatedList += UpdateGUI;

            InitializeComponent();
            isSpecialist = true;
            SubscribePacket subbie = new SubscribePacket(client.Username, true, Settings.GetInstance().authToken);

            ListPacket p = new ListPacket("connected_clients", Settings.GetInstance().authToken);
            TCPController.OnPacketReceived += HandleIncomingPackets;
            TCPController.Send(p.ToString());

            TCPController.Send(subbie.ToString());


            // updateGraph();
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
            if ( String.IsNullOrWhiteSpace( _textBox.Text ))
                return;
            else
            {

                String message = _textBox.Text;

                AddNewMessage(Settings.GetInstance().CurrentUser.Fullname, message);

                string destination;
                if (isSpecialist)
                    destination = client.Username;
                else
                    destination = "";


                JObject json = new ChatPacket(message, destination, Settings.GetInstance().authToken).ToJsonObject();
                TCPController.Send(json.ToString());
                _textBox.Text = "";
            }
        }

        private void AddNewMessage(string name, string message)
        {
            _chatLogBox.AppendText(name + ": " + message);
            _chatLogBox.AppendText(Environment.NewLine);
        }

        private void _textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                _sendButton_Click(this, EventArgs.Empty);
            }
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void MainScreen_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_Click(object sender, EventArgs e)
        {
            
            _controller.SetPower((int)(numericUpDown1.Value));
        }

        private void HandleIncomingPackets(Packet p)
        {
            if (InvokeRequired)
            {
                Invoke((new Action(() => HandleIncomingPackets(p))));
                return;
            }

            if (p is DataFromClientPacket<Measurement>)
            {
                var response = p as DataFromClientPacket<Measurement>;
                
                if(response.ClientId != client.Id)
                    return;
                if (_spController == null)
                    startTraining(this, EventArgs.Empty);


                foreach (var m in response.List)
	            {
		             _spController.SetMeasurement(m);
                    Console.WriteLine("Received a measurement.");
	            }
            }
            else if (p is ChatPacket)
            {
                var chat = p as ChatPacket;
                if (client != null && chat.UsernameDestination != client.Username)
                    return;
                AddNewMessage(chat.UsernameDestination, chat.Message);

            }
        }

        private void connectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var createScreen = new CreateConnectionScreen();
            
            createScreen.ShowDialog();
        }

        private void loadClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var measurementScreen = new SelectMeasurementScreen();
            measurementScreen.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

// ReSharper disable once InconsistentNaming
	    public void UpdateGUI(object sender, EventArgs args)
        {
	        if (!_inTraining) return;


	        dataRPM.Text = _controller.LatestMeasurement.RPM + "";
	        dataSPEED.Text = String.Format("{0:0.0}", _controller.LatestMeasurement.SPEED / 10.0);
	        dataDISTANCE.Text = String.Format("{0:0.00}", _controller.LatestMeasurement.DISTANCE / 10.0);
	        dataPOWER.Text = _controller.LatestMeasurement.POWER + "";
	        dataPOWERPCT.Text = _controller.LatestMeasurement.POWERPCT + "%";
	        dataENERGY.Text = _controller.LatestMeasurement.ENERGY + "";
	        dataTIME.Text = _controller.LatestMeasurement.TIME;
	        dataPULSE.Text = _controller.LatestMeasurement.PULSE + "";

	        dataRPM.Refresh();
	        dataSPEED.Refresh();
	        dataDISTANCE.Refresh();
	        dataPOWER.Refresh();
	        dataPOWERPCT.Refresh();
	        dataENERGY.Refresh();
	        dataTIME.Refresh();
	        dataPULSE.Refresh();
	        numericUpDown1.Refresh();

	        updateGraph();

	        //if (!_writeToFile) return;
                //var protoLine = _controller.LatestMeasurement.toProtocolString();
                //_writer.WriteLine(protoLine);
     

        }
            public void updateGraph()
            {
                try
                {
                    _graph.Series["SPEED"].Points.AddXY(_controller.LatestMeasurement.currentAndCycleTime, _controller.LatestMeasurement.SPEED / 10.0);

                    _graph.Series["PULSE"].Points.AddXY(_controller.LatestMeasurement.currentAndCycleTime, _controller.LatestMeasurement.PULSE);
                }
                catch (NullReferenceException)
                {
                    //TODO 
                    Console.WriteLine("Mainscreen.updateGraph(): Code werkt nog niet met specialist blijkbaar!");
                }

            }

            private string getCOMPort()
            {

                var portNames = SerialPort.GetPortNames();
                foreach (string i in portNames)
                {
                    var serial = new SerialPort();
                    serial.PortName = i;

                    serial.DataBits = 8;
                    serial.StopBits = StopBits.One;
                    serial.ReadTimeout = 2000;
                    serial.WriteTimeout = 50;

                    serial.Open();

                    serial.WriteLine("ID");
                    var output = serial.ReadLine();
                    if (!String.IsNullOrEmpty(output))
                    {
                        serial.WriteLine("RS");
                        Thread.Sleep(10);
                        serial.Close();
                        return i;
                    }
                }
                return null;

            }

    }
}
