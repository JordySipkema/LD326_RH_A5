using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH_APP.Classes
{
    class Measurement
    {
        private int _rpm = -1;
        private int _speed = -1;

        private int _distance = -1;
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

        public void copy(Measurement m)
        {
            this.PULSE = m.PULSE;
            this.RPM = m.RPM;
            this.SPEED = m.SPEED;
            this.DISTANCE = m.DISTANCE;
            this.POWER = m.POWER;
            this.POWERPCT = m.POWERPCT;
            this.ENERGY = m.ENERGY;
            this.TIME = m.TIME;
        }
    }


}
