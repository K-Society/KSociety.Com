using Autofac;
using KSociety.Com.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.Web.App.Bindings.Common
{
    public class Query : Module
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

            //builder.RegisterType<Model.Class.Query.Common.List.GridView.TagGroup>().As<Model.Interface.Query.Common.List.GridView.ITagGroup>();
            //builder.RegisterType<Model.Class.Query.Common.TagGroup>().As<Model.Interface.Query.Common.ITagGroup>()
            //    .SingleInstance();

            builder.RegisterType<KSociety.Com.Srv.Agent.Query.Common.TagGroup>().As<KSociety.Com.Srv.Agent.Interface.Query.Common.ITagGroup>()
                .SingleInstance();

            builder.RegisterType<KSociety.Com.Srv.Agent.Query.Common.Tag>().As<KSociety.Com.Srv.Agent.Interface.Query.Common.ITag>()
                .SingleInstance();

            builder.RegisterType<KSociety.Com.Srv.Agent.Query.Common.Connection>().As<KSociety.Com.Srv.Agent.Interface.Query.Common.IConnection>()
                .SingleInstance();
        }
    }
}
