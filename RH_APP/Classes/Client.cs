using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RH_APP.Classes
{
    public class Client
    {
        private static Socket client;
        private static ManualResetEvent connectDone = new ManualResetEvent(false);
        private static ManualResetEvent sendDone = new ManualResetEvent(false);

        public static void StartClient()
        {
            // Connect to a remote device.
            try
            {
                // Establish the remote endpoint for the socket.
                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse("192.168.1.12"), 9001);//145.48.205.97

                // Create a TCP/IP socket.
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Connect to the remote endpoint.
                client.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), client);
                connectDone.WaitOne();
                Console.WriteLine("Client connected...");


                // Release the socket.
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void StopClient()
        {
            client.Shutdown(SocketShutdown.Both);
            client.Close();
        }

        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket cl = (Socket)ar.AsyncState;

                // Complete the connection.
                cl.EndConnect(ar);

                // Signal that connected
                connectDone.Set();
                Console.WriteLine("Socket connected...");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void Send(String data)
        {
            // Convert the string data to byte data using ASCII encoding.
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.
            client.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), client);
            sendDone.WaitOne();
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket cl = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = cl.EndSend(ar);
                // Signal that all bytes have been sent.
                sendDone.Set();
                Console.WriteLine("Sent to server...", bytesSent);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

    }
}
