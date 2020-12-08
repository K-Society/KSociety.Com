using Autofac;
using KSociety.Base.EventBus.Handlers;
using KSociety.Com.Biz.IntegrationEvent.Event;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Biz.IntegrationEvent.EventHandling
{
    public class TagInvokeQueueHandler : IntegrationQueueHandler<TagIntegrationEvent>
    {

        public TagInvokeQueueHandler(
            ILoggerFactory loggerFactory,
            IComponentContext componentContext
        ) : base(loggerFactory, componentContext)
        {

        }
    }
}
