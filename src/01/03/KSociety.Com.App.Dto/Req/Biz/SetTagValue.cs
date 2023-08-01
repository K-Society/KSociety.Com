using KSociety.Base.App.Shared;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Req.Biz
{
    [ProtoContract]
    public class SetTagValue : IRequest
    {
        [ProtoMember(1)] public string GroupName { get; set; }

        [ProtoMember(2)] public string TagName { get; set; }

        [ProtoMember(3)] public string Value { get; set; }

        public SetTagValue()
        {

        }

        public SetTagValue(
            string groupName,
            string tagName,
            string value)
        {
            GroupName = groupName;
            TagName = tagName;
            Value = value;
        }
    }
}