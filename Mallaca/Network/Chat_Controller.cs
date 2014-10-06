using System;
using Newtonsoft.Json.Linq;

namespace Mallaca.Network
{
    public class Chat_Controller
    {

        public static void SendMessage(String message)
        {
            JObject chatPacket = new JObject(
                    new JProperty("CMD", "chat"),
                    new JProperty("message", message));

            var json = chatPacket.ToString();
            //json = json.Length.ToString().PadRight(4, ' ') + json;

            TCPController.RunClient();
            TCPController.Send(json);

        }

    }
}
