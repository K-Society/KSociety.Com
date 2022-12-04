using KSociety.Base.InfraSub.Shared.Interface;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.S7
{
    [ProtoContract]
    public class WordLen : IObject
    {
        [ProtoMember(1)] public int Id { get; set; }

        [ProtoMember(2)] public string Value { get; set; }

        [ProtoMember(3)] public string Mean { get; set; }

        public WordLen()
        {

        }

        public WordLen(int id, string value, string mean)
        {
            Id = id;
            Value = value;
            Mean = mean;
        }
    }
}