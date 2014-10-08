using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Mallaca.Network.Packet
{
    public abstract class ListResponsePacket<T> : AuthenticatedPacket
    {
        public List<T> List { get; protected set; }
        private readonly string _listPropertyName;
        private readonly bool useAuth;

        protected ListResponsePacket(string auth, string listPropName) : base(auth)
        {
            List = new List<T>();
            _listPropertyName = listPropName;
            useAuth = true;
        }

        protected ListResponsePacket(string listPropName)
            : base("")
        {
            useAuth = false;
            List = new List<T>();
            _listPropertyName = listPropName;
        }

        protected ListResponsePacket(List<T> list , string listPropName)
            : base("")
        {

            useAuth = false;
            List = list;
            _listPropertyName = listPropName;

        }

        protected ListResponsePacket(List<T> list, string listPropName, string authToken)
            : base(authToken)
        {

            useAuth = false;
            List = list;
            _listPropertyName = listPropName;
            List = new List<T>();
        }

        protected ListResponsePacket(JObject j, string listPropName) : base(j)
        {
            _listPropertyName = listPropName;
            List = new List<T>();
            foreach (JToken token in j[_listPropertyName].Children())
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
            j.Add(new JProperty(_listPropertyName, jArray));
            return j;
        }

    }
}
