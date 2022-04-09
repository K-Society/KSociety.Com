using KSociety.Base.App.Shared;
using KSociety.Base.InfraSub.Shared.Interface;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Res.ModifyField.Common;

[ProtoContract]
public class TagGroup : IResponse, IBoolResponse
{
    [ProtoMember(1)]
    public bool Result { get; set; }

    public TagGroup() { }

    public TagGroup(bool result)
    {
        Result = result;
    }
}