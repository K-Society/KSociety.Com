using Autofac;
using KSociety.Com.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.Web.App.Bindings.Common
{
    public class QueryListKeyValue : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LoggerFactory>().As<ILoggerFactory>().SingleInstance();
            // Create Logger<T> when ILogger<T> is required.
            builder.RegisterGeneric(typeof(Logger<>))
                .As(typeof(ILogger<>));

            //// Use NLogLoggerFactory as a factory required by Logger<T>.
            //builder.RegisterType<NLogLoggerFactory>()
            //    .AsImplementedInterfaces().InstancePerLifetimeScope();

            var agentConfiguration = new ComAgentConfiguration("http://localhost:5001", true);
            builder.RegisterInstance(agentConfiguration).As<IComAgentConfiguration>().SingleInstance();

            builder.RegisterType<KSociety.Com.Srv.Agent.Query.Common.ListKeyValue.AutomationTypeId>()
                .As<KSociety.Com.Srv.Agent.Interface.Query.Common.ListKeyValue.IAutomationTypeId>().SingleInstance();

            builder.RegisterType<KSociety.Com.Srv.Agent.Query.Common.ListKeyValue.AnalogDigitalSignal>()
                .As<KSociety.Com.Srv.Agent.Interface.Query.Common.ListKeyValue.IAnalogDigitalSignal>().SingleInstance();

            builder.RegisterType<KSociety.Com.Srv.Agent.Query.Common.ListKeyValue.InputOutput>()
                .As<KSociety.Com.Srv.Agent.Interface.Query.Common.ListKeyValue.IInputOutput>().SingleInstance();

            builder.RegisterType<KSociety.Com.Srv.Agent.Query.Common.ListKeyValue.ConnectionId>()
                .As<KSociety.Com.Srv.Agent.Interface.Query.Common.ListKeyValue.IConnectionId>().SingleInstance();

            builder.RegisterType<KSociety.Com.Srv.Agent.Query.Common.ListKeyValue.TagGroupId>()
                .As<KSociety.Com.Srv.Agent.Interface.Query.Common.ListKeyValue.ITagGroupId>().SingleInstance();
        }
    }
}
