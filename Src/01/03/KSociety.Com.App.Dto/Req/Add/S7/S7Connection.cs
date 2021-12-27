using KSociety.Base.App.Shared;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Req.Add.S7;

[ProtoContract]
public class S7Connection : IRequest
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

    [ProtoMember(6)]
    public int? CpuTypeId { get; set; }

    [ProtoMember(7)]
    public short? Rack { get; set; }

    [ProtoMember(8)]
    public short? Slot { get; set; }

    [ProtoMember(9)]
    public int? ConnectionTypeId { get; set; }

    public S7Connection() { }

    public S7Connection(
        int automationTypeId,
        string name, string ip,
        bool enable, bool writeEnable,
        int? cpuTypeId,
        short? rack, short? slot,
        int? connectionTypeId
    )
    {
        AutomationTypeId = 1; //automationTypeId;
        Name = name;
        Ip = ip;
        Enable = enable;
        WriteEnable = writeEnable;
        CpuTypeId = cpuTypeId;
        Rack = rack;
        Slot = slot;
        ConnectionTypeId = connectionTypeId;
    }
}