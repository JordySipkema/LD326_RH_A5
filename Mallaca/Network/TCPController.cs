using System;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using Mallaca.Properties;

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
            _client.Connect(NetworkSettings.ServerIP, NetworkSettings.ServerPort);

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

            // Signal that connected
            Console.WriteLine("TCPController: Connection active");
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
            if (_client == null)
                return;

            // Convert the string data to byte data using ASCII encoding.
            var byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data
            Busy = true;
            _sslStream.BeginWrite(byteData, 0, byteData.Length, SendCallback, _sslStream);
            _sslStream.Flush();

            Console.WriteLine("Data sent: " + data);
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
            var servercert = new X509Certificate2(Resources._23tia5_centificate, "AvansHogeschool23ti2a5");
            return certificate.Equals(servercert);
        }
    }
}