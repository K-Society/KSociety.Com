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
using KSociety.Com.Srv.Dto.Biz;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;
using RabbitMQ.Client;

namespace KSociety.Com.Srv.Behavior.Transaction
{
    public class TransactionAsync : ITransactionAsync
    {
        private readonly ILoggerFactory _loggerFactory;
        private static ILogger<TransactionAsync> _logger;
        private readonly IComponentContext _componentContext;
        private readonly IConnectionFactory _connectionFactory;
        private readonly IExchangeComDeclareParameters _exchangeDeclareParameters;
        private readonly IQueueComDeclareParameters _queueDeclareParameters;
        private readonly ICommandHandlerAsync _commandHandlerAsync;
        private readonly ITagGroupReady _tagGroupReady;

        private Dictionary<string, IEventBus> TagGroupEventBus { get; } = new Dictionary<string, IEventBus>();

        public TransactionAsync(
            ILoggerFactory loggerFactory,
            IComponentContext componentContext,
            IConnectionFactory connectionFactory,
            IExchangeComDeclareParameters exchangeDeclareParameters,
            IQueueComDeclareParameters queueDeclareParameters,
            ICommandHandlerAsync commandHandlerAsync,
            ITagGroupReady tagGroupReady
            )
        {
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<TransactionAsync>();
            _componentContext = componentContext;
            _connectionFactory = connectionFactory;
            _exchangeDeclareParameters = exchangeDeclareParameters;
            _queueDeclareParameters = queueDeclareParameters;
            _commandHandlerAsync = commandHandlerAsync;
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

        public IAsyncEnumerable<HeartBeat> SendHeartBeatAsync(CallContext context = default) =>
            SendHeartBeatAsync(context.CancellationToken);

        private static async IAsyncEnumerable<HeartBeat> SendHeartBeatAsync([EnumeratorCancellation] CancellationToken cancel)
        {
            while (!cancel.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(TimeSpan.FromSeconds(10), cancel);
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

        public IAsyncEnumerable<TagIntegrationEvent> NotifyTagInvokeAsync(NotifyTagReq notifyTagReq, CallContext context = default) =>
            NotifyTagInvokeAsync(notifyTagReq, context.CancellationToken);

        private async IAsyncEnumerable<TagIntegrationEvent> NotifyTagInvokeAsync(NotifyTagReq notifyTagReq, [EnumeratorCancellation] CancellationToken cancel)
        {
            await foreach (var tagInvokeIntegrationEvent in ((IEventBusQueue)TagGroupEventBus[notifyTagReq.GroupName + "_Invoke"])
                .GetIntegrationQueueHandler<TagIntegrationEvent, TagInvokeQueueHandler>().Dequeue(cancel))
            {
                yield return tagInvokeIntegrationEvent;
            }
        }

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

        public async ValueTask<App.Dto.Res.Transaction.GetConnectionStatus> ConnectionStatusAsync(GetConnectionStatus request, CallContext context = default)
        {
            return await _commandHandlerAsync.ExecuteWithResponseAsync<GetConnectionStatus, App.Dto.Res.Transaction.GetConnectionStatus>(_loggerFactory, _componentContext, request, context.CancellationToken);
        }

        public async ValueTask<App.Dto.Res.Transaction.SetTagValue> SetTagValueAsync(SetTagValue request, CallContext context = default)
        {
            return await _commandHandlerAsync.ExecuteWithResponseAsync<SetTagValue, App.Dto.Res.Transaction.SetTagValue>(_loggerFactory, _componentContext, request, context.CancellationToken);
        }

        public async ValueTask<App.Dto.Res.Transaction.GetTagValue> GetTagValueAsync(GetTagValue request, CallContext context = default)
        {
            return await _commandHandlerAsync.ExecuteWithResponseAsync<GetTagValue, App.Dto.Res.Transaction.GetTagValue>(_loggerFactory, _componentContext, request);
        }

        #endregion
    }
}
