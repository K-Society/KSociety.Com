using System;
using Autofac;
using KSociety.Base.Srv.Host.Shared.Class;
using KSociety.Com.EventBus;
using RabbitMQ.Client;
using ConnectionFactory = RabbitMQ.Client.ConnectionFactory;

namespace KSociety.Com.Srv.Host.Shared.Bindings;

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

    public ComMessageBroker(MessageBrokerOptions messageBroker, bool debug = false)
    {
        _debugFlag = debug;
        _brokerNameCom = messageBroker.ExchangeDeclareParameters.BrokerName;
        _exchangeTypeCom = messageBroker.ExchangeDeclareParameters.ExchangeType;
        _exchangeDurableCom = messageBroker.ExchangeDeclareParameters.ExchangeDurable;
        _exchangeAutoDeleteCom = messageBroker.ExchangeDeclareParameters.ExchangeAutoDelete;

        _queueDurableCom = messageBroker.QueueDeclareParameters.QueueDurable;
        _queueExclusiveCom = messageBroker.QueueDeclareParameters.QueueExclusive;
        _queueAutoDeleteCom = messageBroker.QueueDeclareParameters.QueueAutoDelete;

        _mqHostNameCom = messageBroker.ConnectionFactory.MqHostName;
        _mqUserNameCom = messageBroker.ConnectionFactory.MqUserName;
        _mqPasswordCom = messageBroker.ConnectionFactory.MqPassword;
    }

    protected override void Load(ContainerBuilder builder)
    {
        var exchangeComDeclareParameters = new ExchangeComDeclareParameters(_brokerNameCom, _exchangeTypeCom, _exchangeDurableCom, _exchangeAutoDeleteCom);
        var queueComDeclareParameters = new QueueComDeclareParameters(_queueDurableCom, _queueExclusiveCom, _queueAutoDeleteCom);
        var eventBusComParameters = new EventBusComParameters(exchangeComDeclareParameters, queueComDeclareParameters, _debugFlag);

        var rabbitMqConnectionFactoryCom = new ConnectionFactory
        {
            HostName = _mqHostNameCom,
            UserName = _mqUserNameCom,
            Password = _mqPasswordCom,
            AutomaticRecoveryEnabled = true,
            NetworkRecoveryInterval = TimeSpan.FromSeconds(10),
            RequestedHeartbeat = TimeSpan.FromSeconds(10),
            ContinuationTimeout = TimeSpan.FromSeconds(120),
            DispatchConsumersAsync = true
        };

        builder.RegisterInstance(exchangeComDeclareParameters).As<IExchangeComDeclareParameters>().SingleInstance();
        builder.RegisterInstance(queueComDeclareParameters).As<IQueueComDeclareParameters>().SingleInstance();
        builder.RegisterInstance(eventBusComParameters).As<IEventBusComParameters>().SingleInstance();
        builder.RegisterInstance(rabbitMqConnectionFactoryCom).As<IConnectionFactory>().SingleInstance();
    }
}