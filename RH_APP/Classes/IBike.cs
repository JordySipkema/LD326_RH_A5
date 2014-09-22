using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mallaca;
namespace RH_APP.Classes
{
    public abstract class IBike
    {
        public Measurement Measurement { get; set; }

        public abstract Measurement RecieveData();

        public abstract void SendData(String command);

        protected Measurement ProtocolToMeasurement(String protocolData)
        {
            String[] values = protocolData.Split('\t');

            Measurement measurement = new Measurement();

            if (values.Length == 8)
            {
                int pulse = -1;
                int rpm = -1;
                int speed = -1;
                int distance = -1;
                int despwr = -1;
                int energy = -1;
                int actpwer = -1;

                Int32.TryParse(values[0], out pulse);
                Int32.TryParse(values[1], out rpm);
                Int32.TryParse(values[2], out speed);
                Int32.TryParse(values[3], out distance);
                Int32.TryParse(values[4], out actpwer);
                Int32.TryParse(values[5], out energy);
                String time = values[6];
                Int32.TryParse(values[7], out despwr);

                measurement.PULSE = pulse;
                measurement.RPM = rpm;
                measurement.SPEED = speed;
                measurement.DISTANCE = distance;
                measurement.POWER = despwr;
                measurement.ACT_POWER = actpwer;
                measurement.ENERGY = energy;
                measurement.TIME = time;

            }
            else
            {
                throw new ArgumentException("Invalid protocoldata given, Expected 8 parameters instead of "+values.Length);
            }
            return measurement;
        }
    }
}
