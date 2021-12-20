using KSociety.Base.App.Shared;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Res.Export.Logix;

[ProtoContract]
public class LogixTag : IResponse
{
    [ProtoMember(1)]
    public bool Result { get; set; }

    public LogixTag() { }

    public LogixTag(bool result)
    {
        Result = result;
    }
}