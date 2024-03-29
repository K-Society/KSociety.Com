﻿using Autofac;
using KSociety.Base.EventBus.Abstractions.EventBus;
using KSociety.Base.EventBusRabbitMQ;
using KSociety.Base.EventBusRabbitMQ.Helper;
using KSociety.Base.InfraSub.Shared.Interface;
using KSociety.Com.Biz.Event;
using KSociety.Com.Biz.IntegrationEvent.EventHandling;
using KSociety.Com.Biz.Interface;
using KSociety.Com.Domain.Repository.View.Common;
using KSociety.Com.Domain.Repository.View.Joined;
using KSociety.Com.EventBus;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KSociety.Com.Biz.Class;

public class Biz : IBiz
{
    private readonly ILogger<Biz> _logger;
    private readonly ILoggerFactory _loggerFactory;
    private readonly IEventBusComParameters _eventBusComParameters;
    private readonly INotifierMediatorService _notifierMediatorService;
    private readonly ITagGroupReady _tagGroupReady;
    private readonly IAllTagGroupAllConnection _allTagGroupAllConnection;
    private readonly IComponentContext _componentContext;
    private readonly IRabbitMqPersistentConnection _persistentConnection;

    private readonly string _machineName;
    private List<Domain.Entity.View.Joined.AllTagGroupAllConnection> _dataList;
    public Dictionary<string, Domain.Entity.Common.TagGroup> SystemGroups { get; } = new();

    //public Dictionary<string, IEventBus> TagGroupEventBus { get; } = new();

    public Subscriber Subscriber { get; }

    public Biz(
        ILoggerFactory loggerFactory,
        IEventBusComParameters eventBusComParameters,
        INotifierMediatorService notifierMediatorService,
        ITagGroupReady tagGroupReady,
        IAllTagGroupAllConnection allTagGroupAllConnection,
        IComponentContext componentContext,
        IRabbitMqPersistentConnection persistentConnection
    )
    {
        _loggerFactory = loggerFactory;
        _logger = _loggerFactory.CreateLogger<Biz>();
        _eventBusComParameters = eventBusComParameters;
        _notifierMediatorService = notifierMediatorService;
        _tagGroupReady = tagGroupReady;
        _allTagGroupAllConnection = allTagGroupAllConnection;
        _componentContext = componentContext;
        _persistentConnection = persistentConnection;

        _machineName = Environment.MachineName;
        _logger.LogInformation("KBase.Business.Com startup machine name: " + _machineName);

        Subscriber = new Subscriber(_loggerFactory, _persistentConnection, eventBusComParameters);
    }

    public void LoadGroup()
    {
        //var result = 
        try
        {
            foreach (var tagGroupReady in _tagGroupReady.GetAllTagGroupReady())
            {
                _logger.LogTrace("LoadGroup TagGroup: {0}", tagGroupReady.Name);

                #region [Connection]

                Subscriber.SubscribeClientServer<
                    ConnectionStatusRpcClientHandler, ConnectionStatusRpcServerHandler,
                    ConnectionStatusIntegrationEvent, ConnectionStatusIntegrationEventReply>(
                    tagGroupReady.Name + "_Connection",
                    "BusinessQueueConnection_" + tagGroupReady.Name,
                    tagGroupReady.Name + ".automation.connection.server",
                    tagGroupReady.Name + ".automation.connection.client.com",
                    new ConnectionStatusRpcClientHandler(_loggerFactory, _componentContext),
                    new ConnectionStatusRpcServerHandler(_loggerFactory, _componentContext));

                #endregion

                Subscriber.SubscribeInvoke<TagInvokeEventHandler, TagIntegrationEvent>(
                    tagGroupReady.Name + "_Invoke", "BusinessQueueInvoke_" + tagGroupReady.Name, 
                    new TagInvokeEventHandler(_loggerFactory, _componentContext)
                    );

                #region [Read]

                Subscriber.SubscribeClientServer<
                    TagReadRpcClientHandler, TagReadRpcServerHandler, 
                    TagReadIntegrationEvent, TagReadIntegrationEventReply>(
                    tagGroupReady.Name + "_Read", 
                    "BusinessQueueRead_" + tagGroupReady.Name, 
                    tagGroupReady.Name + ".automation.read.server", 
                    tagGroupReady.Name + ".automation.read.client.com", 
                    new TagReadRpcClientHandler(_loggerFactory, _componentContext), 
                    new TagReadRpcServerHandler(_loggerFactory, _componentContext));

                #endregion

                #region [Write]

                Subscriber.SubscribeClientServer<
                    TagWriteRpcClientHandler, TagWriteRpcServerHandler,
                    TagWriteIntegrationEvent, TagWriteIntegrationEventReply>(
                    tagGroupReady.Name + "_Write",
                    "BusinessQueueWrite_" + tagGroupReady.Name,
                    tagGroupReady.Name + ".automation.write.server",
                    tagGroupReady.Name + ".automation.write.client.com",
                    new TagWriteRpcClientHandler(_loggerFactory, _componentContext),
                    new TagWriteRpcServerHandler(_loggerFactory, _componentContext));

                #endregion

                if (SystemGroups.ContainsKey(tagGroupReady.Name)) continue;
                tagGroupReady.AddLoggerFactory(_loggerFactory);
                SystemGroups.Add(tagGroupReady.Name, tagGroupReady.GetTagGroup(/*_connectionFactory,*/ _notifierMediatorService));

                SystemGroups[tagGroupReady.Name]
                    .Initiate(_allTagGroupAllConnection.GetAllTagGroupAllConnection()
                        .Where(tags => tags.TagGroupName.Equals(tagGroupReady.Name))
                        .ToList());
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,"LoadGroup: ");
        }
    }

