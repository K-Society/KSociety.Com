using KSociety.Base.EventBusRabbitMQ.Helper;
using KSociety.Com.Biz.Event;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KSociety.Com.Biz.Interface;

public interface IBiz
{
    Dictionary<string, Domain.Entity.Common.TagGroup> SystemGroups { get; }

    //Dictionary<string, IEventBus> TagGroupEventBus { get; }
    Subscriber Subscriber { get; }

    void LoadGroup();

    #region [Get Set to Plc]

    bool GetConnectionReadStatus(string groupName, string connectionName);

    bool GetConnectionWriteStatus(string groupName, string connectionName);

    //ValueTask<bool> GetConnectionReadStatusAsync(string groupName, string connectionName);

    //ValueTask<bool> GetConnectionWriteStatusAsync(string groupName, string connectionName);

    string GetTagValue(string groupName, string tagName);

    ValueTask<string> GetTagValueAsync(string groupName, string tagName);

    bool SetTagValue(string groupName, string tagName, string value);

    ValueTask<bool> SetTagValueAsync(string groupName, string tagName, string value);

    #endregion

    ConnectionStatusIntegrationEventReply GetConnectionStatus(
        ConnectionStatusIntegrationEvent connectionStatusIntegrationEvent);

    ValueTask<ConnectionStatusIntegrationEventReply> GetConnectionStatusAsync(
        ConnectionStatusIntegrationEvent connectionStatusIntegrationEvent);

    TagReadIntegrationEventReply GetTagValue(TagReadIntegrationEvent tagReadIntegrationEvent);

    ValueTask<TagReadIntegrationEventReply> GetTagValueAsync(TagReadIntegrationEvent tagReadIntegrationEvent);

    TagWriteIntegrationEventReply SetTagValue(TagWriteIntegrationEvent tagIntegrationEvent);

    ValueTask<TagWriteIntegrationEventReply> SetTagValueAsync(TagWriteIntegrationEvent tagIntegrationEvent);
}