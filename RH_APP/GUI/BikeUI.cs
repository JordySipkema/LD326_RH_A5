using System;
using System.IO;
using System.Windows.Forms;
using RH_APP.Classes;
using RH_APP.Controller;

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
        }

        public RH_BIKE_GUI(IBike b)
        {
            _controller = new RH_Controller(b);
            _controller.UpdatedList += updateGUI;
            _writeToFile = false;
            InitializeComponent();
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

            if (!_writeToFile) return;
            var protoLine = _controller.LatestMeasurement.toProtocolString();
            _writer.WriteLine(protoLine);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            _controller.ChangeSpeed(numericUpDown1.Value);
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
    }
}
