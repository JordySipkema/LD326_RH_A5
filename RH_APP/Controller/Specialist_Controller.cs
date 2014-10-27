using Mallaca;
using Mallaca.Network;
using Mallaca.Network.Packet;
using Mallaca.Network.Packet.Request;
using Newtonsoft.Json.Linq;
using RH_APP.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH_APP.Controller
{
    class Specialist_Controller
    {
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

        public void SetMeasurement(Measurement m)
        {
            _data.Add(m);
            OnUpdatedList(new MeasurementEventArgs(m));
        }

        public void SetPower(int power, String username)
        {
            Console.WriteLine("Setpower in SP CTRL");
            Packet p = new PushPacket<Configuaration>(PushPacket<Configuaration>.DataType.Configuration,
                new List<Configuaration> {
                    new Configuaration { Power = power, Username = username }
                },
                Settings.GetInstance().authToken);
            Console.WriteLine("Sending \n {0}", p);
            TCPController.Send(p);
        }

        public event EventHandler UpdatedList;

        private void OnUpdatedList(MeasurementEventArgs e)
        {
            var handler = UpdatedList;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void WriteAllDataToFile()
        {
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

        public List<Measurement> GetList()
        {
            return _data;
        }

        public void FormClosing()
        {
            var jsonObject = new JObject(new JProperty("CMD", "dc"));
            var json = jsonObject.ToString();
            
            TCPController.Send(json);
        }

    }
}
