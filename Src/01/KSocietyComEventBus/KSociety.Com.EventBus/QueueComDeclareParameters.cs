using KSociety.Base.EventBus;

namespace KSociety.Com.EventBus;

public class QueueComDeclareParameters : QueueDeclareParameters, IQueueComDeclareParameters
{
    public QueueComDeclareParameters(bool queueDurable, bool queueExclusive, bool queueAutoDelete)
        :base(queueDurable, queueExclusive, queueAutoDelete)
    {

    }
}