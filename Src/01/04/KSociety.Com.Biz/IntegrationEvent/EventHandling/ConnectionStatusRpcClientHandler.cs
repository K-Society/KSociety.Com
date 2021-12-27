using Autofac;
using KSociety.Base.EventBus.Handlers;
using KSociety.Com.Biz.Event;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.Biz.IntegrationEvent.EventHandling;

public class ConnectionStatusRpcClientHandler : IntegrationRpcClientHandler<ConnectionStatusIntegrationEventReply>
{
    public ConnectionStatusRpcClientHandler(ILoggerFactory loggerFactory, IComponentContext componentContext)
        : base(loggerFactory, componentContext)
    {

    }

    public override void HandleReply(ConnectionStatusIntegrationEventReply @integrationEventReply, CancellationToken cancel = default)
    {
        //await Queue.SendAsync(@integrationEventReply, cancel).ConfigureAwait(false);
        Logger.LogWarning("ConnectionStatusRpcClientHandler HandleRpcAsync: NotImplemented! " + @integrationEventReply.RoutingKey);
        //throw new NotImplementedException();
    }

    public override async ValueTask HandleReplyAsync(ConnectionStatusIntegrationEventReply @integrationEventReply, CancellationToken cancel = default)
    {
        //await Queue.SendAsync(@integrationEventReply, cancel).ConfigureAwait(false);
        ;
        Logger.LogWarning("ConnectionStatusRpcClientHandler HandleRpcAsync: NotImplemented! " + @integrationEventReply.RoutingKey);
        //throw new NotImplementedException();
    }
}