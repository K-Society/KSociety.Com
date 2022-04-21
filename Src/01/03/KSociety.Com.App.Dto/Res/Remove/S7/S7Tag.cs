using KSociety.Base.App.Shared;
using KSociety.Base.InfraSub.Shared.Interface;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Res.Remove.S7;

[ProtoContract]
public class S7Tag : IResponse, IBoolResponse
{
    [ProtoMember(1)]
    public bool Result { get; set; }

    public S7Tag() { }

    public S7Tag(bool result)
    {
        Result = result;
    }
}