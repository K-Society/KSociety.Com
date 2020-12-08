using Autofac;

namespace KSociety.Com.Srv.Host.Bindings.Common
{
    public class Repository : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Infra.DataAccess.Repository.Common.AnalogDigital>().As<Domain.Repository.Common.IAnalogDigital>();
            builder.RegisterType<Infra.DataAccess.Repository.Common.TagGroup>().As<Domain.Repository.Common.ITagGroup>();
            builder.RegisterType<Infra.DataAccess.Repository.Common.AutomationType>().As<Domain.Repository.Common.IAutomationType>();
            builder.RegisterType<Infra.DataAccess.Repository.Common.InOut>().As<Domain.Repository.Common.IInOut>();
            builder.RegisterType<Infra.DataAccess.Repository.Common.Connection>().As<Domain.Repository.Common.IConnection>();
            builder.RegisterType<Infra.DataAccess.Repository.Common.Bit>().As<Domain.Repository.Common.IBit>();
            builder.RegisterType<Infra.DataAccess.Repository.Common.Tag>().As<Domain.Repository.Common.ITag>();
        }
    }
}
