using System;
using Newtonsoft.Json.Linq;

namespace Mallaca.Network.Packet.Request
{
    public class RequestPacket : Packet
    {
        //Introduced Fields: CMD

        //ReSharper disable once InconsistentNaming
        public String CMD { get; private set; }

        #region Constructors
        //RequestPacket shouldnt be initialized directly.
        //A protected constructor protects initializing 
        //(only derrived classes can call this ctor)
        protected RequestPacket(string cmd)
        {
            Initialize(cmd);
        } 
        #endregion

        #region Initializers
        private void Initialize(String cmd)
        {
            CMD = cmd;
        } 
        #endregion


        #region Override methods
        public override JObject ToJsonObject()
        {
            return new JObject(
                     new JProperty("CMD", CMD)
                     );
        }

        public override string ToString()
        {
            return ToJsonObject().ToString();
        }
        #endregion
    }
}
