using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using Mallaca.Properties;
using Mallaca.Network.Packet;

namespace Mallaca.Network
{
    // ReSharper disable once InconsistentNaming
    public class TCPController
    {
        private static TcpClient _client;
        private static SslStream _sslStream;
        public static Boolean Busy { get; private set; }
        private static string _response = String.Empty;

        public delegate void ReceivedPacket(Packet.Packet p);
        public static event ReceivedPacket OnPacketReceived;

        public static bool IsReading { get; private set; }
        private static List<byte> _totalBuffer = new List<byte>();

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



        public async static void Send(String data)
        {
            if (_client == null)
                return;
            Busy = true;

            var bytes = Packet.Packet.CreateByteData(data);
            try
            {
                await _sslStream.WriteAsync(bytes, 0, bytes.Length);
            }
            catch (NotSupportedException)
            {
                Send(data);
            }
            

        }

        public async static void ReceiveTransmissionAsync()
        {
            
            while (true)
            {
                var buffer = new byte[1024];
                var bytesRead = await _sslStream.ReadAsync(buffer, 0, buffer.Length);
                if (bytesRead > 0)
                {
                    try
                    {
                        var rawData = new byte[bytesRead];
                        Array.Copy(buffer, 0, rawData, 0, bytesRead);
                        _totalBuffer = _totalBuffer.Concat(rawData).ToList();

                        var packetSize = Packet.Packet.GetLengthOfPacket(_totalBuffer);
                        if (packetSize != -1)
                        {
                            Console.WriteLine("TCP: Packet received");
                            var p = Packet.Packet.RetrievePacket(packetSize, ref _totalBuffer);
                            if (p != null)
                            {
                                foreach (ReceivedPacket deleg in OnPacketReceived.GetInvocationList())
                                {
                                    deleg.BeginInvoke(p, null, null);
                                }
                            }
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("An exception occured in the TCPController.ReceiveTransmissionAsync function: " +
                                          e.Message);
                    }
                }
                else
                {
                    Console.WriteLine("No bytes received. Connection has probably been closed.");
                    return;
                }
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
