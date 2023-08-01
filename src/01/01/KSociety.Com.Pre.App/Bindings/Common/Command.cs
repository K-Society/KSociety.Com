using Autofac;
using KSociety.Com.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.App.Bindings.Common;

public class Command : Module
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

        builder.RegisterType<Srv.Agent.Command.Common.TagGroup>()
            .As<Srv.Agent.Interface.Command.Common.ITagGroup>().SingleInstance();

        builder.RegisterType<Srv.Agent.Command.Common.Tag>()
            .As<Srv.Agent.Interface.Command.Common.ITag>().SingleInstance();

        builder.RegisterType<Srv.Agent.Command.Common.Connection>()
            .As<Srv.Agent.Interface.Command.Common.IConnection>().SingleInstance();
    }
}