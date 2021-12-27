using KSociety.Base.App.Shared;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Res.Import.Common;

[ProtoContract]
public class TagGroup : IResponse
{
    [ProtoMember(1)]
    public bool Result { get; set; }

    public TagGroup() { }

    public TagGroup(bool result)
    {
        Result = result;
    }
}