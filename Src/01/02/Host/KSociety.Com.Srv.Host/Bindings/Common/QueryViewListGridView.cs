using Autofac;
using KSociety.Base.Infra.Shared.Class;

namespace KSociety.Com.Srv.Host.Bindings.Common;

public class QueryViewListGridView<TContext> : Module where TContext : DatabaseContext
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<Infra.DataAccess.Repository.View.Common.TagGroupReady<TContext>>().As<Domain.Repository.View.Common.ITagGroupReady>();
    }
}