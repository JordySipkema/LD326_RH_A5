﻿using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Mallaca.Network.Packet.Response
{
    public class PullResponsePacket<T> : ResponsePacket
    {
        public const string Cmd = "RESP-PULL";
        public string DataType { get; private set; }
        public List<T> List { get; set; }

        public PullResponsePacket(List<T> lsit, string datatype) : base(Statuscode.Status.Ok, Cmd)
        {
            DataType = datatype;
            List = lsit;
        }

        public PullResponsePacket() : base(Statuscode.Status.Ok, Cmd)
        {
            
        }

        public PullResponsePacket(JObject json, bool dealWithContents = true) : base (json)
        {
            DataType = json["dataType"].ToString();
            if (!dealWithContents)
                return;
            List = new List<T>();
            foreach (var token in json["data"].Children())
            {
                List.Add(token.ToObject<T>());
            }
        }

        public override string ToString()
        {
            return ToJsonObject().ToString();
        }

        public override JObject ToJsonObject()
        {
            JObject json =  base.ToJsonObject();
            json.Add("data", JArray.FromObject(List));
            json.Add("dataType", DataType);
            return json;
        }
    }
}
