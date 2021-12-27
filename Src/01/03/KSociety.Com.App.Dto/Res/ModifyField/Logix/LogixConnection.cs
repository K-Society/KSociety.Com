using KSociety.Base.App.Shared;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Res.ModifyField.Logix;

[ProtoContract]
public class LogixConnection : IResponse
{
    [ProtoMember(1)]
    public bool Result { get; set; }

    public LogixConnection() { }

    public LogixConnection(bool result)
    {
        Result = result;
    }
}