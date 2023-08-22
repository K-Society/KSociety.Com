using Autofac;
using KSociety.Base.Infra.Abstraction.Class;
using KSociety.Base.Infra.Shared.Class;
using KSociety.Base.InfraSub.Shared.Class;
using KSociety.Base.Srv.Host.Shared.Bindings;
using KSociety.Base.Srv.Host.Shared.Class;
using KSociety.Com.EventBus;
using KSociety.Com.Infra.Transfer.MySql;
using KSociety.Com.Infra.Transfer.Npgsql;
using KSociety.Com.Infra.Transfer.Sqlite;
using KSociety.Com.Infra.Transfer.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProtoBuf.Grpc.Server;
using RabbitMQ.Client;
using System;

namespace KSociety.Com.Srv.Host;

public class Startup
{
    public ILifetimeScope AutofacContainer { get; private set; }

    private bool DebugFlag { get; }
    private MessageBrokerOptions ComMessageBrokerOptions { get; }
    private DatabaseOptions DatabaseOptions { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
        DebugFlag = Configuration.GetValue<bool>("DebugFlag");

        ComMessageBrokerOptions = Configuration.GetSection("MessageBroker").Get<MessageBrokerOptions>();
        DatabaseOptions = Configuration.GetSection("Database").Get<DatabaseOptions>();
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
        try
        {
            KSociety.Com.Srv.Contract.ProtoModel.Configuration.ProtoBufConfiguration();
            services.AddCodeFirstGrpc();
            //services.Configure<ConsoleLifetimeOptions>(opts => opts.SuppressStatusMessages = true);
        }
        catch (Exception ex)
        {
            Console.WriteLine(@"Startup ConfigureServices: " + ex.Message + " " + ex.StackTrace);
        }
    }

