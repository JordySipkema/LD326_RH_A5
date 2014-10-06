using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Sockets;

namespace Mallaca.Network
{
    public class Chat_Controller
    {

        public static void SendMessage(String message)
        {
            JObject chatPacket = new JObject(
                    new JProperty("CMD", "CHAT"),
                    new JProperty("message", message));

            var json = chatPacket.ToString();
            json = json.Length.ToString().PadRight(4, ' ') + json;

            TCPController.RunClient();
            TCPController.Send(json);

        }

    }
}
