using Autofac;
using KSociety.Com.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.Web.App.Bindings.Common
{
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

            builder.RegisterType<Model.Class.Command.Common.TagGroup>()
                .As<Model.Interface.Command.Common.ITagGroup>().SingleInstance();

            builder.RegisterType<Model.Class.Command.Common.Tag>()
                .As<Model.Interface.Command.Common.ITag>().SingleInstance();

            builder.RegisterType<Model.Class.Command.Common.Connection>()
                .As<Model.Interface.Command.Common.IConnection>().SingleInstance();

        }
    }
}
