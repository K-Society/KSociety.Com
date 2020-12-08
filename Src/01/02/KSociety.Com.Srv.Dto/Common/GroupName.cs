using ProtoBuf;

namespace KSociety.Com.Srv.Dto.Common
{
    [ProtoContract]
    public class GroupName
    {
        [ProtoMember(1), CompatibilityLevel(CompatibilityLevel.Level200)]
        public string Name { get; set; }

        public GroupName()
        {

        }

        public GroupName(string name)
        {
            Name = name;
        }
    }
}
