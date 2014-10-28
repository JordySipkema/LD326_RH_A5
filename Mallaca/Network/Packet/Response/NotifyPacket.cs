using System;
using System.Collections.Generic;
using System.Linq;
using Mallaca.Network.Packet.Request;
using Newtonsoft.Json.Linq;

namespace Mallaca.Network.Packet.Response
{
    public class NotifyPacket : AuthenticatedPacket
    {
        public const string Cmd = "NOTIFY";

        public Subject NotifySubject { get; private set; }
        public string PrimaryValue { get; private set; }
        public string SecundaryValue { get; private set; }
        public enum Subject
        {
            SpecialistConnected,
            SpecialistDisconnected,
            NewTrainingId,
            StartTraining,
            StopTraining
        }

        public static readonly Dictionary<Subject, string> PrimaryFieldName = new Dictionary<Subject,string>()
        {
            {Subject.NewTrainingId,"id"},
            {Subject.SpecialistConnected, "user"},
            {Subject.SpecialistDisconnected, "user"},
            {Subject.StartTraining, "clientid"},
            {Subject.StopTraining, "clientid"}
        };

        public static readonly Dictionary<Subject, string> SecundaryFieldName = new Dictionary<Subject, string>()
        {
            {Subject.NewTrainingId, "clientid"},
        };

        //Example: "Username","SpecialistA"

        #region Constructors
        public NotifyPacket(Subject notifySubject, string notifyValue, string auth) :
            base(Cmd, auth)
        {
            Initialize(notifySubject, notifyValue);
        }

        public NotifyPacket(Subject notifySubject, string notifyValue, string secundaryVal, string auth) :
            base(Cmd, auth)
        {
            Initialize(notifySubject, notifyValue, secundaryVal);
        }

        public NotifyPacket(JObject json)
            : base(json, Cmd)
        {
            NotifySubject = json["Subject"].ToObject<Subject>();

            string field = GetPrimaryFieldName(NotifySubject);
            if(field != null)
                PrimaryValue = json[field].ToString();

            string secundary = GetSecundaryFieldName(NotifySubject);
            if (secundary != null)
                SecundaryValue = json[secundary].ToString();

        }
        #endregion

        #region Initializers
        private void Initialize(Subject notifySubject, string notifyValue)
        {
            NotifySubject = notifySubject;
            PrimaryValue = notifyValue;
        }

        private void Initialize(Subject notifySubject, string notifyValue, string sec)
        {
            NotifySubject = notifySubject;
            PrimaryValue = notifyValue;
            SecundaryValue = sec;
        }
        #endregion

        #region Overrided Methods

        public override JObject ToJsonObject()
        {
            var obj = base.ToJsonObject();
            obj.Add("Subject", NotifySubject.ToString());
            string field = GetPrimaryFieldName(NotifySubject);
            if(field != null)
                obj.Add(field, PrimaryValue);

            string sec = GetSecundaryFieldName(NotifySubject);
            if(sec != null)
                obj.Add(sec, SecundaryValue);
            return obj;
        }

        public override string ToString()
        {
            return ToJsonObject().ToString();
        }

        #endregion

        public string GetPrimaryFieldName(Subject s)
        {
            string k;
            PrimaryFieldName.TryGetValue(s, out k);
            return k;
        }

        public string GetSecundaryFieldName(Subject s)
        {
            string k;
            SecundaryFieldName.TryGetValue(s, out k);
            return k;
        }
    }
}
