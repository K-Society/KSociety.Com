using ProtoBuf;

namespace KSociety.Com.Biz.Event;

[ProtoContract]
public class ConnectionStatusIntegrationEventReply : IntegrationComEventReply
{
    [ProtoMember(1)]
    public string GroupName { get; set; }

    [ProtoMember(2)]
    public string ConnectionName { get; set; }

    [ProtoMember(3)]
    public bool ConnectionRead { get; set; }

    [ProtoMember(4)]
    public bool ConnectionWrite { get; set; }

    public ConnectionStatusIntegrationEventReply() { }

    public ConnectionStatusIntegrationEventReply(
        string routingKey,
        string groupName,
        string connectionName,
        bool connectionRead, bool connectionWrite
    )
        : base(routingKey)
    {
        GroupName = groupName;
        ConnectionName = connectionName;
        ConnectionRead = connectionRead;
        ConnectionWrite = connectionWrite;
    }
}