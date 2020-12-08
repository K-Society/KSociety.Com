using System.Threading;
using System.Threading.Tasks;
using Autofac;
using KSociety.Base.EventBus.Handlers;
using KSociety.Com.Biz.IntegrationEvent.Event;
using KSociety.Com.Biz.Interface;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Biz.IntegrationEvent.EventHandling
{
    public class TagWriteRpcServerHandler : IntegrationRpcServerHandler<TagWriteIntegrationEvent, TagWriteIntegrationEventReply>
    {
        private readonly IBiz _biz;
        public TagWriteRpcServerHandler(
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

        public override async ValueTask<TagWriteIntegrationEventReply> HandleRpcAsync(TagWriteIntegrationEvent @event, CancellationToken cancellationToken = default)
        {
            //Logger.LogTrace("HandleRpcAsync... " + @event.RoutingKey + " " + @event.ReplyRoutingKey);
            //Logger.LogTrace("HandleRpcAsync... " + @event.RoutingKey);
            var result = await _biz.SetTagValueAsync(@event.GroupName, @event.Name, @event.Value).ConfigureAwait(false);
            //Logger.LogTrace("HandleRpcAsync: " + tagValue);
            //return new TagWriteIntegrationEventReply(@event.GroupName + @event.ReplyRoutingKey, @event.GroupName, @event.Name, @event.CreationDate, result);
            return new TagWriteIntegrationEventReply(@event.ReplyRoutingKey, @event.GroupName, @event.Name, @event.CreationDate, result);
        }
    }
}
