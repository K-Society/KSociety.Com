using KSociety.Base.EventBus;

namespace KSociety.Com.EventBus
{
    public class ExchangeComDeclareParameters : ExchangeDeclareParameters, IExchangeComDeclareParameters
    {
        public ExchangeComDeclareParameters(string brokerName, ExchangeType exchangeType, bool exchangeDurable = false, bool exchangeAutoDelete = false)
        :base(brokerName, exchangeType, exchangeDurable, exchangeAutoDelete)
        {

        }
    }
}
