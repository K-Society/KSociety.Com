using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using KSociety.Base.EventBus.Abstractions.EventBus;
using KSociety.Base.EventBusRabbitMQ;
using KSociety.Base.Srv.Shared.Interface;
using KSociety.Com.App.Dto.Req.Biz;
using KSociety.Com.Biz.Event;
using KSociety.Com.Biz.IntegrationEvent.EventHandling;
using KSociety.Com.Domain.Repository.View.Common;
using KSociety.Com.EventBus;
using KSociety.Com.Srv.Contract.Biz;
using KSociety.Com.Srv.Dto;
using KSociety.Com.Srv.Dto.Biz;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;
using RabbitMQ.Client;

namespace KSociety.Com.Srv.Behavior.Biz;

public class BizAsync : IBizAsync
{
    private readonly ILoggerFactory _loggerFactory;
    private static ILogger<BizAsync> _logger;
    private readonly IComponentContext _componentContext;
    private readonly IEventBusComParameters _eventBusComParameters;
    private readonly ICommandHandlerAsync _commandHandlerAsync;
    private readonly ITagGroupReady _tagGroupReady;
    private readonly IRabbitMqPersistentConnection _persistentConnection;

    private Dictionary<string, IEventBus> TagGroupEventBus { get; } = new();

    public BizAsync(
        ILoggerFactory loggerFactory,
        IComponentContext componentContext,
        IEventBusComParameters eventBusComParameters,
        ICommandHandlerAsync commandHandlerAsync,
        ITagGroupReady tagGroupReady,
        IRabbitMqPersistentConnection persistentConnection
    )
    {
        _loggerFactory = loggerFactory;
        _logger = _loggerFactory.CreateLogger<BizAsync>();
        _componentContext = componentContext;
        _eventBusComParameters = eventBusComParameters;
        _commandHandlerAsync = commandHandlerAsync;
        _tagGroupReady = tagGroupReady;
        _persistentConnection = persistentConnection;
        //LoadGroups();
    }

    private void LoadGroups()
    {
        try
        {
            //DefaultRabbitMqPersistentConnection persistentConnection =
            //    new(_connectionFactory, _loggerFactory);

            foreach (var tagGroupReady in _tagGroupReady.GetAllTagGroupReady())
            {
                var queueInvokeHandler =
                    new TagInvokeQueueHandler(_loggerFactory, _componentContext);
                //var queueReadHandler = 
                //    new TagReadQueueHandler(_loggerFactory);


                TagGroupEventBus.Add(tagGroupReady.Name + "_Invoke",
                    new EventBusRabbitMqQueue(_persistentConnection, _loggerFactory, queueInvokeHandler, null, _eventBusComParameters,
                        "TransactionQueueInvoke_" + tagGroupReady.Name));

                ((IEventBusQueue)TagGroupEventBus[tagGroupReady.Name + "_Invoke"]).Initialize();

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
            _logger.LogError(ex, "LoadGroups: ");
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
                _logger.LogWarning(tce, "SendHeartBeatAsync: CancellationToken CancellationRequested.");
            }

            if (!cancel.IsCancellationRequested)
            {
                yield return new HeartBeat(DateTime.UtcNow);
            }
        }
    }

    public IAsyncEnumerable<NotifyTagRes> NotifyTagInvokeAsync(NotifyTagReq notifyTagReq, CallContext context = default) =>
        NotifyTagInvokeAsync(notifyTagReq, context.CancellationToken);

    private async IAsyncEnumerable<NotifyTagRes> NotifyTagInvokeAsync(NotifyTagReq notifyTagReq, [EnumeratorCancellation] CancellationToken cancel)
    {
        await foreach (var tagInvokeIntegrationEvent in ((IEventBusQueue)TagGroupEventBus[notifyTagReq.GroupName + "_Invoke"])
                       .GetIntegrationQueueHandler<TagIntegrationEvent, TagInvokeQueueHandler>().Dequeue(cancel))
        {
            //_logger.LogTrace(tagInvokeIntegrationEvent.Timestamp + " " + tagInvokeIntegrationEvent.GroupName + " " + tagInvokeIntegrationEvent.Name + " " + tagInvokeIntegrationEvent.Value);
            yield return new NotifyTagRes(tagInvokeIntegrationEvent.GroupName, tagInvokeIntegrationEvent.Name, tagInvokeIntegrationEvent.Value, tagInvokeIntegrationEvent.Timestamp);
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

    public async ValueTask<App.Dto.Res.Biz.GetConnectionStatus> ConnectionStatusAsync(GetConnectionStatus request, CallContext context = default)
    {
        return await _commandHandlerAsync.ExecuteWithResponseAsync<GetConnectionStatus, App.Dto.Res.Biz.GetConnectionStatus>(_loggerFactory, _componentContext, request, context.CancellationToken);
    }

    public async ValueTask<App.Dto.Res.Biz.SetTagValue> SetTagValueAsync(SetTagValue request, CallContext context = default)
    {
        return await _commandHandlerAsync.ExecuteWithResponseAsync<SetTagValue, App.Dto.Res.Biz.SetTagValue>(_loggerFactory, _componentContext, request, context.CancellationToken);
    }

    public async ValueTask<App.Dto.Res.Biz.GetTagValue> GetTagValueAsync(GetTagValue request, CallContext context = default)
    {
        ;
        return await _commandHandlerAsync.ExecuteWithResponseAsync<GetTagValue, App.Dto.Res.Biz.GetTagValue>(_loggerFactory, _componentContext, request);
    }

    #endregion
}