using Autofac;

namespace KSociety.Com.Srv.Host.Bindings.Logix;

public class Repository : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<Infra.DataAccess.Repository.Logix.Connection>()
            .As<Domain.Repository.Logix.IConnection>();
        builder.RegisterType<Infra.DataAccess.Repository.Logix.Tag>()
            .As<Domain.Repository.Logix.ITag>();
    }
}