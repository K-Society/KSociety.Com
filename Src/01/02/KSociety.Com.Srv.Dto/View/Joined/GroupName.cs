using ProtoBuf;

namespace KSociety.Com.Srv.Dto.View.Joined;

[ProtoContract]
public class GroupName
{
    [ProtoMember(1)]
    public string Name { get; set; }

    public GroupName()
    {

    }

    public GroupName(string name)
    {
        Name = name;
    }
}