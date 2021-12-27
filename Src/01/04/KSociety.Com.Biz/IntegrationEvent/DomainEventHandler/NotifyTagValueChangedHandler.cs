using System.Threading;
using System.Threading.Tasks;
using Autofac;
using KSociety.Base.EventBus.Abstractions.EventBus;
using KSociety.Com.Biz.Event;
using KSociety.Com.Biz.Interface;
using KSociety.Com.Domain.Entity.Event;
using MediatR;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Biz.IntegrationEvent.DomainEventHandler;

public class NotifyTagValueChangedHandler
    : INotificationHandler<TagValueChanged>
{
    private readonly ILogger<NotifyTagValueChangedHandler> _logger;
    private readonly IComponentContext _componentContext;
    private readonly IBiz _biz;

    public NotifyTagValueChangedHandler(
        ILogger<NotifyTagValueChangedHandler> logger,
        IComponentContext componentContext
    )
    {
        _logger = logger;
        _componentContext = componentContext;
        if (_componentContext.IsRegistered<IBiz>())
        {
            _biz = _componentContext.Resolve<IBiz>();
        }
        else
        {
            _logger.LogError("IBiz not Registered!");
        }
    }

    public async Task Handle(TagValueChanged notification, CancellationToken cancellationToken)
    {
        //_logger.LogInformation("Business Tag Value Changed: " + 
        //                       notification.Name + " " + 
        //                       notification.Value + " " +
        //                       _startup.TagGroupEventBusInvoke.ContainsKey(notification.Tag.TagGroup.Name));
        //Console.WriteLine("NotifyTagValueChangedHandler Handle: " + notification.Value);
        //_logger.LogTrace("Tag Value Changed: " +
        //                       notification.Name + " " +
        //                       notification.Value);

        //_startup
        //    .TagGroupEventBusInvoke[notification.Tag.TagGroup.Name]
        //    .Publish(
        //        new TagIntegrationEvent(
        //            //notification.Tag.TagGroup.Name + ".automation.read",
        //            notification.Tag.TagGroup.Name + ".automation.invoke",
        //            notification.Tag.TagGroup.Name,
        //            notification.Tag.Name,
        //            notification.Tag.Value,
        //            notification.Timestamp
        //            ));

        await ((IEventBusQueue)_biz
                .TagGroupEventBus[notification.Tag.TagGroup.Name + "_Invoke"])
            .Publish(
                new TagIntegrationEvent(
                    //notification.Tag.TagGroup.Name + ".automation.read",
                    notification.Tag.TagGroup.Name + ".automation.invoke",
                    notification.Tag.TagGroup.Name,
                    notification.Tag.Name,
                    notification.Tag.Value,
                    notification.Timestamp
                )).ConfigureAwait(false);

        //_startup
        //    .TagGroupEventBusRead[notification.Tag.TagGroup.Name]
        //    .PublishRpc(
        //        new TagIntegrationEvent(
        //            //notification.Tag.TagGroup.Name + ".automation.read",
        //            notification.Tag.TagGroup.Name + ".automation.read",
        //            notification.Tag.TagGroup.Name,
        //            notification.Tag.Name,
        //            notification.Tag.Value,
        //            notification.Timestamp
        //        ));

        //return Task.CompletedTask;
    }
}