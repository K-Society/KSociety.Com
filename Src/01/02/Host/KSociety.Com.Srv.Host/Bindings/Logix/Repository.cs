using Autofac;
using KSociety.Base.Infra.Shared.Class;

namespace KSociety.Com.Srv.Host.Bindings.Logix;

public class Repository<TContext> : Module where TContext : DatabaseContext
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<Infra.DataAccess.Repository.Logix.Connection<TContext>>()
            .As<Domain.Repository.Logix.IConnection>();
        builder.RegisterType<Infra.DataAccess.Repository.Logix.Tag<TContext>>()
            .As<Domain.Repository.Logix.ITag>();
    }
}