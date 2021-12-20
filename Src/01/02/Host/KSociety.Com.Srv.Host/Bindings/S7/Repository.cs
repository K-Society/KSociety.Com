using Autofac;

namespace KSociety.Com.Srv.Host.Bindings.S7;

public class Repository : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<Infra.DataAccess.Repository.S7.Area>()
            .As<Domain.Repository.S7.IArea>();
        builder.RegisterType<Infra.DataAccess.Repository.S7.BlockArea>()
            .As<Domain.Repository.S7.IBlockArea>();
        builder.RegisterType<Infra.DataAccess.Repository.S7.Connection>()
            .As<Domain.Repository.S7.IConnection>();
        builder.RegisterType<Infra.DataAccess.Repository.S7.ConnectionType>()
            .As<Domain.Repository.S7.IConnectionType>();
        builder.RegisterType<Infra.DataAccess.Repository.S7.CpuType>()
            .As<Domain.Repository.S7.ICpuType>();
        builder.RegisterType<Infra.DataAccess.Repository.S7.WordLen>()
            .As<Domain.Repository.S7.IWordLen>();
        builder.RegisterType<Infra.DataAccess.Repository.S7.Tag>()
            .As<Domain.Repository.S7.ITag>();
    }
}