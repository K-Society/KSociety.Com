using KSociety.Base.App.Shared;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Req.Biz;

[ProtoContract]
public class GetConnectionStatus : IRequest
{
    [ProtoMember(1)]
    public string GroupName { get; set; }

    [ProtoMember(2)]
    public string ConnectionName { get; set; }

    public GetConnectionStatus()
    {

    }

    public GetConnectionStatus(string groupName, string connectionName)
    {
        GroupName = groupName;
        ConnectionName = connectionName;
    }
}