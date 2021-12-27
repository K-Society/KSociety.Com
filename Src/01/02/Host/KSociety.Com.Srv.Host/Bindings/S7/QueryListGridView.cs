using Autofac;

namespace KSociety.Com.Srv.Host.Bindings.S7;

public class QueryListGridView : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<Srv.Behavior.Query.Common.ListKeyValue.Query>().As<Srv.Contract.Query.Common.ListKeyValue.IQuery>();
        builder.RegisterType<Srv.Behavior.Query.Common.ListKeyValue.QueryAsync>().As<Srv.Contract.Query.Common.ListKeyValue.IQueryAsync>();

        builder.RegisterType<Srv.Behavior.Query.S7.ListKeyValue.Query>().As<Srv.Contract.Query.S7.ListKeyValue.IQuery>();
        builder.RegisterType<Srv.Behavior.Query.S7.ListKeyValue.QueryAsync>().As<Srv.Contract.Query.S7.ListKeyValue.IQueryAsync>();
    }
}