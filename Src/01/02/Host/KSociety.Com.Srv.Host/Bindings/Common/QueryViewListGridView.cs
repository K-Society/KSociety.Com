using Autofac;

namespace KSociety.Com.Srv.Host.Bindings.Common;

public class QueryViewListGridView : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<Infra.DataAccess.Repository.View.Common.TagGroupReady>().As<Domain.Repository.View.Common.ITagGroupReady>();
    }
}