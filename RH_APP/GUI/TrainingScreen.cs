using System.IO.Ports;
using System.Linq;
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
using System.Windows.Forms;


namespace RH_APP.GUI
{
    public partial class TrainingScreen : Form
    {
        private Chat_Controller _chatController;
        private Specialist_Controller _spController;
        private RH_Controller _controller;
        private bool _inTraining = false;
        private bool isSpecialist;
        private User client;
        private int currentTraingId = -1;

        public TrainingScreen(Boolean showSpecialistItems)
        {

            TCPController.OnPacketReceived += HandleIncomingPackets;

            InitializeComponent();
            _quitButton.Enabled = false;
            isSpecialist = showSpecialistItems;
            if (!isSpecialist)
            {
                numericUpDown1.Visible = false;
                setPowerLabel.Visible = false;
                broadcastCheckbox.Visible = false;
                startTrainingButton.Visible = false;
                _quitButton.Visible = false;
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
                TCPController.Send(new NotifyPacket(NotifyPacket.Subject.StartTraining, client.NonNullId.ToString(), Settings.GetInstance().authToken));
                _spController = new Specialist_Controller();
                _spController.UpdatedList += UpdateGUI;

            }
            else
            {
                var port = getCOMPort();
                if (port == null)
                {
                    MessageBox.Show("No COM port found. Please connect your pc to a Kettler x7");
                    return;
                }
                _controller = new RH_Controller(new COM_Bike(port), true);

                //_controller = new RH_Controller(new STUB_Bike(), true);
                _controller.UpdatedList += UpdateGUI;
            }
            startTrainingButton.Enabled = false;
            _quitButton.Enabled = true;

        }

        private void _quitButton_Click(object sender, EventArgs e)
        {

            //this.Hide();            
            //_controller.UpdatedList -= updateGUI;
            if (_controller != null)
                _controller.Stop();

            if (isSpecialist)
            {
                TCPController.Send(new NotifyPacket(NotifyPacket.Subject.StopTraining, client.NonNullId.ToString(),
                    Settings.GetInstance().authToken));
                this.Hide();

                DBConnect db = new DBConnect();

                int id;
                if (isSpecialist)
                    id = client.NonNullId;
                else
                {
                    id = Settings.GetInstance().CurrentUser.NonNullId;
                }

                GraphResultUI g = new GraphResultUI(db.getMeasurementsOfUser(id.ToString(), currentTraingId.ToString()));
                g.Show();
            }

            _inTraining = false;


        }


        public TrainingScreen(User client)
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

        private void TrainingScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult dialog = dialog = MessageBox.Show("Do you really want to close the program?", "Alert", MessageBoxButtons.YesNo);
            //if (dialog == DialogResult.Yes)
            //{
            //    Application.ExitThread();
            //}
            //else if (dialog == DialogResult.No)
            //{
            //    e.Cancel = true;
            //}
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateScreen _createScreen = new CreateScreen();
            _createScreen.ShowDialog();
        }

        private void _sendButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(_textBox.Text))
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

                JObject json = new ChatPacket(message, destination, Settings.GetInstance().authToken, broadcastCheckbox.Checked).ToJsonObject();
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

        private void TrainingScreen_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_Click(object sender, EventArgs e)
        {
            var power = (int)numericUpDown1.Value;

            if (_controller != null)
                _controller.SetPower(power);

            if (_spController != null)
                _spController.SetPower(power, client.Username);
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

                if (response.ClientId != client.Id)
                    return;
                if (_spController == null)
                    startTraining(this, EventArgs.Empty);


                foreach (var m in response.List)
                {
                    _spController.SetMeasurement(m);
                    //Console.WriteLine("Received a measurement.");
                }
            }
            else if (p is ChatPacket)
            {
                var chat = p as ChatPacket;

                if (chat.IsBroadcast)
                {
                    AddNewMessage("<Broadcast> " + chat.UsernameDestination, chat.Message);
                    return;
                }
                if (client != null && chat.UsernameDestination != client.Username)
                    return;
                AddNewMessage(chat.UsernameDestination, chat.Message);

            }
            else if (p is PushPacket<Configuaration>)
            {
                var ppacket = p as PushPacket<Configuaration>;
                var config = ppacket.DataSource.FirstOrDefault();
                if (config == null)
                    return;

                if (config.Power.HasValue && _controller != null)
                {
                    _controller.SetPower(config.Power.Value);
                }
            }
            else if (p is NotifyPacket)
            {
                var traitor = p as NotifyPacket;
                if (traitor.NotifySubject == NotifyPacket.Subject.NewTrainingId)
                {
                    if (isSpecialist && int.Parse(traitor.SecundaryValue) == client.Id)
                    {
                        currentTraingId = int.Parse(traitor.PrimaryValue);
                    }
                    else
                        currentTraingId = int.Parse(traitor.PrimaryValue);
                }
                else if (traitor.NotifySubject == NotifyPacket.Subject.StartTraining)
                {
                    startTraining(this, EventArgs.Empty);
                }
                else if (traitor.NotifySubject == NotifyPacket.Subject.StopTraining)
                {
                    _quitButton_Click(this, EventArgs.Empty);
                }
            }

            string b = "";
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

            var eventargs = args as MeasurementEventArgs;
            if (eventargs == null)
                return;

            dataRPM.Text = eventargs.Measurement.RPM + "";
            dataSPEED.Text = String.Format("{0:0.0}", eventargs.Measurement.SPEED / 10.0);
            dataDISTANCE.Text = String.Format("{0:0.00}", eventargs.Measurement.DISTANCE / 10.0);
            dataPOWER.Text = eventargs.Measurement.POWER + "";
            dataPOWERPCT.Text = eventargs.Measurement.POWERPCT + "%";
            dataENERGY.Text = eventargs.Measurement.ENERGY + "";
            dataTIME.Text = eventargs.Measurement.TIME;
            dataPULSE.Text = eventargs.Measurement.PULSE + "";

            dataRPM.Refresh();
            dataSPEED.Refresh();
            dataDISTANCE.Refresh();
            dataPOWER.Refresh();
            dataPOWERPCT.Refresh();
            dataENERGY.Refresh();
            dataTIME.Refresh();
            dataPULSE.Refresh();
            numericUpDown1.Refresh();

            updateGraph(eventargs);

            //if (!_writeToFile) return;
            //var protoLine = _controller.LatestMeasurement.toProtocolString();
            //_writer.WriteLine(protoLine);


        }
        public void updateGraph(MeasurementEventArgs args)
        {
            try
            {
                _graph.Series["SPEED"].Points.AddXY(args.Measurement.currentAndCycleTime, args.Measurement.SPEED / 10.0);

                _graph.Series["PULSE"].Points.AddXY(args.Measurement.currentAndCycleTime, args.Measurement.PULSE);
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
