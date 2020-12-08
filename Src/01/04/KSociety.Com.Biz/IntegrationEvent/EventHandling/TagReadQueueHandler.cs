using Autofac;
using KSociety.Base.EventBus.Handlers;
using KSociety.Com.Biz.IntegrationEvent.Event;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Biz.IntegrationEvent.EventHandling
{
    public class TagReadQueueHandler : IntegrationQueueHandler<TagReadIntegrationEvent>
    {

        public TagReadQueueHandler(
            ILoggerFactory loggerFactory,
            IComponentContext componentContext
        ) : base(loggerFactory, componentContext)
        {

        }
    }
}
