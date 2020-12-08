using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using KSociety.Base.EventBus.Abstractions.EventBus;
using KSociety.Base.EventBusRabbitMQ;
using KSociety.Base.Srv.Shared.Interface;
using KSociety.Com.App.Dto.Req.Transaction;
using KSociety.Com.Biz.IntegrationEvent.Event;
using KSociety.Com.Biz.IntegrationEvent.EventHandling;
using KSociety.Com.Domain.Repository.View.Common;
using KSociety.Com.EventBus;
using KSociety.Com.Srv.Contract.Transaction;
using KSociety.Com.Srv.Dto;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;
using RabbitMQ.Client;

namespace KSociety.Com.Srv.Behavior.Transaction
{
    public class Transaction : ITransaction
    {
        private readonly ILoggerFactory _loggerFactory;
        private static ILogger<Transaction> _logger;
        private readonly IComponentContext _componentContext;
        private readonly IConnectionFactory _connectionFactory;
        private readonly IExchangeComDeclareParameters _exchangeDeclareParameters;
        private readonly IQueueComDeclareParameters _queueDeclareParameters;
        private readonly ICommandHandler _commandHandler;
        private readonly ITagGroupReady _tagGroupReady;

        private Dictionary<string, IEventBus> TagGroupEventBus { get; } = new Dictionary<string, IEventBus>();

        public Transaction(
            ILoggerFactory loggerFactory,
            IComponentContext componentContext,
            IConnectionFactory connectionFactory,
            IExchangeComDeclareParameters exchangeDeclareParameters,
            IQueueComDeclareParameters queueDeclareParameters,
            ICommandHandler commandHandler,
            ITagGroupReady tagGroupReady
            )
        {
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<Transaction>();
            _componentContext = componentContext;
            _connectionFactory = connectionFactory;
            _exchangeDeclareParameters = exchangeDeclareParameters;
            _queueDeclareParameters = queueDeclareParameters;
            _commandHandler = commandHandler;
            _tagGroupReady = tagGroupReady;

            //LoadGroups();
        }

        private void LoadGroups()
        {
            try
            {
                DefaultRabbitMqPersistentConnection persistentConnection =
                    new DefaultRabbitMqPersistentConnection(_connectionFactory, _loggerFactory);

                foreach (var tagGroupReady in _tagGroupReady.GetAllTagGroupReady())
                {
                    var queueInvokeHandler =
                        new TagInvokeQueueHandler(_loggerFactory, _componentContext);
                    //var queueReadHandler = 
                    //    new TagReadQueueHandler(_loggerFactory);


                    TagGroupEventBus.Add(tagGroupReady.Name + "_Invoke",
                        new EventBusRabbitMqQueue(persistentConnection, _loggerFactory, queueInvokeHandler, null, _exchangeDeclareParameters, _queueDeclareParameters,
                            "TransactionQueueInvoke_" + tagGroupReady.Name, CancellationToken.None));

                    //TagGroupEventBus.Add(tagGroupReady.Name + "_Read",
                    //    new EventBusRabbitMq(persistentConnection, _loggerFactory, queueReadHandler, null, "direct",
                    //        "TransactionQueueRead_" + tagGroupReady.Name, CancellationToken.None, true));

                    ((IEventBusQueue)TagGroupEventBus[tagGroupReady.Name + "_Invoke"])
                        .SubscribeQueue<TagIntegrationEvent, TagInvokeQueueHandler>(
                            tagGroupReady.Name + ".automation.invoke");

                    //TagGroupEventBus[tagGroupReady.Name + "_Read"]
                    //    .SubscribeRpc<TagReadIntegrationEvent, TagReadQueueHandler>(
                    //        tagGroupReady.Name + ".automation.read");

                    //TagGroupEventBus[tagGroupReady.Name + "_Read"]
                    //    .SubscribeRpc<TagReadIntegrationEvent, 
                    //        TagReadIntegrationEventResult, 
                    //        TagReadIntegrationEventReply, 
                    //        TagReadEventHandlerRpc>(tagGroupReady.Name + ".automation.read");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("LoadGroups: " + ex.Message + " - " + ex.StackTrace);
            }
        }

        #region []

        public IEnumerable<HeartBeat> SendHeartBeat(CallContext context = default) =>
            SendHeartBeat(context.CancellationToken);

        private static IEnumerable<HeartBeat> SendHeartBeat([EnumeratorCancellation] CancellationToken cancel)
        {
            while (!cancel.IsCancellationRequested)
            {
                try
                {
                    Task.Delay(TimeSpan.FromSeconds(10), cancel);
                }
                catch (TaskCanceledException tce)
                {
                    _logger.LogWarning("SendHeartBeatAsync: CancellationToken CancellationRequested" + tce.Message);
                }

                if (!cancel.IsCancellationRequested)
                {
                    yield return new HeartBeat(DateTime.UtcNow);
                }
            }
        }

        //public IEnumerable<TagIntegrationEvent> NotifyTagInvoke(NotifyTagReq notifyTagReq, CallContext context = default) =>
        //    NotifyTagInvoke(notifyTagReq, context.CancellationToken);

        //private async IEnumerable<TagIntegrationEvent> NotifyTagInvoke(NotifyTagReq notifyTagReq, [EnumeratorCancellation] CancellationToken cancel)
        //{
        //    await foreach (var tagInvokeIntegrationEvent in ((IEventBusQueue)TagGroupEventBus[notifyTagReq.GroupName + "_Invoke"])
        //        .GetIntegrationQueueHandler<TagIntegrationEvent, TagInvokeQueueHandler>().Dequeue(cancel))
        //    {
        //        yield return tagInvokeIntegrationEvent;
        //    }
        //}

        //public IAsyncEnumerable<TagReadIntegrationEvent> NotifyTagReadAsync(NotifyTagReq notifyTagReq, CallContext context = default) =>
        //    NotifyTagReadAsync(notifyTagReq, context.CancellationToken);

        //private async IAsyncEnumerable<TagReadIntegrationEvent> NotifyTagReadAsync(NotifyTagReq notifyTagReq, [EnumeratorCancellation] CancellationToken cancel)
        //{
        //    await foreach (var tagReadIntegrationEvent in TagGroupEventBus[notifyTagReq.GroupName + "_Read"]
        //        .GetIntegrationQueueHandler<TagReadIntegrationEvent, TagReadQueueHandler>().Dequeue(cancel))
        //    {
        //        yield return tagReadIntegrationEvent;
        //    }
        //}

        public App.Dto.Res.Transaction.GetConnectionStatus ConnectionStatus(GetConnectionStatus request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<GetConnectionStatus, App.Dto.Res.Transaction.GetConnectionStatus>(_loggerFactory, _componentContext, request);
        }

        public App.Dto.Res.Transaction.SetTagValue SetTagValue(SetTagValue request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<SetTagValue, App.Dto.Res.Transaction.SetTagValue>(_loggerFactory, _componentContext, request);
        }

        public App.Dto.Res.Transaction.GetTagValue GetTagValue(GetTagValue request, CallContext context = default)
        {
            return _commandHandler.ExecuteWithResponse<GetTagValue, App.Dto.Res.Transaction.GetTagValue>(_loggerFactory, _componentContext, request);
        }

        #endregion
    }
}
