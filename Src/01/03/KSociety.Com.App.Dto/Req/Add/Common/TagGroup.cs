using KSociety.Base.App.Shared;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Req.Add.Common;

[ProtoContract]
public class TagGroup : IRequest
{
    [ProtoMember(1)]
    public string Name { get; set; }

    [ProtoMember(2)]
    public int Clock { get; set; }

    [ProtoMember(3)]
    public int Update { get; set; }

    [ProtoMember(4)]
    public bool Enable { get; set; }

    public TagGroup() { }

    public TagGroup(
        string name, int clock, int update, bool enable
    )
    {
        Name = name;
        Clock = clock;
        Update = update;
        Enable = enable;
    }
}