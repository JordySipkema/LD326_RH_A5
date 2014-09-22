using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Mallaca;

namespace RH_APP.Classes
{
    class TXT_Bike : IBike
    {
        private int datacounter = 0;
        private List<Measurement> txtdata = new List<Measurement>();

        public TXT_Bike(string path) : base()
        {
            foreach (string line in File.ReadLines(path))
            {
                txtdata.Add(new Measurement(line));
            }
        }
        public override Measurement RecieveData()
        {
            Measurement m = txtdata.ElementAt(datacounter % txtdata.Count);
            ++datacounter;
            return m;
        }

        public override void SendData(string command)
        {
            throw new NotImplementedException();
        }
    }
}
