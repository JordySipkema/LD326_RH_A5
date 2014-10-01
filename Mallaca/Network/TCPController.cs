using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RH_APP.Controller
{
// ReSharper disable once InconsistentNaming
    public class TCPController
    {
        private static Socket _socket;
        public static Boolean Busy { get; private set; }

        public static void StartConnection()
        {
            // Connect to a remote device.
            try
            {
                // Establish the remote endpoint for the socket.
                var remoteEP = new IPEndPoint(IPAddress.Parse("10.0.1.11"), 9001);//145.48.205.97

                // Create a TCP/IP socket.
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Connect to the remote endpoint.
                _socket.BeginConnect(remoteEP, ConnectCallback, _socket);
                Console.WriteLine("Client connected...");


                // Release the socket.
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR!! " + e.ToString());
            }
        }

        public static void StopConnection()
        {
            if (_socket == null) return;

            _socket.Shutdown(SocketShutdown.Both);
            _socket.Disconnect(false);
            _socket = null;
            Console.WriteLine("Socket closed...");
        }

        public static void Send(String data)
        {
            //Socket must be set to any instance....
            if (_socket == null) return;

            // Convert the string data to byte data using ASCII encoding.
            var byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data
            Busy = true;
            _socket.BeginSend(byteData, 0, byteData.Length, 0,SendCallback, _socket);
            Console.WriteLine("Sent data: " + data);
        }

        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket
                var socket = (Socket)ar.AsyncState;

                // Complete the connection.
                socket.EndConnect(ar);

                // Signal that connected
                Console.WriteLine("TCPController: Connection active");
            }
            catch (Exception e)
            {
                Console.WriteLine("TCPController ERROR!! \n" + e.ToString());
            }
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket
                var cl = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                var bytesSent = cl.EndSend(ar);
                Busy = false;
                Console.WriteLine("Sent to server...", bytesSent);

            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR!!" + e.ToString());
            }
        }

    }
}
