using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mallaca.Network.Packet.Request
{
    public class PushPacket<T> : AuthenticatedPacket
    {
        //Inherited field: CMD, AuthToken
        //Introduced fields: PacketDataType (enum), Measurements (Array/List)

        public const string DefCmd = "PUSH";

        public DataType PacketDataType { get; private set; }
        public IEnumerable<T> DataSource { get; private set; }

        // The enum containing all posible datatypes
        // Note to developers: Feel free to add new ones if necessary.
        public enum DataType
        {
            Measurements,
            Configuration
        }

        public PushPacket(DataType datatype, IEnumerable<T> datasource, string authtoken)
            : base(DefCmd, authtoken)
        {
            Initialize(datatype, datasource);
        }

        private void Initialize(DataType type, IEnumerable<T> datasource)
        {
            DataSource = datasource;
            PacketDataType = type;
        }

        public override JObject ToJsonObject()
        {
            // Parse all the object to a Json-Object first.
            var dataEnumerable = DataSource.Select(data => JObject.Parse(JsonConvert.SerializeObject(data)));

            // Create the json-object using the dataEnumerable
            var json = base.ToJsonObject();
            json.Add("Datatype", Enum.GetName(typeof(DataType), PacketDataType));
            json.Add("DataSource", new JArray(dataEnumerable));
            return json;
        }

        public override string ToString()
        {
            return ToJsonObject().ToString();
        }
    }
}
