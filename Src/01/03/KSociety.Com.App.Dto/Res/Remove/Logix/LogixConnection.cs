using KSociety.Base.App.Shared;
using KSociety.Base.InfraSub.Shared.Interface;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Res.Remove.Logix;

[ProtoContract]
public class LogixConnection : IResponse, IBoolResponse
{
    [ProtoMember(1)]
    public bool Result { get; set; }

    public LogixConnection() { }

    public LogixConnection(bool result)
    {
        Result = result;
    }
}