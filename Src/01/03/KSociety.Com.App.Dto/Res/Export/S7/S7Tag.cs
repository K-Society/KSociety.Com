using KSociety.Base.App.Shared;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Res.Export.S7;

[ProtoContract]
public class S7Tag : IResponse
{
    [ProtoMember(1)]
    public bool Result { get; set; }

    public S7Tag() { }

    public S7Tag(bool result)
    {
        Result = result;
    }
}