    // ConfigureContainer is where you can register things directly
    // with Autofac. This runs after ConfigureServices so the things
    // here will override registrations made in ConfigureServices.
    // Don't build the container; that gets done for you by the factory.
    public void ConfigureContainer(ContainerBuilder builder)
    {
        switch (DatabaseOptions.DatabaseEngine)
        {
            case DatabaseEngine.Sqlserver:
                RegisterModule<SqlServerComContext>(builder);
                break;

            case DatabaseEngine.Sqlite:
                RegisterModule<SqliteComContext>(builder);
                break;

            case DatabaseEngine.Npgsql:
                RegisterModule<NpgsqlComContext>(builder);
                break;

            case DatabaseEngine.Mysql:
                RegisterModule<MySqlComContext>(builder);
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void RegisterModule<TContext>(ContainerBuilder builder) where TContext : DatabaseContext
    {
        try
        {
            //Log.
            builder.RegisterModule(new Base.Srv.Host.Shared.Bindings.Log());

            //AutoMapper.
            builder.RegisterModule(new KSociety.Base.Srv.Host.Shared.Bindings.AutoMapper(AssemblyTool.GetAssembly()));

            //DatabaseConfiguration.
            builder.RegisterModule(new KSociety.Base.Infra.Abstraction.Bindings.DatabaseConfiguration(DatabaseOptions));

            //MediatR.
            builder.RegisterModule(new KSociety.Base.Srv.Host.Shared.Bindings.Mediatr());

            //Common.
            builder.RegisterModule(new Bindings.Common.Repository<TContext>());
            builder.RegisterModule(new Bindings.Common.QueryListGridView());
            builder.RegisterModule(new Bindings.Common.QueryModel());
            builder.RegisterModule(new Bindings.Common.QueryViewListGridView<TContext>());

            //S7
            builder.RegisterModule(new Bindings.S7.Repository<TContext>());
            builder.RegisterModule(new Bindings.S7.QueryListGridView());
            builder.RegisterModule(new Bindings.S7.QueryModel());

            //Logix
            builder.RegisterModule(new Bindings.Logix.Repository<TContext>());

            builder.RegisterModule(new Bindings.QueryViewJoinedListGridView<TContext>());

            //UnitOfWork.
            builder.RegisterModule(new KSociety.Base.Infra.Shared.Bindings.UnitOfWork<TContext>());

            builder.RegisterModule(new KSociety.Base.Infra.Shared.Bindings.DatabaseControl<TContext>());
            builder.RegisterModule(new KSociety.Base.App.Utility.Bindings.DatabaseControlHdlr());
            
            //CommandHandler.
            builder.RegisterModule(new KSociety.Base.Srv.Host.Shared.Bindings.CommandHdlr(AssemblyTool.GetAssembly()));

            //DatabaseFactory
            builder.RegisterModule(new KSociety.Base.Infra.Shared.Bindings.DatabaseFactory<TContext>());

            //RabbitMQ.
            builder.RegisterModule(
                new MessageBroker<
                    IExchangeComDeclareParameters,
                    IQueueComDeclareParameters,
                    IEventBusComParameters,
                    IConnectionFactory,
                    ExchangeComDeclareParameters,
                    QueueComDeclareParameters,
                    EventBusComParameters>(ComMessageBrokerOptions, DebugFlag));
            //Biz.
            builder.RegisterModule(new Bindings.Biz.Biz<TContext>(DebugFlag));
        }
        catch (Exception ex)
        {
            Console.WriteLine(@"RegisterModule: " + ex.Message + " " + ex.StackTrace);
        }
    }
    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseMiddleware<ErrorHandlerMiddleware>();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGrpcService<KSociety.Base.Srv.Behavior.Control.DatabaseControl>();
            endpoints.MapGrpcService<KSociety.Base.Srv.Behavior.Control.DatabaseControlAsync>();

            endpoints.MapGrpcService<Srv.Behavior.Command.Common.Tag>();
            endpoints.MapGrpcService<Srv.Behavior.Command.Common.TagAsync>();
            endpoints.MapGrpcService<Srv.Behavior.Command.Common.TagGroup>();
            endpoints.MapGrpcService<Srv.Behavior.Command.Common.TagGroupAsync>();
            endpoints.MapGrpcService<Srv.Behavior.Command.Common.Connection>();
            endpoints.MapGrpcService<Srv.Behavior.Command.Common.ConnectionAsync>();

            endpoints.MapGrpcService<Srv.Behavior.Command.Logix.Tag>();
            endpoints.MapGrpcService<Srv.Behavior.Command.Logix.TagAsync>();
            endpoints.MapGrpcService<Srv.Behavior.Command.Logix.Connection>();
            endpoints.MapGrpcService<Srv.Behavior.Command.Logix.ConnectionAsync>();

            endpoints.MapGrpcService<Srv.Behavior.Command.S7.Tag>();
            endpoints.MapGrpcService<Srv.Behavior.Command.S7.TagAsync>();
            endpoints.MapGrpcService<Srv.Behavior.Command.S7.Connection>();
            endpoints.MapGrpcService<Srv.Behavior.Command.S7.ConnectionAsync>();

            endpoints.MapGrpcService<Srv.Behavior.Query.Common.Query>();
            endpoints.MapGrpcService<Srv.Behavior.Query.Common.QueryAsync>();

            endpoints.MapGrpcService<Srv.Behavior.Query.Common.Model.Query>();
            endpoints.MapGrpcService<Srv.Behavior.Query.Common.Model.QueryAsync>();

            endpoints.MapGrpcService<Srv.Behavior.Query.Common.ListKeyValue.Query>();
            endpoints.MapGrpcService<Srv.Behavior.Query.Common.ListKeyValue.QueryAsync>();

            endpoints.MapGrpcService<Srv.Behavior.Query.Common.List.GridView.Query>();
            endpoints.MapGrpcService<Srv.Behavior.Query.Common.List.GridView.QueryAsync>();

            endpoints.MapGrpcService<Srv.Behavior.Query.Logix.List.GridView.Query>();
            endpoints.MapGrpcService<Srv.Behavior.Query.Logix.List.GridView.QueryAsync>();

            endpoints.MapGrpcService<Srv.Behavior.Query.S7.Query>();
            endpoints.MapGrpcService<Srv.Behavior.Query.S7.QueryAsync>();

            endpoints.MapGrpcService<Srv.Behavior.Query.S7.Model.Query>();
            endpoints.MapGrpcService<Srv.Behavior.Query.S7.Model.QueryAsync>();

            endpoints.MapGrpcService<Srv.Behavior.Query.S7.List.GridView.Query>();
            endpoints.MapGrpcService<Srv.Behavior.Query.S7.List.GridView.QueryAsync>();

            endpoints.MapGrpcService<Srv.Behavior.Query.View.Common.List.GridView.Query>();
            endpoints.MapGrpcService<Srv.Behavior.Query.View.Common.List.GridView.QueryAsync>();

            endpoints.MapGrpcService<Srv.Behavior.Query.View.Joined.List.GridView.Query>();
            endpoints.MapGrpcService<Srv.Behavior.Query.View.Joined.List.GridView.QueryAsync>();

            endpoints.MapGrpcService<Srv.Behavior.Biz.Biz>();
            endpoints.MapGrpcService<Srv.Behavior.Biz.BizAsync>();

            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
            });
        });
    }
}