    #region [Get Set to Plc]

    public bool GetConnectionReadStatus(string groupName, string connectionName)
    {
        return SystemGroups.ContainsKey(groupName) && SystemGroups[groupName].GetConnectionStatusRead(connectionName);
    }

    public bool GetConnectionWriteStatus(string groupName, string connectionName)
    {
        return SystemGroups.ContainsKey(groupName) && SystemGroups[groupName].GetConnectionStatusWrite(connectionName);
    }

    public string GetTagValue(string groupName, string tagName)
    {
        var output = string.Empty;

        if (SystemGroups.ContainsKey(groupName))
        {
            output = SystemGroups[groupName].GetTagValue(tagName);
        }

        return output;
    }

    public async ValueTask<string> GetTagValueAsync(string groupName, string tagName)
    {
        var output = string.Empty;

        if (SystemGroups.ContainsKey(groupName))
        {
            output = await SystemGroups[groupName].GetTagValueAsync(tagName).ConfigureAwait(false);
        }

        return output;
    }

    public bool SetTagValue(string groupName, string tagName, string value)
    {
        var output = false;

        if (SystemGroups.ContainsKey(groupName))
        {
            output = SystemGroups[groupName].SetTagValue(tagName, value);
        }

        return output;
    }

    public async ValueTask<bool> SetTagValueAsync(string groupName, string tagName, string value)
    {
        //_logger.LogTrace("SetTagValueAsync: " + groupName + " " + tagName + " " + value);
        var output = false;

        if (SystemGroups.ContainsKey(groupName))
        {
            output = await SystemGroups[groupName].SetTagValueAsync(tagName, value).ConfigureAwait(false);
        }

        return output;
    }

    #endregion

    #region [Handler]

    #region [GetConnectionStatus]

    public ConnectionStatusIntegrationEventReply GetConnectionStatus(ConnectionStatusIntegrationEvent connectionStatusIntegrationEvent)
    {
        //if (TagGroupEventBus.ContainsKey(connectionStatusIntegrationEvent.GroupName + "_Connection"))
        if (Subscriber.EventBus.ContainsKey(connectionStatusIntegrationEvent.GroupName + "_Connection_Client"))
        {
            var result = ((IEventBusRpcClient)Subscriber.EventBus[connectionStatusIntegrationEvent.GroupName + "_Connection_Client"])
                .CallAsync<ConnectionStatusIntegrationEventReply>(connectionStatusIntegrationEvent);

            return result.Result;
        }

        _logger.LogError("GetConnectionStatus: " + connectionStatusIntegrationEvent.GroupName + " " + connectionStatusIntegrationEvent.ConnectionName + " Error!");

        return new ConnectionStatusIntegrationEventReply();
    }

