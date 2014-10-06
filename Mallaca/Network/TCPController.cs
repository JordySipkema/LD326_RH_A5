using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Mallaca.Network;

namespace RH_APP.Controller
{
    // ReSharper disable once InconsistentNaming
    public class TCPController
    {
        private static TcpClient client;
        private static SslStream sslStream;
        public static Boolean Busy { get; private set; }

        public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
            {
                return true;
            }

            Console.WriteLine("Certificate error: {0}", sslPolicyErrors);

            // Do not allow this client to communicate with unauthenticated servers. 
            return false;
        }

        public static void runClient()
        {
            client = new TcpClient();
            client.BeginConnect(NetworkSettings.ServerIP, NetworkSettings.ServerPort, ConnectCallback, null);
            Console.WriteLine("Client connected...");
        }

        public static void stopClient()
        {
            if (client == null) return;
            client.Close();
            client = null;
            Console.WriteLine("Client closed...");
        }

        public static void Send(String data)
        {
            //Socket must be set to any instance....
            if (client == null)
            {
                runClient();
            }

            // Convert the string data to byte data using ASCII encoding.
            var byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data
            Busy = true;
            sslStream.BeginWrite(byteData, 0, byteData.Length, SendCallback, sslStream);
            sslStream.Flush();

            Console.WriteLine("Data sent: " + data);
        }

        private static void ConnectCallback(IAsyncResult ar)
        {
            sslStream = new SslStream(client.GetStream(), false, new RemoteCertificateValidationCallback(ValidateServerCertificate), null);

            try
            {
                sslStream.AuthenticateAsClient(NetworkSettings.ServerIP);
            }

            catch (AuthenticationException e)
            {
                Console.WriteLine("Exception: {0}", e.Message);

                if (e.InnerException != null)
                {
                    Console.WriteLine("Inner exception: {0}", e.InnerException.Message);
                }

                Console.WriteLine("Authentication failed - closing the connection.");

                stopClient();
            }
            var tcpclient = (TcpClient)ar.AsyncState;
            // Complete the connection.
            tcpclient.EndConnect(ar);

            // Signal that connected
            Console.WriteLine("TCPController: Connection active");

        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                //Retrieve the SslStream
                var sslstream = (SslStream)ar.AsyncState;

                //Complete sending the data to the remote device
                sslstream.EndWrite(ar);

                Busy = false;
                Console.WriteLine("Sent to server...");

            }

            catch (Exception e)
            {
                Console.WriteLine("ERROR!!" + e.ToString());
            }
        }
    }
}
