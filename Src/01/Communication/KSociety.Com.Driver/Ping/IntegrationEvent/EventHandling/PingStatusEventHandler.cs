using System.Threading;
using System.Threading.Tasks;
using KSociety.Base.EventBus.Abstractions.Handler;
using KSociety.Com.Driver.Ping.IntegrationEvent.Event;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Driver.Ping.IntegrationEvent.EventHandling
{
    public class PingStatusEventHandler : IIntegrationEventHandler<PingStatusIntegrationEvent>
    {
        protected readonly string Name;

        protected readonly ILogger<PingStatusEventHandler> Logger;
        //private readonly IAutomation _automation;


        public PingStatusEventHandler(string name, ILogger<PingStatusEventHandler> logger)
        {
            Name = name;
            Logger = logger;
        }

        //public PingStatusEventHandler(string name, ILogger logger, IAutomation automation)
        //{
        //    _name = name;
        //    _logger = logger;
        //    _automation = automation;
        //}

        public virtual async ValueTask Handle(PingStatusIntegrationEvent @event,
            CancellationToken cancellationToken = default)
        {
            if (@event.Status)
            {
                Logger.LogInformation("Ping " + Name + ": " + @event.Name + " " + @event.Address + " " + @event.Status +
                                      " " +
                                      @event.CreationDate);
            }
            else
            {
                Logger.LogError("Ping " + Name + ": " + @event.Name + " " + @event.Address + " " + @event.Status + " " +
                                @event.CreationDate);
            }


            //if (_automation is null)
            //{

            //}
            //else
            //{
            //    //_automation.
            //}

            await Task.CompletedTask.ConfigureAwait(false);
        }
    }
}