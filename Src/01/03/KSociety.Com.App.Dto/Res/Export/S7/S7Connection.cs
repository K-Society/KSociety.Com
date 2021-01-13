using KSociety.Base.App.Shared;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Res.Export.S7
{
    [ProtoContract]
    public class S7Connection : IResponse
    {
        [ProtoMember(1)]
        public bool Result { get; set; }

        public S7Connection() { }

        public S7Connection(bool result)
        {
            Result = result;
        }
    }
}
