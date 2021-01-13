using KSociety.Base.App.Shared;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Res.Export.Common
{
    [ProtoContract]
    public class Tag : IResponse
    {
        [ProtoMember(1)]
        public bool Result { get; set; }

        public Tag() { }

        public Tag(bool result)
        {
            Result = result;
        }
    }
}
