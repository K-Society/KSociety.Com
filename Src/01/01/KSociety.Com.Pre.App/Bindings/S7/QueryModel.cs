using Autofac;
using KSociety.Com.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.App.Bindings.S7;

public class QueryModel : Module
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

        builder.RegisterType<KSociety.Com.Srv.Agent.Query.S7.Model.S7Tag>()
            .As<KSociety.Com.Srv.Agent.Interface.Query.S7.Model.IS7Tag>().SingleInstance();

        builder.RegisterType<KSociety.Com.Srv.Agent.Query.S7.Model.S7Connection>()
            .As<KSociety.Com.Srv.Agent.Interface.Query.S7.Model.IS7Connection>().SingleInstance();

    }
}