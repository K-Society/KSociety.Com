using KSociety.Base.App.Shared;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Req.Biz
{
    [ProtoContract]
    public class GetTagValue : IRequest
    {
        [ProtoMember(1)]
        public string GroupName { get; set; }

        [ProtoMember(2)]
        public string TagName { get; set; }

        public GetTagValue()
        {

        }

        public GetTagValue(string groupName, string tagName)
        {
            GroupName = groupName;
            TagName = tagName;
        }
    }
}
