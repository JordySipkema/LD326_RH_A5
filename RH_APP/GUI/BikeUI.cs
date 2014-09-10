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

namespace RH_APP
{
    public partial class RH_BIKE_GUI : Form
    {
        Controller.RH_Controller controller = null;

        public RH_BIKE_GUI()
        {
            controller = new Controller.RH_Controller();
            controller.UpdatedList += updateGUI;
            InitializeComponent();
        }

        private void RH_BIKE_GUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void measurementBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        public void updateGUI(object sender, EventArgs args)
        {
            this.dataRPM.Text = controller.LatestMeasurement.RPM + "";
            this.dataSPEED.Text = String.Format("{0:0.0}", controller.LatestMeasurement.SPEED / 10.0);

            this.dataDISTANCE.Text = String.Format("{0:0.00}",controller.LatestMeasurement.DISTANCE / 10.0);
            this.dataPOWER.Text = controller.LatestMeasurement.POWER + "";
            this.dataPOWERPCT.Text = controller.LatestMeasurement.POWERPCT + "%";
            this.dataENERGY.Text = controller.LatestMeasurement.ENERGY + "";
            this.dataTIME.Text = controller.LatestMeasurement.TIME;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            controller.ChangeSpeed(numericUpDown1.Value);
        }


    }
}
