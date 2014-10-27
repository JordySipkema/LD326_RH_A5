using System;

namespace Mallaca
{
    public class MeasurementEventArgs : EventArgs
    {
        public Measurement Measurement { get; private set; }

        public MeasurementEventArgs(Measurement m)
        {
            Measurement = m;
        }
    }
}
