using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Mallaca.Network.Packet
{
    public abstract class ListPacket<T> : AuthenticatedPacket
    {
        public List<T> List { get; protected set; }
        private readonly string _dataType;
        private readonly bool useAuth;

        protected ListPacket(string auth, string listPropName) : base(auth)
        {
            List = new List<T>();
            _dataType = listPropName;
            useAuth = true;
        }

        protected ListPacket(string listPropName)
            : base("")
        {
            useAuth = false;
            List = new List<T>();
            _dataType = listPropName;
        }

        protected ListPacket(List<T> list , string listPropName)
            : base("")
        {

            useAuth = false;
            List = list;
            _dataType = listPropName;

        }

        protected ListPacket(List<T> list, string listPropName, string authToken)
            : base(authToken)
        {

            useAuth = false;
            List = list;
            _dataType = listPropName;
            List = new List<T>();
        }

        protected ListPacket(JObject j, string listPropName) : base(j)
        {
            _dataType = listPropName;
            List = new List<T>();

            foreach (JToken token in j["data"].Children())
            {
                List.Add(token.ToObject<T>());
            }
        }

        public override JObject ToJsonObject()
        {
            JObject j;
            j = useAuth ? base.ToJsonObject() : new JObject();

            j.Add("count", List.Count);
            JArray jArray = JArray.FromObject(List);
            j.Add(new JProperty("data", jArray));
            return j;
        }

    }
}
