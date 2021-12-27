using Autofac;
using KSociety.Base.Infra.Shared.Class;

namespace KSociety.Com.Srv.Host.Bindings.Common;

public class Repository<TContext> : Module where TContext : DatabaseContext
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<Infra.DataAccess.Repository.Common.AnalogDigital<TContext>>().As<Domain.Repository.Common.IAnalogDigital>();
        builder.RegisterType<Infra.DataAccess.Repository.Common.TagGroup<TContext>>().As<Domain.Repository.Common.ITagGroup>();
        builder.RegisterType<Infra.DataAccess.Repository.Common.AutomationType<TContext>>().As<Domain.Repository.Common.IAutomationType>();
        builder.RegisterType<Infra.DataAccess.Repository.Common.InOut<TContext>>().As<Domain.Repository.Common.IInOut>();
        builder.RegisterType<Infra.DataAccess.Repository.Common.Connection<TContext>>().As<Domain.Repository.Common.IConnection>();
        builder.RegisterType<Infra.DataAccess.Repository.Common.Bit<TContext>>().As<Domain.Repository.Common.IBit>();
        builder.RegisterType<Infra.DataAccess.Repository.Common.Tag<TContext>>().As<Domain.Repository.Common.ITag>();
    }
}