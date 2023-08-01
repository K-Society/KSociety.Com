using System.Threading;
using System.Threading.Tasks;
using Autofac;
using KSociety.Base.EventBus.Abstractions.Handler;
using KSociety.Com.Biz.Event;
using KSociety.Com.Biz.Interface;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Biz.IntegrationEvent.EventHandling;

public class TagWriteEventHandler : IIntegrationEventHandler<TagIntegrationEvent>
{
    private readonly ILogger _logger;
    private readonly IBiz _biz;
    private readonly IComponentContext _componentContext;

    public TagWriteEventHandler(
        ILoggerFactory loggerFactory,
        IComponentContext componentContext
    )
    {
        _logger = loggerFactory.CreateLogger<TagInvokeEventHandler>();
        _componentContext = componentContext;

        if (_componentContext.IsRegistered<IBiz>())
        {
            _biz = _componentContext.Resolve<IBiz>();
        }
        else
        {
            _logger.LogError("IBiz not Registered!");
        }
    }

    public async ValueTask Handle(TagIntegrationEvent @event, CancellationToken cancellationToken = default)
    {
        //_logger.LogTrace(@event.Timestamp + " Tag Write: " + @event.GroupName + " - " + @event.Name + " - " + @event.Value);

        if (_biz.SystemGroups.ContainsKey(@event.GroupName))
        {
            var group = _biz.SystemGroups[@event.GroupName];

            group.SetTagValue(@event.Name, @event.Value);

            //if (tag.InputOutput.Equals("R") || tag.InputOutput.Equals("RW"))
            //{
            //    _logger.LogTrace(@event.Timestamp + " Tag Read: " + @event.GroupName + " - " + @event.Name + " - " + @event.Value);
            //}else if (tag.InputOutput.Equals("W") || tag.InputOutput.Equals("RW"))
            //{
            //    _logger.LogTrace(@event.Timestamp + " Tag Write: " + @event.GroupName + " - " + @event.Name + " - " + @event.Value);
            //}
        }

        //if (_tag.ContainsKey(@event.Name))
        //{
        //    //    if (_tag[@event.Name].InputOutput.Equals("R") || _tag[@event.Name].InputOutput.Equals("RW"))
        //    //    {
        //    //        //_logger.Info("Read RabbitMQ: " + @event.GroupName + @event.Name + " - " + @event.Value);
        //    //        //_tag[@event.Name].InvokeStatus();

        //    //        //var tag = _tag[@event.Name];
        //    //        //tag.Status
        //    //        //_tag["Tag02"].WriteTagToPlc(@event.Value);
        //    //    }

        //    //    if (_tag[@event.Name].InputOutput.Equals("W") || _tag[@event.Name].InputOutput.Equals("RW"))
        //    //    {
        //    //        _logger.Info("Write RabbitMQ: " + @event.Name + " - " + @event.Value);
        //    //        _tag[@event.Name].WriteTagToPlc(@event.Value);
        //    //    }
        //}

        await Task.CompletedTask.ConfigureAwait(false);
    }
}