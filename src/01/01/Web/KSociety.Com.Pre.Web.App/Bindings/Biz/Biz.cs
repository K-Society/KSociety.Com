using Autofac;
using KSociety.Com.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.Web.App.Bindings.Biz;

public class Biz : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<LoggerFactory>().As<ILoggerFactory>().SingleInstance();
        // Create Logger<T> when ILogger<T> is required.
        builder.RegisterGeneric(typeof(Logger<>))
            .As(typeof(ILogger<>));

        var agentConfiguration = new ComAgentConfiguration("http://localhost:5001", true);
        builder.RegisterInstance(agentConfiguration).As<IComAgentConfiguration>().SingleInstance();

        builder.RegisterType<Srv.Agent.Biz.Biz>()
            .As<Srv.Agent.Interface.Biz.IBiz>().SingleInstance();
    }
}