    public async ValueTask<ConnectionStatusIntegrationEventReply> GetConnectionStatusAsync(ConnectionStatusIntegrationEvent connectionStatusIntegrationEvent)
    {
        //if (TagGroupEventBus.ContainsKey(connectionStatusIntegrationEvent.GroupName + "_Connection"))
        if (Subscriber.EventBus.ContainsKey(connectionStatusIntegrationEvent.GroupName + "_Connection_Client"))
        {
            return await ((IEventBusRpcClient)Subscriber.EventBus[connectionStatusIntegrationEvent.GroupName + "_Connection_Client"])
                .CallAsync<ConnectionStatusIntegrationEventReply>(connectionStatusIntegrationEvent);
        }

        _logger.LogError("GetConnectionStatus: " + connectionStatusIntegrationEvent.GroupName + " " + connectionStatusIntegrationEvent.ConnectionName + " Error!");

        return new ConnectionStatusIntegrationEventReply();
    }

    #endregion

    #region [GetTagValue]

    public TagReadIntegrationEventReply GetTagValue(TagReadIntegrationEvent tagReadIntegrationEvent)
    {
        //if (TagGroupEventBus.ContainsKey(tagReadIntegrationEvent.GroupName + "_Read"))
        if (Subscriber.EventBus.ContainsKey(tagReadIntegrationEvent.GroupName + "_Read_Client"))
        {
            var result= ((IEventBusRpcClient)Subscriber.EventBus[tagReadIntegrationEvent.GroupName + "_Read_Client"])
                .CallAsync<TagReadIntegrationEventReply>(tagReadIntegrationEvent);

            return result.Result;
        }

        _logger.LogError("GetTagValueAsync: " + tagReadIntegrationEvent.GroupName + " " + tagReadIntegrationEvent.Name + " Error!");

        return new TagReadIntegrationEventReply();
    }

    public async ValueTask<TagReadIntegrationEventReply> GetTagValueAsync(TagReadIntegrationEvent tagReadIntegrationEvent)
    {
        if (Subscriber.EventBus.ContainsKey(tagReadIntegrationEvent.GroupName + "_Read_Client"))
        {
            return await ((IEventBusRpcClient)Subscriber.EventBus[tagReadIntegrationEvent.GroupName + "_Read_Client"])
                .CallAsync<TagReadIntegrationEventReply>(tagReadIntegrationEvent).ConfigureAwait(false);
        }

        _logger.LogError("GetTagValueAsync: " + tagReadIntegrationEvent.GroupName + " " + tagReadIntegrationEvent.Name + " Error!");

        return new TagReadIntegrationEventReply();
    }

    #endregion

    #region [SetTagValue]

    public TagWriteIntegrationEventReply SetTagValue(TagWriteIntegrationEvent tagWriteIntegrationEvent)
    {
        //if (TagGroupEventBus.ContainsKey(tagWriteIntegrationEvent.GroupName + "_Write"))
        if (Subscriber.EventBus.ContainsKey(tagWriteIntegrationEvent.GroupName + "_Write_Client"))
        {
            var result = ((IEventBusRpcClient)Subscriber.EventBus[tagWriteIntegrationEvent.GroupName + "_Write_Client"])
                .CallAsync<TagWriteIntegrationEventReply>(tagWriteIntegrationEvent);

            return result.Result;
        }

        _logger.LogError("SetTagValueAsync: " + tagWriteIntegrationEvent.GroupName + " " + tagWriteIntegrationEvent.Name + " Error!");

        return new TagWriteIntegrationEventReply();
    }

    public async ValueTask<TagWriteIntegrationEventReply> SetTagValueAsync(TagWriteIntegrationEvent tagWriteIntegrationEvent)
    {
        //if (TagGroupEventBus.ContainsKey(tagWriteIntegrationEvent.GroupName + "_Write"))
        if (Subscriber.EventBus.ContainsKey(tagWriteIntegrationEvent.GroupName + "_Write_Client"))
        {
            return await ((IEventBusRpcClient)Subscriber.EventBus[tagWriteIntegrationEvent.GroupName + "_Write_Client"])
                .CallAsync<TagWriteIntegrationEventReply>(tagWriteIntegrationEvent).ConfigureAwait(false);
        }

        _logger.LogError("SetTagValueAsync: " + tagWriteIntegrationEvent.GroupName + " " + tagWriteIntegrationEvent.Name + " Error!");

        return new TagWriteIntegrationEventReply();
    }

    #endregion

    #endregion
}