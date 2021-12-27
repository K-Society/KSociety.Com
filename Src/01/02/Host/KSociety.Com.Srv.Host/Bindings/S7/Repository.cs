using Autofac;
using KSociety.Base.Infra.Shared.Class;

namespace KSociety.Com.Srv.Host.Bindings.S7;

public class Repository<TContext> : Module where TContext : DatabaseContext
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<Infra.DataAccess.Repository.S7.Area<TContext>>()
            .As<Domain.Repository.S7.IArea>();
        builder.RegisterType<Infra.DataAccess.Repository.S7.BlockArea<TContext>>()
            .As<Domain.Repository.S7.IBlockArea>();
        builder.RegisterType<Infra.DataAccess.Repository.S7.Connection<TContext>>()
            .As<Domain.Repository.S7.IConnection>();
        builder.RegisterType<Infra.DataAccess.Repository.S7.ConnectionType<TContext>>()
            .As<Domain.Repository.S7.IConnectionType>();
        builder.RegisterType<Infra.DataAccess.Repository.S7.CpuType<TContext>>()
            .As<Domain.Repository.S7.ICpuType>();
        builder.RegisterType<Infra.DataAccess.Repository.S7.WordLen<TContext>>()
            .As<Domain.Repository.S7.IWordLen>();
        builder.RegisterType<Infra.DataAccess.Repository.S7.Tag<TContext>>()
            .As<Domain.Repository.S7.ITag>();
    }
}