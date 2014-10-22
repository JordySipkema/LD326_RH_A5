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
        private List<User> connectedClients = new List<User>();
        private readonly RH_Controller _controller;
        private readonly Specialist_Controller _spController;
        private bool _inTraining = true;
        private readonly IP_Bike _ipbike = new IP_Bike();

        public MainScreen(Boolean showSpecialistItems, IBike b)
        private readonly RH_Controller _controller; 
        private bool _inTraining = true;

        public MainScreen(Boolean showSpecialistItems, IBike b)
        {

            _controller = new RH_Controller(b);
            _controller.UpdatedList += updateGUI;

            InitializeComponent();
            _quitButton.Enabled = false;
            isSpecialist = showMenu;
            if (!showMenu)
            {
                menuStrip1.Visible = false;
                numericUpDown1.Visible = false;
                setPowerLabel.Visible = false;
            }
            ListPacket p = new ListPacket("connected_clients", Settings.GetInstance().authToken);
            TCPController.OnPacketReceived += handleIncomingPackets;
            TCPController.Send(p.ToString());

           // updateGraph();
        }

        private void startTraining(object sender, EventArgs e)
        {
            if (_inTraining)
                return;

            if (isSpecialist)
            {
                //send start packet to client
            }
            ListPacket p = new ListPacket("connected_clients", Settings.GetInstance().authToken);
            TCPController.OnPacketReceived += handleIncomingPackets;
            TCPController.Send(p.ToString());
        }

        private void _quitButton_Click(object sender, EventArgs e)
        {
            DialogResult dialog /*= dialog*/ = MessageBox.Show("Are you sure you want to stop the training?", "Alert", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                //this.Hide();            

                _inTraining = false;

                GraphResultUI resultUI = new GraphResultUI(_controller.GetList());

                resultUI.Show();
            }
        }


        public MainScreen(User client)
        {
            _spController = new Specialist_Controller();
            _spController.UpdatedList += updateGUI;

            InitializeComponent();
            isSpecialist = true;
            SubscribePacket subbie = new SubscribePacket(client.Username, true, Settings.GetInstance().authToken);

            ListPacket p = new ListPacket("connected_clients", Settings.GetInstance().authToken);
            TCPController.OnPacketReceived += handleIncomingPackets;
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

                addNewMessage(Settings.GetInstance().CurrentUser.Fullname, message);
                JObject json = new ChatPacket(message, "otto", Settings.GetInstance().authToken).ToJsonObject();
                TCPController.Send(json.ToString());
                _textBox.Text = "";
            }
        }

        private void addNewMessage(string name, string message)
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

        private void handleIncomingPackets(Packet p)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((new Action(() => handleIncomingPackets(p))));
                return;
            }

            Console.WriteLine("Packet: " + p.ToString());

            if (p is PullResponsePacket<User>)
            {
                PullResponsePacket<User> response = p as PullResponsePacket<User>;

                if (response.DataType == "connected_clients")
                    connectedClients = response.List;
            }
            else if (p is PullResponsePacket<Measurement>)
            {
                var response = p as PullResponsePacket<Measurement>;
                if (_spController == null)
                    return;

                foreach (var m in response.List)
	            {
		             _spController.SetMeasurement(m);
	            }
            }
            else if (p is ChatPacket)
            {
                ChatPacket chat = p as ChatPacket;
                addNewMessage(chat.UsernameDestination, chat.Message);

            }
        }

        private void connectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var p = new ListPacket("connected_clients", Settings.GetInstance().authToken);
            TCPController.OnPacketReceived += handleIncomingPackets;
            TCPController.Send(p.ToString());
            TCPController.ReceiveTransmission();

            var createScreen = new CreateConnectionScreen();
            createScreen.readClients(connectedClients);
            
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

	    public void updateGUI(object sender, EventArgs args)
        {
            if (_inTraining)
            {
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
            }

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
