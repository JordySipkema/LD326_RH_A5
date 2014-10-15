using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using Mallaca.Properties;
using Mallaca.Network.Packet;
using Newtonsoft.Json.Linq;

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

        public delegate void ReceivedPacket(Packet.Packet p);
        public static event ReceivedPacket PacketReceived;

        public static bool IsReading { get; private set; }
        private static  List<byte> _totalBuffer = new List<byte>();
        private static ManualResetEvent sendDone =
            new ManualResetEvent(false);

        public static void RunClient()
        {
            IsReading = false;
            _client = new TcpClient();
            _client.Connect(NetworkSettings.ServerIP, NetworkSettings.ServerPort);

            _totalBuffer = new List<byte>();

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

            // Begin sending the data
            Busy = true;
            byte[] bytes = Packet.Packet.CreateByteData(data);
            _sslStream.BeginWrite(bytes, 0, bytes.Length, SendCallback, _sslStream);
            
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
            if(IsReading)
                return;
            try
            {
                IsReading = true;
                // Create the state object.
                var state = new StateObject();

                // Begin receiving the data from the remote device.
                _sslStream.BeginRead(state.buffer, 0, StateObject.BufferSize, ReceiveCallback,
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
                var state = (StateObject)ar.AsyncState;
                

                // Read data from the remote device.
                var bytesRead = _sslStream.EndRead(ar);

                if (bytesRead > 0)
                {
                    try
                    {
                        var rawData = new byte[bytesRead];
                        Array.Copy(state.buffer, 0, rawData, 0, bytesRead);
                        _totalBuffer = _totalBuffer.Concat(rawData).ToList();


                        var packetSize = Packet.Packet.GetLengthOfPacket(_totalBuffer);
                        if (packetSize != -1)
                        {

                            var p = Packet.Packet.RetrievePacket(packetSize, ref _totalBuffer);
                            if (p != null)
                            {
                                OnPacketRecieve(p);
                            }

                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("An exception occured in the TCPController.ReceiveCallback function: " + e.Message);    
                    }

                    _sslStream.BeginRead(state.buffer, 0, StateObject.BufferSize, ReceiveCallback,
                        state);
                }
                else
                {
                    IsReading = false;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void OnPacketRecieve(Packet.Packet p)
        {
            var handler = PacketReceived;
            if (handler == null) return;

            Console.WriteLine("Trigger OnPacketRecieve");
            handler(p);
        }

        private static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
        {
            var servercert = new X509Certificate2(Resources._23tia5_centificate, "AvansHogeschool23ti2a5");
            return certificate.Equals(servercert);
        }
    }
}