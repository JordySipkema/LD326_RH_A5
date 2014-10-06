using System;
using System.IO;
using System.Windows.Forms;
using Mallaca.Network;
using RH_APP.Classes;
using RH_APP.Controller;
using System.Drawing;


namespace RH_APP.GUI
{
    public partial class RH_BIKE_GUI : Form
    {
        private readonly RH_Controller _controller;
        private bool _writeToFile;
        private StreamWriter _writer;

        public RH_BIKE_GUI(IBike b, string path)
        {

            _controller = new RH_Controller(b);
            _controller.UpdatedList += updateGUI;

            _writeToFile = true;
            InitializeComponent();
            writeRealTime(path);

            updateGraph();
        }

        public RH_BIKE_GUI(IBike b)
        {
            _controller = new RH_Controller(b);
            _controller.UpdatedList += updateGUI;
            _writeToFile = false;
            InitializeComponent();

            updateGraph();
        }

        public void writeRealTime(string file)
        {
            if (File.Exists(file))
                _writer = File.CreateText(file);
            else
                _writer = File.AppendText(file);
            _writer.AutoFlush = true;
            _writeToFile = true;
        }

        private void RH_BIKE_GUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            _controller.FormClosing();
            Application.Exit();
        }

        public void updateGraph()
        {

            _graph.Series["RPM"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            _graph.Series["RPM"].Color = Color.Blue;
            _graph.Series["RPM"].Points.AddXY(_controller.LatestMeasurement.TIME, _controller.LatestMeasurement.RPM);

            

            _graph.ChartAreas[0].AxisY.Maximum = 200;
            _graph.ChartAreas[0].AxisY.Minimum = 0;
            //_graph.Series["PULSE"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            //_graph.Series["PULSE"].Color = Color.Green;
            //_graph.Series["PULSE"].Points.AddY(_controller.LatestMeasurement.PULSE);
        }

        public void updateGUI(object sender, EventArgs args)
        {
            dataRPM.Text = _controller.LatestMeasurement.RPM + "";
            dataSPEED.Text = String.Format("{0:0.0}", _controller.LatestMeasurement.SPEED / 10.0);
            dataDISTANCE.Text = String.Format("{0:0.00}", _controller.LatestMeasurement.DISTANCE / 10.0);
            dataPOWER.Text = _controller.LatestMeasurement.POWER + "";
            dataPOWERPCT.Text = _controller.LatestMeasurement.POWERPCT + "%";
            dataENERGY.Text = _controller.LatestMeasurement.ENERGY + "";
            dataTIME.Text = _controller.LatestMeasurement.TIME;
            dataPULSE.Text = _controller.LatestMeasurement.PULSE + "";

            updateGraph();

            if (!_writeToFile) return;
            var protoLine = _controller.LatestMeasurement.toProtocolString();
            _writer.WriteLine(protoLine);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int value = (int)numericUpDown1.Value;
            _controller.SetPower(value);
        }

        ~RH_BIKE_GUI()
        {
            _controller.UpdatedList -= updateGUI;
            if (_writer != null)
            {
                _writer.Flush();
                _writer.Dispose();
            }
        }

        public void receiveMessage()
        {
            //Nog implementeren
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
    }
}
