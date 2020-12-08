using KSociety.Base.App.Shared;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Res.Transaction
{
    [ProtoContract]
    public class SetTagValue : IResponse
    {
        [ProtoMember(1)]
        public string GroupName { get; set; }

        [ProtoMember(2)]
        public string TagName { get; set; }

        [ProtoMember(3)]
        public bool Result { get; set; }

        public SetTagValue()
        {

        }

        public SetTagValue(string groupName, string tagName, bool result)
        {
            GroupName = groupName;
            TagName = tagName;
            Result = result;
        }
    }
}
