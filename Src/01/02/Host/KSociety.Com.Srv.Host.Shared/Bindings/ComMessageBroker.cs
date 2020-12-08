using System;
using Autofac;
using KSociety.Com.EventBus;
using RabbitMQ.Client;

namespace KSociety.Com.Srv.Host.Shared.Bindings
{
    public class ComMessageBroker : Module
    {
        private readonly bool _debugFlag;

        private readonly string _brokerNameCom;
        private readonly KSociety.Base.EventBus.ExchangeType _exchangeTypeCom;
        private readonly bool _exchangeDurableCom;
        private readonly bool _exchangeAutoDeleteCom;
        private readonly bool _queueDurableCom;
        private readonly bool _queueExclusiveCom;
        private readonly bool _queueAutoDeleteCom;

        private readonly string _mqHostNameCom;
        private readonly string _mqUserNameCom;
        private readonly string _mqPasswordCom;

        public ComMessageBroker(
            string brokerNameCom, KSociety.Base.EventBus.ExchangeType exchangeTypeCom,
            bool exchangeDurableCom, bool exchangeAutoDeleteCom,
            string mqHostNameCom, string mqUserNameCom, string mqPasswordCom,
            bool debugFlag,
            bool queueDurableCom,
            bool queueExclusiveCom,
            bool queueAutoDeleteCom)
        {
            _debugFlag = debugFlag;

            _brokerNameCom = brokerNameCom;
            _exchangeTypeCom = exchangeTypeCom;
            _exchangeDurableCom = exchangeDurableCom;
            _exchangeAutoDeleteCom = exchangeAutoDeleteCom;

            _queueDurableCom = queueDurableCom;
            _queueExclusiveCom = queueExclusiveCom;
            _queueAutoDeleteCom = queueAutoDeleteCom;

            _mqHostNameCom = mqHostNameCom;
            _mqUserNameCom = mqUserNameCom;
            _mqPasswordCom = mqPasswordCom;
        }

        protected override void Load(ContainerBuilder builder)
        {
            var exchangeComDeclareParameters = new ExchangeComDeclareParameters(_brokerNameCom, _exchangeTypeCom, _exchangeDurableCom, _exchangeAutoDeleteCom);
            var queueComDeclareParameters = new QueueComDeclareParameters(_queueDurableCom, _queueExclusiveCom, _queueAutoDeleteCom);

            var rabbitMqConnectionFactoryCom = new ConnectionFactory
            {
                HostName = _mqHostNameCom,
                UserName = _mqUserNameCom,
                Password = _mqPasswordCom,
                AutomaticRecoveryEnabled = true,
                NetworkRecoveryInterval = TimeSpan.FromSeconds(10),
                RequestedHeartbeat = TimeSpan.FromSeconds(10),
                DispatchConsumersAsync = true
            };

            builder.RegisterInstance(exchangeComDeclareParameters).As<IExchangeComDeclareParameters>().SingleInstance();
            builder.RegisterInstance(queueComDeclareParameters).As<IQueueComDeclareParameters>().SingleInstance();
            builder.RegisterInstance(rabbitMqConnectionFactoryCom).As<IConnectionFactory>().SingleInstance();
        }
    }
}
