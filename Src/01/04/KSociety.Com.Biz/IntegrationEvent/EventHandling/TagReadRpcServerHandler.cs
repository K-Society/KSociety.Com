using System.Threading;
using System.Threading.Tasks;
using Autofac;
using KSociety.Base.EventBus.Handlers;
using KSociety.Com.Biz.Event;
using KSociety.Com.Biz.Interface;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Biz.IntegrationEvent.EventHandling;

public class TagReadRpcServerHandler : IntegrationRpcServerHandler<TagReadIntegrationEvent, TagReadIntegrationEventReply>
{
    private readonly IBiz _biz;
    public TagReadRpcServerHandler(
        ILoggerFactory loggerFactory,
        IComponentContext componentContext
    )
        : base(loggerFactory, componentContext)
    {
        if (ComponentContext.IsRegistered<IBiz>())
        {
            _biz = ComponentContext.Resolve<IBiz>();
        }
        else
        {
            Logger.LogError("IBiz not Registered!");
        }
    }

    public override async ValueTask<TagReadIntegrationEventReply> HandleRpcAsync(TagReadIntegrationEvent @event, CancellationToken cancellationToken = default)
    {
        //Logger.LogTrace("TagReadRpcServerHandler HandleRpcAsync... " + @event.RoutingKey + " " + @event.ReplyRoutingKey + " " 
        //+ @event.GroupName + " " + @event.Name);
        ;
        var tagValue = await _biz.GetTagValueAsync(@event.GroupName, @event.Name).ConfigureAwait(false);

        //Logger.LogTrace("HandleRpcAsync: " + tagValue);
        return new TagReadIntegrationEventReply(@event.ReplyRoutingKey, @event.GroupName, @event.Name, @event.CreationDate, tagValue);
    }
}