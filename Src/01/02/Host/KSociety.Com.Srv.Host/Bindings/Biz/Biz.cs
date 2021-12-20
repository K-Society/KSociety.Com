﻿using Autofac;
using KSociety.Base.InfraSub.Shared.Interface;
using KSociety.Base.Srv.Shared.Class;
using KSociety.Com.Biz.IntegrationEvent.DomainEventHandler;
using KSociety.Com.Biz.Interface;

namespace KSociety.Com.Srv.Host.Bindings.Biz;

public class Biz : Module
{
    private readonly bool _debugFlag;

    public Biz(bool debugFlag)
    {
        _debugFlag = debugFlag;

        //_mqHostName = "localhost";//mqHostName;
        //_mqUserName = "KSociety";//mqUserName;
        //_mqPassword = "KSociety";//mqPassword;
        ////_mqUserName = "guest";//mqUserName;
        ////_mqPassword = "guest";//mqPassword;
    }
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<NotifyTagValueChangedHandler>().AsImplementedInterfaces().InstancePerDependency();

        builder.RegisterType<Infra.DataAccess.Repository.View.Common.TagGroupReady>()
            .As<Domain.Repository.View.Common.ITagGroupReady>(); //.InstancePerLifetimeScope();

        builder.RegisterType<NotifierMediatorService>().As<INotifierMediatorService>();

        builder.RegisterType<Com.Biz.Class.Biz>().As<IBiz>().SingleInstance();
        builder.RegisterType<Com.Biz.Class.Startup>().As<IStartable>().SingleInstance();

        //builder.RegisterType<Srv.Behavior.Biz.Biz>().As<Srv.Contract.Biz.IBiz>();
        //builder.RegisterType<Srv.Behavior.Biz.BizAsync>().As<Srv.Contract.Biz.IBizAsync>();
    }
}