using Autofac;
using KSociety.Base.Infra.Shared.Class;
using KSociety.Base.InfraSub.Shared.Interface;
using KSociety.Base.Srv.Shared.Class;
using KSociety.Com.Biz.IntegrationEvent.DomainEventHandler;
using KSociety.Com.Biz.Interface;

namespace KSociety.Com.Srv.Host.Bindings.Biz;

public class Biz<TContext> : Module where TContext : DatabaseContext
{
    private readonly bool _debugFlag;

    public Biz(bool debugFlag)
    {
        _debugFlag = debugFlag;
    }
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<NotifyTagValueChangedHandler>().AsImplementedInterfaces().InstancePerDependency();

        builder.RegisterType<Infra.DataAccess.Repository.View.Common.TagGroupReady<TContext>>()
            .As<Domain.Repository.View.Common.ITagGroupReady>();

        builder.RegisterType<NotifierMediatorService>().As<INotifierMediatorService>();

        builder.RegisterType<Com.Biz.Class.Biz>().As<IBiz>().SingleInstance();
        builder.RegisterType<Com.Biz.Class.Startup>().As<IStartable>().SingleInstance();
    }
}