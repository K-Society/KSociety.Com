using KSociety.Base.EventBus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSociety.Com.Biz.Event;
using KSociety.Com.Biz.Interface;
using Microsoft.Extensions.Logging;
using Autofac;
using System.Threading;

namespace KSociety.Com.Biz.IntegrationEvent.EventHandling
{
    public class ConnectionStatusRpcServerHandler : IntegrationRpcServerHandler<ConnectionStatusIntegrationEvent, ConnectionStatusIntegrationEventReply>
    {
        private readonly IBiz _biz;
        public ConnectionStatusRpcServerHandler(
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

            var connectionRead = _biz.GetConnectionReadStatus(@event.GroupName, @event.ConnectionName); 
            var connectionWrite = _biz.GetConnectionWriteStatus(@event.GroupName, @event.ConnectionName);

            return new ConnectionStatusIntegrationEventReply(@event.ReplyRoutingKey, @event.GroupName, @event.ConnectionName, connectionRead, connectionWrite);
        }
    }
}
