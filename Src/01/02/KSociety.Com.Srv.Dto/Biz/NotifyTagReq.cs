using ProtoBuf;

namespace KSociety.Com.Srv.Dto.Biz
{
    [ProtoContract]
    public class NotifyTagReq
    {
        [ProtoMember(1)] public string GroupName { get; set; }

        public NotifyTagReq() { }

        public NotifyTagReq(string groupName)
        {
            GroupName = groupName;
        }
    }
}