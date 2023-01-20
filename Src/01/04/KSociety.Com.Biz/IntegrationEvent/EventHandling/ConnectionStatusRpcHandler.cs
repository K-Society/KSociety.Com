using System;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using KSociety.Base.EventBus.Handlers;
using KSociety.Com.Biz.Event;
using KSociety.Com.Biz.Interface;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Biz.IntegrationEvent.EventHandling;

public class ConnectionStatusRpcHandler : IntegrationRpcHandler<ConnectionStatusIntegrationEvent, ConnectionStatusIntegrationEventReply>
{
    private readonly IBiz _biz;

    public ConnectionStatusRpcHandler(
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

    public override async ValueTask<ConnectionStatusIntegrationEventReply> HandleRpcAsync(ConnectionStatusIntegrationEvent @event, CancellationToken cancellationToken = default)
    {
        var connectionRead = false;
        var connectionWrite = false;

        try
        {
            connectionRead = _biz.GetConnectionReadStatus(@event.GroupName, @event.ConnectionName);
            connectionWrite = _biz.GetConnectionWriteStatus(@event.GroupName, @event.ConnectionName);
        }catch(Exception ex)
        {
            Logger.LogError(ex, "ConnectionStatusRpcHandler: ");
        }

        return new ConnectionStatusIntegrationEventReply(@event.GroupName + ".automation.connection", @event.GroupName, @event.ConnectionName, connectionRead, connectionWrite);
    }
}