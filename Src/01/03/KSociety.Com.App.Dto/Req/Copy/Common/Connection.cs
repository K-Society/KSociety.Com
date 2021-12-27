using KSociety.Base.App.Shared;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Req.Copy.Common;

[ProtoContract]
public class Connection : IRequest
{
    [ProtoMember(1)]
    public int AutomationTypeId { get; set; }

    [ProtoMember(2)]
    public string Name { get; set; }

    [ProtoMember(3)]
    public string Ip { get; set; }

    [ProtoMember(4)]
    public bool Enable { get; set; }

    [ProtoMember(5)]
    public bool WriteEnable { get; set; }

    public Connection() { }

    public Connection(
        int automationTypeId,
        string name, string ip,
        bool enable, bool writeEnable
    )
    {
        AutomationTypeId = automationTypeId;
        Name = name;
        Ip = ip;
        Enable = enable;
        WriteEnable = writeEnable;
    }
}