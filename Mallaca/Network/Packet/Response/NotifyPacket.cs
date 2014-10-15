using System;
using Newtonsoft.Json.Linq;

namespace Mallaca.Network.Packet.Response
{
    public class NotifyPacket : ResponsePacket
    {
        private const string Cmd = "Notify";

        public Subject NotifySubject { get; private set; }
        public Tuple<String, String> NotifyValue { get; private set; }
        //Example: "Username","SpecialistA"

        #region Constructors
        public NotifyPacket(Subject notifySubject, Tuple<String, String> notifyValue) :
            base(Statuscode.Status.Ok, Cmd)
        {
            Initialize(notifySubject, notifyValue);
        }
        #endregion

        #region Initializers
        private void Initialize(Subject notifySubject, Tuple<String, String> notifyValue)
        {
            NotifySubject = notifySubject;
            NotifyValue = notifyValue;
        }
        #endregion

        #region Overrided Methods

        public override JObject ToJsonObject()
        {
            var obj = base.ToJsonObject();
            obj.Add("Subject", NotifySubject.ToString());
            obj.Add(NotifyValue.Item1, NotifyValue.Item2);
            return obj;
        }

        public override string ToString()
        {
            return ToJsonObject().ToString();
        }

        #endregion

        public enum Subject
        {
            SpecialistConnected,
            SpecialistDisconnected,
        }
    }
}
