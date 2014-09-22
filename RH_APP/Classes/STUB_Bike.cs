using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mallaca;
namespace RH_APP.Classes
{
    class STUB_Bike : IBike
    {
        private DateTime _startTime = DateTime.Now;

        public override Measurement RecieveData()
        {
            TimeSpan runningTime = DateTime.Now.Subtract(_startTime); 

            Measurement m = new Measurement();
            m.DISTANCE = new Random().Next(0, 100);
            m.ENERGY = 25;
            m.POWER = 25;
            m.PULSE = 0;
            m.RPM = new Random().Next(24, 80);
            m.SPEED = new Random().Next(12, 50);
            m.TIME = String.Format("{0:00}:{1:00}", runningTime.Minutes, runningTime.Seconds);
            m.DATE = DateTime.Now;
            return m;
        }

        public override void SendData(string command)
        {
            throw new NotImplementedException();
        }
    }
}
