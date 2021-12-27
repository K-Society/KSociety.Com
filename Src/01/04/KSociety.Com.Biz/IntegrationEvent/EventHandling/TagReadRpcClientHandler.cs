using System.Threading;
using System.Threading.Tasks;
using Autofac;
using KSociety.Base.EventBus.Handlers;
using KSociety.Com.Biz.Event;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Biz.IntegrationEvent.EventHandling;

public class TagReadRpcClientHandler : IntegrationRpcClientHandler<TagReadIntegrationEventReply>
{
    public TagReadRpcClientHandler(ILoggerFactory loggerFactory, IComponentContext componentContext)
        : base(loggerFactory, componentContext)
    {

    }

    public override void HandleReply(TagReadIntegrationEventReply @integrationEventReply, CancellationToken cancel = default)
    {
        //await Queue.SendAsync(@integrationEventReply, cancel).ConfigureAwait(false);
        Logger.LogWarning("TagReadRpcClientHandler HandleRpcAsync: NotImplemented! " + @integrationEventReply.RoutingKey);
        //throw new NotImplementedException();
    }

    public override async ValueTask HandleReplyAsync(TagReadIntegrationEventReply @integrationEventReply, CancellationToken cancel = default)
    {
        //await Queue.SendAsync(@integrationEventReply, cancel).ConfigureAwait(false);
        ;
        Logger.LogWarning("TagReadRpcClientHandler HandleRpcAsync: NotImplemented! " + @integrationEventReply.RoutingKey);
        //throw new NotImplementedException();
    }
}