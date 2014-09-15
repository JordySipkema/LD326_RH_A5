using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH_APP.Controller
{
    class RH_Controller
    {
        private Classes.IBike bike = null;
        private BackgroundWorker bw = new BackgroundWorker();
        private List<Classes.Measurement> data = new List<Classes.Measurement>();

        public Classes.Measurement LatestMeasurement
        {
            get
            {
                Classes.Measurement m = new Classes.Measurement();
                try
                {
                    return data.Last();
                }
                catch (InvalidOperationException) { }
                return m;
            }
        }

        public RH_Controller(Classes.IBike b)
        {
            //bike = new Classes.COM_Bike("COM3");
            //bike = new Classes.STUB_Bike();
            bike = b;
            InitializeBackgroundWorker();
            bw.RunWorkerAsync();

        }

        public void ChangeSpeed(decimal speed)
        {
            int speed_int = Convert.ToInt32(speed);
            bike.SendData(String.Format("PW {0}", speed_int));
        }

        public event EventHandler UpdatedList;

        private void OnUpdatedList(EventArgs e)
        {
            EventHandler handler = UpdatedList;
            if (handler != null)
            {
                handler(this, e);
            }
        }


        public void WriteAllDataToFile()
        {
            bw.CancelAsync();
            String filepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (StreamWriter writer = new StreamWriter(filepath + "\\RH_DATA.txt", append: false))
            {
                foreach (var measurement in data)
                {
                    writer.WriteLine(measurement.toProtocolString());
                }
                writer.Flush();
            }

        }

        private void InitializeBackgroundWorker()
        {
            bw.WorkerSupportsCancellation = true;
            // Attach event handlers to the BackgroundWorker object.
            bw.DoWork +=
                new System.ComponentModel.DoWorkEventHandler(BackgroundWorker_DoWork);
            bw.RunWorkerCompleted +=
                new System.ComponentModel.RunWorkerCompletedEventHandler(BackgroundWorker_RunWorkerCompleted);
        }

        private void BackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(200);
            Classes.Measurement m = bike.RecieveData();
            e.Result = m;
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            // Access the result through the Result property. 
            // But first be sure that e.Result is a Measurement instance.
            if (e.Result is Classes.Measurement)
            {
                Classes.Measurement m = (Classes.Measurement)e.Result;
                this.data.Add(m);
                OnUpdatedList(EventArgs.Empty);
            }
            if (!((BackgroundWorker)sender).CancellationPending)
            {
                bw.RunWorkerAsync();
            }
        }

    }
}
