using Autofac;
using KSociety.Com.Domain.Repository.View.Joined;

namespace KSociety.Com.Srv.Host.Bindings
{
    public class QueryViewJoinedListGridView : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Infra.DataAccess.Repository.View.Joined.AllConnection>().As<IAllConnection>(); 
            builder.RegisterType<Infra.DataAccess.Repository.View.Joined.AllTagGroupAllConnection>().As<IAllTagGroupAllConnection>(); 
            builder.RegisterType<Infra.DataAccess.Repository.View.Joined.AllTagGroupConnection>().As<IAllTagGroupConnection>(); 
        }
    }
}
