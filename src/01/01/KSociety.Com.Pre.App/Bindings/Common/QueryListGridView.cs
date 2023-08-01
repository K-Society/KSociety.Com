using Autofac;
using KSociety.Com.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.App.Bindings.Common;

public class QueryListGridView : Module
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

        //builder.RegisterType<Model.Class.Query.Common.List.GridView.TagGroup>()
        //    .As<Model.Interface.Query.Common.List.GridView.ITagGroup>().SingleInstance();

        //builder.RegisterType<Model.Class.Query.Common.List.GridView.Tag>()
        //    .As<Model.Interface.Query.Common.List.GridView.ITag>().SingleInstance();

        //builder.RegisterType<Model.Class.Query.Common.List.GridView.Connection>()
        //    .As<Model.Interface.Query.Common.List.GridView.IConnection>().SingleInstance();

        builder.RegisterType<KSociety.Com.Srv.Agent.Query.Common.List.GridView.TagGroup>()
            .As<KSociety.Com.Srv.Agent.Interface.Query.Common.List.GridView.ITagGroup>().SingleInstance();

        builder.RegisterType<KSociety.Com.Srv.Agent.Query.Common.List.GridView.Tag>()
            .As<KSociety.Com.Srv.Agent.Interface.Query.Common.List.GridView.ITag>().SingleInstance();

        builder.RegisterType<KSociety.Com.Srv.Agent.Query.Common.List.GridView.Connection>()
            .As<KSociety.Com.Srv.Agent.Interface.Query.Common.List.GridView.IConnection>().SingleInstance();

    }
}