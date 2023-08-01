using Autofac;
using KSociety.Base.Infra.Shared.Class;
using KSociety.Com.Domain.Repository.View.Joined;

namespace KSociety.Com.Srv.Host.Bindings;

public class QueryViewJoinedListGridView<TContext> : Module where TContext : DatabaseContext
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<Infra.DataAccess.Repository.View.Joined.AllConnection<TContext>>().As<IAllConnection>(); 
        builder.RegisterType<Infra.DataAccess.Repository.View.Joined.AllTagGroupAllConnection<TContext>>().As<IAllTagGroupAllConnection>(); 
        builder.RegisterType<Infra.DataAccess.Repository.View.Joined.AllTagGroupConnection<TContext>>().As<IAllTagGroupConnection>(); 
    }
}