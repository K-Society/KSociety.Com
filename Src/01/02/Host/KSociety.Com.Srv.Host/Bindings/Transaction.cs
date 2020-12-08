using System;
using Autofac;
using KSociety.Base.InfraSub.Shared.Interface;
using KSociety.Base.Srv.Shared.Class;
using KSociety.Com.Biz.IntegrationEvent.DomainEventHandler;
using KSociety.Com.Biz.Interface;

namespace KSociety.Com.Srv.Host.Bindings
{
    public class Transaction : Module
    {
        private readonly bool _debugFlag;

        //private readonly string _mqHostName;
        //private readonly string _mqUserName;
        //private readonly string _mqPassword;

        public Transaction(bool debugFlag)
        {
            _debugFlag = debugFlag;

            //_mqHostName = "localhost";//mqHostName;
            //_mqUserName = "KSociety";//mqUserName;
            //_mqPassword = "KSociety";//mqPassword;
            ////_mqUserName = "guest";//mqUserName;
            ////_mqPassword = "guest";//mqPassword;
        }

        protected override void Load(ContainerBuilder builder)
        {
            try
            {
                //var rabbitMqConnectionFactory = new ConnectionFactory
                //{
                //    HostName = _mqHostName,
                //    UserName = _mqUserName,
                //    Password = _mqPassword,
                //    AutomaticRecoveryEnabled = true,
                //    NetworkRecoveryInterval = TimeSpan.FromSeconds(10)
                //};

                //builder.RegisterInstance(rabbitMqConnectionFactory).As<IConnectionFactory>().SingleInstance();

                builder.RegisterType<NotifyTagValueChangedHandler>().AsImplementedInterfaces().InstancePerDependency();
                //builder.RegisterAssemblyTypes(typeof(NotifyTagEventHandler).GetTypeInfo().Assembly)
                //    .AsClosedTypesOf(typeof(INotificationHandler<>));

                builder.RegisterType<Infra.DataAccess.Repository.View.Common.TagGroupReady>()
                    .As<Domain.Repository.View.Common.ITagGroupReady>(); //.InstancePerLifetimeScope();

                //builder.RegisterType<Std.Infra.Com.DataAccess.Repository.View.Joined.AllTagGroupAllConnection>()
                //    .As<IAllTagGroupAllConnection>(); //.InstancePerLifetimeScope();

                //builder.RegisterType<Std.Infra.Com.DataAccess.Repository.Common.TagGroup>()
                //    .As<Domain.Repository.Common.ITagGroup>(); //.InstancePerLifetimeScope(); //.SingleInstance();

                ////builder.RegisterType<DatabaseFactory<ILoggerFactory, StdDatabaseConfiguration, ComContext>>()
                ////    .As<IDatabaseFactory<ComContext>>(); //.InstancePerLifetimeScope();

                //ToDo
                builder.RegisterType<NotifierMediatorService>().As<INotifierMediatorService>();

                //builder.RegisterType<NotifierMediatorService<NotifyTagEvent>>().As<INotifierMediatorService<NotifyTagEvent>>();

                //builder.RegisterType<Srv.Behavior.Transaction.Transaction>().As<IServiceTransaction>().SingleInstance();

                //builder.RegisterType<Srv.Service.Class.Service>().As<IService>()/*.As<IStartable>()*/.SingleInstance();
                builder.RegisterType<Biz.Class.Biz>().As<IBiz>().SingleInstance();
                builder.RegisterType<Biz.Class.Startup>().As<IStartable>().SingleInstance(); //.InstancePerLifetimeScope();
            }
            catch (Exception ex)
            {
                if (_debugFlag)
                {
                    Console.WriteLine("Transaction: " + ex.Message + " - " + ex.StackTrace);
                }
            }
        }
    }
}
