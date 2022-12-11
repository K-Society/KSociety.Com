using System;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto
{
    [ProtoContract]
    public class HeartBeat
    {
        [ProtoMember(1), CompatibilityLevel(CompatibilityLevel.Level200)]
        public DateTime Timestamp { get; set; }

        public HeartBeat() { }

        public HeartBeat(DateTime timestamp)
        {
            Timestamp = timestamp;
        }
    }
}