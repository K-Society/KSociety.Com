using KSociety.Base.EventBus;

namespace KSociety.Com.EventBus;

public class EventBusComParameters : EventBusParameters, IEventBusComParameters
{
    public EventBusComParameters() { }

    public EventBusComParameters(IExchangeComDeclareParameters exchangeDeclareParameters,
        IQueueComDeclareParameters queueDeclareParameters, bool debug = false)
        : base(exchangeDeclareParameters, queueDeclareParameters, debug)
    {

    }
}