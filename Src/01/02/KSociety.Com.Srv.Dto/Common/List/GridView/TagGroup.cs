using System.Collections.Generic;
using KSociety.Base.Srv.Dto;
using ProtoBuf;

namespace KSociety.Com.Srv.Dto.Common.List.GridView;

[ProtoContract]
public class TagGroup : ObjectList<Common.TagGroup>
{
    public TagGroup() { }

    public TagGroup
    (
        List<Common.TagGroup> tagGroups
    )
    {
        List = tagGroups;
    }
}