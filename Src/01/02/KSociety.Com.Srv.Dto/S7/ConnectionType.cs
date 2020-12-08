using KSociety.Base.InfraSub.Shared.Interface;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.S7
{
    [ProtoContract]
    public class ConnectionType : IObject
    {
        [ProtoMember(1)]
        public int Id { get; set; }

        [ProtoMember(2)]
        public string Name { get; set; }

        private ConnectionType() { }

        public ConnectionType(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
