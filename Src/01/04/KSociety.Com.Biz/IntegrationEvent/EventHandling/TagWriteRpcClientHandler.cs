using System.Threading;
using System.Threading.Tasks;
using Autofac;
using KSociety.Base.EventBus.Handlers;
using KSociety.Com.Biz.Event;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Biz.IntegrationEvent.EventHandling
{
    public class TagWriteRpcClientHandler : IntegrationRpcClientHandler<TagWriteIntegrationEventReply>
    {
        public TagWriteRpcClientHandler(ILoggerFactory loggerFactory, IComponentContext componentContext)
            : base(loggerFactory, componentContext)
        {

        }

        public override void HandleReply(TagWriteIntegrationEventReply @integrationEventReply, CancellationToken cancel = default)
        {
            //await Queue.SendAsync(@integrationEventReply, cancel).ConfigureAwait(false);
            Logger.LogWarning("TagWriteRpcClientHandler HandleReply: NotImplemented! " + @integrationEventReply.RoutingKey);
            //throw new NotImplementedException();
        }

        public override async ValueTask HandleReplyAsync(TagWriteIntegrationEventReply @integrationEventReply, CancellationToken cancel = default)
        {
            //await Queue.SendAsync(@integrationEventReply, cancel).ConfigureAwait(false);
            Logger.LogWarning("TagWriteRpcClientHandler HandleReplyAsync: NotImplemented! " + @integrationEventReply.RoutingKey);
            //throw new NotImplementedException();
        }
    }
}
