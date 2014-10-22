using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mallaca
{
    public class Measurement
    {
        private DateTime _date;
        private int _rpm = -1;
        private int _speed = -1;

        private int _distance = -1;
        public string currentAndCycleTime { get { return TIME + " / " + DATE.ToLongTimeString(); } }
        private string _time = "--:--";
        private int _powerpct = -1;
        private int _power = -1;
        private int _actPower = -1;
        private int _energy = -1;
        private int _pulse = -1;

        public int RPM
        {
            get { return _rpm; }
            set
            {
                _rpm = value;
            }
        }
        public DateTime DATE
        {
            get { return _date; }
            set
            {
                _date = value;
            }
        }
        public int SPEED
        {
            get { return _speed; }
            set
            {
                _speed = value;
            }
        }

        public int DISTANCE
        {
            get { return _distance; }
            set
            {
                _distance = value;
            }
        }

        public string TIME
        {
            get { return _time; }
            set
            {
                _time = value;
            }
        }

        public int POWERPCT
        {
            get { return _powerpct; }
            private set
            {
                _powerpct = value;
            }
        }

        public int POWER
        {
            get { return _power; }
            set
            {
                _power = value;
                this._powerpct = value * 100 / maxpower;
            }
        }

        public int ENERGY
        {
            get { return _energy; }
            set
            {
                _energy = value;
            }
        }

        public int ACT_POWER 
        {
            get { return _actPower; }
            set
            {
                _actPower = value;
            }
        }

        public int PULSE
        {
            get { return _pulse; }
            set
            {
                _pulse = value;
            }
        }


        private const int maxpower = 400;

        public Measurement()
        {
        }

        public Measurement(String protocolString)
        {
            String[] values = protocolString.Split('\t');

            if (values.Length == 9 || values.Length == 8)
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

                this.PULSE = pulse;
                this.RPM = rpm;
                this.SPEED = speed;
                this.DISTANCE = distance;
                this.POWER = despwr;
                this.ACT_POWER = actpwer;
                this.ENERGY = energy;
                this.TIME = time;

                if (values.Length == 9)
                {
                    this.DATE = DateTime.ParseExact(values[8], "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                }

            }
            else
            {
                throw new ArgumentException("Invalid protocoldata given, Expected either 8 or 9 parameters instead of " + values.Length);
            }
        }

        public void copy(Measurement m)
        {
            this.PULSE = m.PULSE;
            this.RPM = m.RPM;
            this.SPEED = m.SPEED;
            this.DISTANCE = m.DISTANCE;
            this.POWER = m.POWER;
            this.POWERPCT = m.POWERPCT;
            this.ACT_POWER = m.ACT_POWER;
            this.ENERGY = m.ENERGY;
            this.TIME = m.TIME;
            this.DATE = m.DATE;
        }

        public String toProtocolString()
        {

            String protocol = String.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}",
                PULSE, RPM, SPEED, DISTANCE, ACT_POWER, ENERGY, TIME, POWER, DATE.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            return protocol;
        }
    }
}