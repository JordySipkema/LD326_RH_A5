using System;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace Mallaca.Network
{
    // ReSharper disable once InconsistentNaming
    public class TCPController
    {
        private static TcpClient _client;
        private static SslStream _sslStream;
        public static Boolean Busy { get; private set; }

        public static void RunClient()
        {
            _client = new TcpClient();
            Busy = true;
            _client.Connect(NetworkSettings.ServerIP, NetworkSettings.ServerPort);
            Console.WriteLine("Client connected...");
        }

        public static void StopClient()
        {
            if (_client == null) return;
            _client.Close();
            _client = null;
            Console.WriteLine("Client closed...");
        }

        public static void Send(String data)
        {
            if (_client == null && !Busy)
            {
                RunClient();
            }
            else if (_client == null && Busy)
            {
                while (Busy)
                {
                    Thread.Sleep(10);
                }
            }

            // Convert the string data to byte data using ASCII encoding.
            var byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data
            Busy = true;
            _sslStream.BeginWrite(byteData, 0, byteData.Length, SendCallback, _sslStream);
            _sslStream.Flush();

            Console.WriteLine("Data sent: " + data);
        }

        private static void ConnectCallback(IAsyncResult ar)
        {
            // ReSharper disable once RedundantDelegateCreation
            _sslStream = new SslStream(_client.GetStream(), false,
                new RemoteCertificateValidationCallback(ValidateServerCertificate), null);

            try
            {
                _sslStream.AuthenticateAsClient(NetworkSettings.ServerIP);
            }

            catch (AuthenticationException e)
            {
                Console.WriteLine("Exception: {0}", e.Message);

                if (e.InnerException != null)
                {
                    Console.WriteLine("Inner exception: {0}", e.InnerException.Message);
                }

                Console.WriteLine("Authentication failed - closing the connection.");

                StopClient();
            }
            var tcpclient = (TcpClient)ar.AsyncState;
            // Complete the connection.
            tcpclient.EndConnect(ar);

            // Signal that connected
            Console.WriteLine("TCPController: Connection active");
            Busy = false;
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

            catch (Exception exception)
            {
                Console.WriteLine("ERROR!!: " + exception);
            }
        }

        private static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
            {
                return true;
            }

            Console.WriteLine("Certificate error: {0}", sslPolicyErrors);

            // Do not allow this client to communicate with unauthenticated servers.
            return false;
        }
    }
}