using RH_APP.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RH_APP
{
    public partial class RH_BIKE_GUI : Form
    {
        Controller.RH_Controller controller = null;
        bool writeToFile;
        StreamWriter writer;


        public RH_BIKE_GUI(IBike b, string path)
        {

            controller = new Controller.RH_Controller(b);
            controller.UpdatedList += updateGUI;
            writeToFile = true;
            InitializeComponent();
            writeRealTime(path);
        }

        public RH_BIKE_GUI(IBike b)
        {
            controller = new Controller.RH_Controller(b);
            controller.UpdatedList += updateGUI;
            writeToFile = false;
            InitializeComponent();
            Classes.Client.StartClient();
            Console.WriteLine("Client started...");


        }

        public void writeRealTime(string file)
        {
            if (File.Exists(file))
                writer = File.CreateText(file);
            else
                writer = File.AppendText(file);
            writer.AutoFlush = true;
            writeToFile = true;
        }

        private void RH_BIKE_GUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            controller.FormClosing();
            Classes.Client.StopClient();
            Console.WriteLine("Client disconnected...");
            Application.Exit();
        }

        private void measurementBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        public void updateGUI(object sender, EventArgs args)
        {
            this.dataRPM.Text = controller.LatestMeasurement.RPM + "";
            this.dataSPEED.Text = String.Format("{0:0.0}", controller.LatestMeasurement.SPEED / 10.0);
            this.dataDISTANCE.Text = String.Format("{0:0.00}", controller.LatestMeasurement.DISTANCE / 10.0);
            this.dataPOWER.Text = controller.LatestMeasurement.POWER + "";
            this.dataPOWERPCT.Text = controller.LatestMeasurement.POWERPCT + "%";
            this.dataENERGY.Text = controller.LatestMeasurement.ENERGY + "";
            this.dataTIME.Text = controller.LatestMeasurement.TIME;
            this.dataPULSE.Text = controller.LatestMeasurement.PULSE + "";

            if (writeToFile)
            {
                string protoLine = controller.LatestMeasurement.toProtocolString();
                writer.WriteLine(protoLine);

            }

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            controller.ChangeSpeed(numericUpDown1.Value);
        }

        ~RH_BIKE_GUI()
        {
            controller.UpdatedList -= updateGUI;
            if (writer != null)
                writer.Flush();
            writer.Dispose();
        }

        private void RH_BIKE_GUI_Load(object sender, EventArgs e)
        {

        }

        private void RH_BIKE_GUI_Load_1(object sender, EventArgs e)
        {

        }
    }
}
