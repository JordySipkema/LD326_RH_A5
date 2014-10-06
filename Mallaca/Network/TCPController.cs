using System;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using Mallaca.Properties;
using Mallaca.Network.Packet;
namespace Mallaca.Network
{
    // State object for receiving data from remote device.
    public class StateObject
    {
        // Size of receive buffer.
        public const int BufferSize = 256;
        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];
        // Received data string.
        public StringBuilder sb = new StringBuilder();



    }

    // ReSharper disable once InconsistentNaming
    public class TCPController
    {
        private static TcpClient _client;
        private static SslStream _sslStream;
        public static Boolean Busy { get; private set; }
        private static string _response = String.Empty;
        public  delegate void ReceivedPacket(Packet.Packet p);
        public static event ReceivedPacket OnPacketReceived;

        private static ManualResetEvent sendDone =
            new ManualResetEvent(false);

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
            sendDone.Reset();
            if (_client == null)
                return;

            
            // Convert the string data to byte data using ASCII encoding.
            byte[] byteData = Encoding.ASCII.GetBytes(data);
            byte[] length = BitConverter.GetBytes(byteData.Length);

            // Begin sending the data
            Busy = true;
            _sslStream.BeginWrite(length, 0, 4, SendCallback, _sslStream);
            sendDone.WaitOne();
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
                sendDone.Set();
                
                Busy = false;
                Console.WriteLine("Sent to server...");

            }

            catch (Exception exception)
            {
                Console.WriteLine("ERROR!!: " + exception);
            }
        }


        public static void ReceiveTransmission()
        {
            try
            {
                // Create the state object.
                StateObject state = new StateObject();

                // Begin receiving the data from the remote device.
                _sslStream.BeginRead(state.buffer, 0, StateObject.BufferSize, new AsyncCallback(ReceiveCallback),
                    state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the state object and the client socket 
                // from the asynchronous state object.
                StateObject state = (StateObject)ar.AsyncState;
                

                // Read data from the remote device.
                int bytesRead = _sslStream.EndRead(ar);

                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));

                    if (state.sb.Length > 1)
                    {
                        _response += state.sb.ToString();


                        int length = Packet.Packet.getLengthOfPacket(_response);
                        if (length == -1)
                            return;
                        Packet.Packet p = Packet.Packet.RetrievePacket(length, ref  _response);
                        if (p == null)
                            return;
                        OnPacketReceived(p);


                        // Signal that all bytes have been received.
                    }

                    // Get the rest of the data.
                    // Begin receiving the data from the remote device.
                    _sslStream.BeginRead(state.buffer, 0, StateObject.BufferSize, new AsyncCallback(ReceiveCallback),
                        state);
                }

                // All the data has arrived; put it in response.
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
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