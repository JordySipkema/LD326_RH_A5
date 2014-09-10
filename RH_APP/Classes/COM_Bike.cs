﻿using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH_APP.Classes
{
    class COM_Bike : IBike
    {
        private SerialPort serial = null;

        public COM_Bike(String com_port) 
        {
            serial = new SerialPort();
            serial.PortName = com_port;
            serial.BaudRate = 9600;
            serial.Handshake = System.IO.Ports.Handshake.None;
            serial.Parity = Parity.None;
            serial.DataBits = 8;
            serial.StopBits = StopBits.One;
            serial.ReadTimeout = 2000;
            serial.WriteTimeout = 50;

            serial.Open();
        }

        public override Measurement RecieveData()
        {
            try
            {
                serial.WriteLine("ST");
                return base.ProtocolToMeasurement(serial.ReadLine());
            }
            catch (TimeoutException)
            {
                Console.WriteLine("Serialconnection timed out");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Operation Invalid \n" + e.Message);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid data!");
            }
            return null;
        }
        public override void SendData(string command)
        {
            serial.WriteLine(command);
        }

        /// <summary>
        /// Destructor for COM_Bike
        /// Closes the active serial connection to release resources
        /// </summary>
        ~COM_Bike()
        {
            serial.Close();
        }

    }
}
