﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using KSociety.Base.EventBus.Abstractions.EventBus;
using KSociety.Base.EventBusRabbitMQ;
using KSociety.Base.InfraSub.Shared.Interface;
using KSociety.Com.Biz.Event;
using KSociety.Com.Biz.IntegrationEvent.EventHandling;
using KSociety.Com.Biz.Interface;
using KSociety.Com.Domain.Repository.View.Common;
using KSociety.Com.Domain.Repository.View.Joined;
using KSociety.Com.EventBus;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace KSociety.Com.Biz.Class
{
    public class Biz : IBiz
    {
        private readonly ILogger<Biz> _logger;
        private readonly ILoggerFactory _loggerFactory;
        private readonly IConnectionFactory _connectionFactory;
        private readonly IExchangeComDeclareParameters _exchangeDeclareParameters;
        private readonly IQueueComDeclareParameters _queueDeclareParameters;
        private readonly INotifierMediatorService _notifierMediatorService;
        private readonly ITagGroupReady _tagGroupReady;
        private readonly IAllTagGroupAllConnection _allTagGroupAllConnection;
        private readonly IComponentContext _componentContext;

        private readonly string _machineName;
        private List<Domain.Entity.View.Joined.AllTagGroupAllConnection> _dataList;
        public Dictionary<string, Domain.Entity.Common.TagGroup> SystemGroups { get; } = new Dictionary<string, Domain.Entity.Common.TagGroup>();

        public Dictionary<string, IEventBus> TagGroupEventBus { get; } = new Dictionary<string, IEventBus>();

        public IRabbitMqPersistentConnection PersistentConnection { get; }

        public Biz(
            ILoggerFactory loggerFactory,
            IConnectionFactory connectionFactory,
            IExchangeComDeclareParameters exchangeDeclareParameters,
            IQueueComDeclareParameters queueDeclareParameters,
            INotifierMediatorService notifierMediatorService,
            ITagGroupReady tagGroupReady,
            IAllTagGroupAllConnection allTagGroupAllConnection,
            IComponentContext componentContext
            )
        {
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<Biz>();
            _connectionFactory = connectionFactory;
            _exchangeDeclareParameters = exchangeDeclareParameters;
            _queueDeclareParameters = queueDeclareParameters;
            _notifierMediatorService = notifierMediatorService;
            _tagGroupReady = tagGroupReady;
            _allTagGroupAllConnection = allTagGroupAllConnection;
            _componentContext = componentContext;

            _machineName = Environment.MachineName;
            _logger.LogInformation("KBase.Business.Com startup machine name: " + _machineName);

            PersistentConnection = new DefaultRabbitMqPersistentConnection(_connectionFactory, _loggerFactory);
        }

        public void LoadGroup()
        {
            //var result = 
            try
            {
                foreach (var tagGroupReady in _tagGroupReady.GetAllTagGroupReady())
                {
                    #region [Connection]

                    TagGroupEventBus.Add(tagGroupReady.Name + "_Connection", 
                        new EventBusRabbitMqRpc(PersistentConnection, _loggerFactory, new ConnectionStatusRpcHandler(_loggerFactory, _componentContext), 
                            null, _exchangeDeclareParameters, _queueDeclareParameters, "BusinessQueueConnection_" + tagGroupReady.Name, CancellationToken.None));

                    ((IEventBusRpcClient)TagGroupEventBus[tagGroupReady.Name + "_Connection"])
                        .SubscribeRpcClient<ConnectionStatusIntegrationEventReply, ConnectionStatusRpcClientHandler>(tagGroupReady.Name + ".automation.connection.client.com");

                    TagGroupEventBus.Add(tagGroupReady.Name + "_Connection_Server",
                        new EventBusRabbitMqRpcServer(PersistentConnection, _loggerFactory, new ConnectionStatusRpcServerHandler(_loggerFactory, _componentContext),
                            null, _exchangeDeclareParameters, _queueDeclareParameters, "BusinessQueueServerRead_" + tagGroupReady.Name, CancellationToken.None));

                    ((IEventBusRpcServer)TagGroupEventBus[tagGroupReady.Name + "_Connection_Server"])
                        .SubscribeRpcServer<TagReadIntegrationEvent, TagReadIntegrationEventReply, TagReadRpcServerHandler>(tagGroupReady.Name + ".automation.connection.server");

                    #endregion

                    TagGroupEventBus.Add(tagGroupReady.Name + "_Invoke", 
                        new EventBusRabbitMqQueue(PersistentConnection, _loggerFactory, new TagInvokeEventHandler(_loggerFactory, _componentContext),
                            null, _exchangeDeclareParameters, _queueDeclareParameters, "BusinessQueueInvoke_" + tagGroupReady.Name, CancellationToken.None));

                    #region [Read]

                    TagGroupEventBus.Add(tagGroupReady.Name + "_Read",
                        new EventBusRabbitMqRpcClient(PersistentConnection, _loggerFactory, new TagReadRpcClientHandler(_loggerFactory, _componentContext),
                            null, _exchangeDeclareParameters, _queueDeclareParameters, "BusinessQueueRead_" + tagGroupReady.Name, CancellationToken.None));

                    ((IEventBusRpcClient)TagGroupEventBus[tagGroupReady.Name + "_Read"])
                        .SubscribeRpcClient<TagReadIntegrationEventReply, TagReadRpcClientHandler>(tagGroupReady.Name + ".automation.read.client.com");

                    TagGroupEventBus.Add(tagGroupReady.Name + "_Read_Server", 
                        new EventBusRabbitMqRpcServer(PersistentConnection, _loggerFactory, new TagReadRpcServerHandler(_loggerFactory, _componentContext),
                            null, _exchangeDeclareParameters, _queueDeclareParameters, "BusinessQueueServerRead_" + tagGroupReady.Name, CancellationToken.None));

                    ((IEventBusRpcServer)TagGroupEventBus[tagGroupReady.Name + "_Read_Server"])
                        .SubscribeRpcServer<TagReadIntegrationEvent, TagReadIntegrationEventReply, TagReadRpcServerHandler>(tagGroupReady.Name + ".automation.read.server");

                    #endregion

                    #region [Write]

                    TagGroupEventBus.Add(tagGroupReady.Name + "_Write", 
                        new EventBusRabbitMqRpcClient(PersistentConnection, _loggerFactory, new TagWriteRpcHandler(_loggerFactory, _componentContext), 
                            null, _exchangeDeclareParameters, _queueDeclareParameters, "BusinessQueueWrite_" + tagGroupReady.Name, CancellationToken.None));

                    ((IEventBusRpcClient)TagGroupEventBus[tagGroupReady.Name + "_Write"])
                        .SubscribeRpcClient<TagWriteIntegrationEventReply, TagWriteRpcClientHandler>(tagGroupReady.Name + ".automation.write.client.com");

                    TagGroupEventBus.Add(tagGroupReady.Name + "_Write_Server", 
                        new EventBusRabbitMqRpcServer(PersistentConnection, _loggerFactory, new TagWriteRpcServerHandler(_loggerFactory, _componentContext),
                            null, _exchangeDeclareParameters, _queueDeclareParameters, "BusinessQueueServerWrite_" + tagGroupReady.Name, CancellationToken.None));

                    ((IEventBusRpcServer)TagGroupEventBus[tagGroupReady.Name + "_Write_Server"])
                        .SubscribeRpcServer<TagWriteIntegrationEvent, TagWriteIntegrationEventReply, TagWriteRpcServerHandler>(tagGroupReady.Name + ".automation.write.server");

                    #endregion

                    if (SystemGroups.ContainsKey(tagGroupReady.Name)) continue;
                    tagGroupReady.AddLoggerFactory(_loggerFactory);
                    SystemGroups.Add(tagGroupReady.Name, tagGroupReady.GetTagGroup(/*_connectionFactory,*/ _notifierMediatorService));

                    SystemGroups[tagGroupReady.Name]
                        .Initiate(_allTagGroupAllConnection.GetAllTagGroupAllConnection()
                        .Where(tags => tags.TagGroupName.Equals(tagGroupReady.Name))
                        .ToList());

                    //tagGroupReady.Initiate(_allTagGroupAllConnection.AllTagGroupAllConnections
                    //    .Where(tags => tags.TagGroupName.Equals(tagGroupReady.Name)).ToList());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("LoadGroup: " + ex.Message + " - " + ex.StackTrace);
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
            if (TagGroupEventBus.ContainsKey(connectionStatusIntegrationEvent.GroupName + "_Connection"))
            {
                var result = ((IEventBusRpcClient)TagGroupEventBus[connectionStatusIntegrationEvent.GroupName + "_Connection"])
                    .CallAsync<ConnectionStatusIntegrationEventReply>(connectionStatusIntegrationEvent);

                return result.Result;
            }

            _logger.LogError("GetConnectionStatus: " + connectionStatusIntegrationEvent.GroupName + " " + connectionStatusIntegrationEvent.ConnectionName + " Error!");

            return new ConnectionStatusIntegrationEventReply();
        }

        public async ValueTask<ConnectionStatusIntegrationEventReply> GetConnectionStatusAsync(ConnectionStatusIntegrationEvent connectionStatusIntegrationEvent)
        {
            if (TagGroupEventBus.ContainsKey(connectionStatusIntegrationEvent.GroupName + "_Connection"))
            {
                return await ((IEventBusRpcClient)TagGroupEventBus[connectionStatusIntegrationEvent.GroupName + "_Connection"])
                    .CallAsync<ConnectionStatusIntegrationEventReply>(connectionStatusIntegrationEvent);
            }

            _logger.LogError("GetConnectionStatus: " + connectionStatusIntegrationEvent.GroupName + " " + connectionStatusIntegrationEvent.ConnectionName + " Error!");

            return new ConnectionStatusIntegrationEventReply();
        }

        #endregion

        #region [GetTagValue]

        public TagReadIntegrationEventReply GetTagValue(TagReadIntegrationEvent tagReadIntegrationEvent)
        {
            if (TagGroupEventBus.ContainsKey(tagReadIntegrationEvent.GroupName + "_Read"))
            {
                var result= ((IEventBusRpcClient)TagGroupEventBus[tagReadIntegrationEvent.GroupName + "_Read"])
                    .CallAsync<TagReadIntegrationEventReply>(tagReadIntegrationEvent);

                return result.Result;
            }

            _logger.LogError("GetTagValueAsync: " + tagReadIntegrationEvent.GroupName + " " + tagReadIntegrationEvent.Name + " Error!");

            return new TagReadIntegrationEventReply();
        }

        public async ValueTask<TagReadIntegrationEventReply> GetTagValueAsync(TagReadIntegrationEvent tagReadIntegrationEvent)
        {
            if (TagGroupEventBus.ContainsKey(tagReadIntegrationEvent.GroupName + "_Read"))
            {
                return await ((IEventBusRpcClient)TagGroupEventBus[tagReadIntegrationEvent.GroupName + "_Read"])
                    .CallAsync<TagReadIntegrationEventReply>(tagReadIntegrationEvent);
            }

            _logger.LogError("GetTagValueAsync: " + tagReadIntegrationEvent.GroupName + " " + tagReadIntegrationEvent.Name + " Error!");

            return new TagReadIntegrationEventReply();
        }

        #endregion

        #region [SetTagValue]

        public TagWriteIntegrationEventReply SetTagValue(TagWriteIntegrationEvent tagWriteIntegrationEvent)
        {
            if (TagGroupEventBus.ContainsKey(tagWriteIntegrationEvent.GroupName + "_Write"))
            {
                var result = ((IEventBusRpcClient)TagGroupEventBus[tagWriteIntegrationEvent.GroupName + "_Write"])
                    .CallAsync<TagWriteIntegrationEventReply>(tagWriteIntegrationEvent);

                return result.Result;
            }

            _logger.LogError("SetTagValueAsync: " + tagWriteIntegrationEvent.GroupName + " " + tagWriteIntegrationEvent.Name + " Error!");

            return new TagWriteIntegrationEventReply();
        }

        public async ValueTask<TagWriteIntegrationEventReply> SetTagValueAsync(TagWriteIntegrationEvent tagWriteIntegrationEvent)
        {
            if (TagGroupEventBus.ContainsKey(tagWriteIntegrationEvent.GroupName + "_Write"))
            {
                return await ((IEventBusRpcClient)TagGroupEventBus[tagWriteIntegrationEvent.GroupName + "_Write"])
                    .CallAsync<TagWriteIntegrationEventReply>(tagWriteIntegrationEvent);
            }

            _logger.LogError("SetTagValueAsync: " + tagWriteIntegrationEvent.GroupName + " " + tagWriteIntegrationEvent.Name + " Error!");

            return new TagWriteIntegrationEventReply();
        }

        #endregion

        #endregion
    }
}
