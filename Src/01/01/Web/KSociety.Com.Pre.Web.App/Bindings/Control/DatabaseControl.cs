using Autofac;
using KSociety.Base.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.Web.App.Bindings.Control
{
    public class DatabaseControl : Module
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

            var agentConfiguration = new AgentConfiguration("http://localhost:5001", true);
            builder.RegisterInstance(agentConfiguration).As<IAgentConfiguration>().SingleInstance();

            builder.RegisterType<KSociety.Base.Pre.Model.Control.DatabaseControl>()
                .As<KSociety.Base.Pre.Model.Control.IDatabaseControl>().SingleInstance();
        }
    }
}
