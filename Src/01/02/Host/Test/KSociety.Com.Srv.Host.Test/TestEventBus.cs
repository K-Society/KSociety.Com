using System;
using Autofac;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace KSociety.Com.Srv.Host.Test
{
    public class TestEventBus
    {
        protected const bool ExchangeAutoDelete = true;
        protected const bool QueueAutoDelete = true;
        protected ILoggerFactory LoggerFactory;
        protected IConnectionFactory ConnectionFactory;
        protected IRabbitMqPersistentConnection PersistentConnection;
        protected IExchangeDeclareParameters ExchangeDeclareParameters;
        protected IQueueDeclareParameters QueueDeclareParameters;
        protected IComponentContext ComponentContext;
        protected IEventBus EventBus;

        public TestEventBus()
        {
            
            LoggerFactory = Microsoft.Extensions.Logging.LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
                builder.SetMinimumLevel(LogLevel.Trace);
            });

            ConnectionFactory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "KSociety",
                Password = "KSociety",
                AutomaticRecoveryEnabled = true,
                NetworkRecoveryInterval = TimeSpan.FromSeconds(10),
                RequestedHeartbeat = TimeSpan.FromSeconds(10),
                DispatchConsumersAsync = true
            };

            ExchangeDeclareParameters = new ExchangeDeclareParameters("k-society_com", Std.EventBus.ExchangeType.Direct, false, ExchangeAutoDelete);
            QueueDeclareParameters = new QueueDeclareParameters(false, false, QueueAutoDelete);

            PersistentConnection = new DefaultRabbitMqPersistentConnection(ConnectionFactory, LoggerFactory);

            var builder = new ContainerBuilder();
            builder.RegisterModule(new Bindings.Test.Test());
            var container = builder.Build();

            ComponentContext = container.BeginLifetimeScope();
        }
    }
}
