using Newtonsoft.Json.Linq;
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

        public static void StartClient()
        {
            // Connect to a remote device.
            try
            {
                // Establish the remote endpoint for the socket.
                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse("145.48.205.97"), 9001);//145.48.205.97

                // Create a TCP/IP socket.
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Connect to the remote endpoint.
                client.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), client);
                Console.WriteLine("Client connected...");


                // Release the socket.
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR!! " + e.ToString());
            }
        }

        public static void StopClient()
        {
            client.Shutdown(SocketShutdown.Both);
            client.Close();
            Console.WriteLine("Socket closed...");
        }

        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket
                Socket cl = (Socket)ar.AsyncState;

                // Complete the connection.
                cl.EndConnect(ar);

                // Signal that connected
                Console.WriteLine("Socket connected...");
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR!! " + e.ToString());
            }
        }

        public static void Send(String data)
        {
            // Convert the string data to byte data using ASCII encoding.
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data
            client.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), client);
            Console.WriteLine("Sent data: " + data);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket
                Socket cl = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = cl.EndSend(ar);
                Console.WriteLine("Sent to server...", bytesSent);

            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR!!" + e.ToString());
            }
        }

    }
}
