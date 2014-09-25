
using Mallaca;
using RH_APP.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mallaca;
namespace RH_APP.Controller
{
// ReSharper disable once InconsistentNaming
    class RH_Controller
    {
        private readonly IBike _bike;
        private readonly BackgroundWorker _bw = new BackgroundWorker();
        private readonly List<Measurement> _data = new List<Measurement>();

        public Measurement LatestMeasurement
        {
            get
            {
                var m = new Measurement();
                try
                {
                    return _data.Last();
                }
                catch (InvalidOperationException) { }
                return m;
            }
        }

        public RH_Controller(IBike b)
        {
            //bike = new Classes.COM_Bike("COM3");
            //bike = new Classes.STUB_Bike();
            _bike = b;
            InitializeBackgroundWorker();
            _bw.RunWorkerAsync();

        }

        public void ChangeSpeed(decimal speed)
        {
            var speedInt = Convert.ToInt32(speed);
            _bike.SendData(String.Format("PW {0}", speedInt));
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
            _bw.CancelAsync();
            var filepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (var writer = new StreamWriter(filepath + "\\RH_DATA.txt", append: false))
            {
                foreach (var measurement in _data)
                {
                    writer.WriteLine(measurement.toProtocolString());
                }
                writer.Flush();
            }

        }

        private void SendToServer(object sender, EventArgs args)
        {
            string json = JsonConvert.SerializeObject(this.LatestMeasurement);
            Classes.Client.Send(json);
            Console.Write(json);

        }

        private void InitializeBackgroundWorker()
        {
            _bw.WorkerSupportsCancellation = true;
            // Attach event handlers to the BackgroundWorker object.
            _bw.DoWork += BackgroundWorker_DoWork;
            _bw.RunWorkerCompleted +=  BackgroundWorker_RunWorkerCompleted;
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(800);
            var m = _bike.RecieveData();
            e.Result = m;
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Access the result through the Result property. 
            // But first be sure that e.Result is a Measurement instance.
            var result = e.Result as Measurement;
            if (result != null)
            {
                _data.Add(result);
                OnUpdatedList(EventArgs.Empty);
            }
            if (!((BackgroundWorker)sender).CancellationPending)
            {
                _bw.RunWorkerAsync();
            }
        }

    }
}
