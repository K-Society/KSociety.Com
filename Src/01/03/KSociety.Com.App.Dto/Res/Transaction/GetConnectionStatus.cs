using KSociety.Base.App.Shared;
using ProtoBuf;

namespace KSociety.Com.App.Dto.Res.Transaction
{
    [ProtoContract]
    public class GetConnectionStatus : IResponse
    {
        [ProtoMember(1)]
        public string GroupName { get; set; }

        [ProtoMember(2)]
        public string ConnectionName { get; set; }

        [ProtoMember(3)]
        public bool ConnectionRead { get; set; }

        [ProtoMember(4)]
        public bool ConnectionWrite { get; set; }

        public GetConnectionStatus()
        {

        }

        public GetConnectionStatus(string groupName, string connectionName, bool connectionRead, bool connectionWrite)
        {
            GroupName = groupName;
            ConnectionName = connectionName;
            ConnectionRead = connectionRead;
            ConnectionWrite = connectionWrite;
        }
    }
}
