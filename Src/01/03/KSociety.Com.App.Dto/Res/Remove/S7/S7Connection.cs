using KSociety.Base.App.Shared;
using KSociety.Base.InfraSub.Shared.Interface;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Res.Remove.S7
{
    [ProtoContract]
    public class S7Connection : IResponse, IBoolResponse
    {
        [ProtoMember(1)] public bool Result { get; set; }

        public S7Connection() { }

        public S7Connection(bool result)
        {
            Result = result;
        }
    }
}