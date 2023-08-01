using Autofac;
using KSociety.Com.Pre.App.Bindings.Common;
using KSociety.Com.Pre.App.Bindings.Control;
using KSociety.Com.Pre.App.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace KSociety.Com.Pre.App;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
        KSociety.Com.Srv.Contract.ProtoModel.Configuration.ProtoBufConfiguration();
        services.AddRazorPages();
        services.AddServerSideBlazor();
        services.AddSingleton<WeatherForecastService>();
    }

    // ConfigureContainer is where you can register things directly
    // with Autofac. This runs after ConfigureServices so the things
    // here will override registrations made in ConfigureServices.
    // Don't build the container; that gets done for you by the factory.
    public void ConfigureContainer(ContainerBuilder builder)
    {
        try
        {
            //Log.
            //builder.RegisterModule(new Log());

            builder.RegisterModule(new DatabaseControl());

            builder.RegisterModule(new Query());
            builder.RegisterModule(new QueryListKeyValue());
            builder.RegisterModule(new QueryListGridView());
            builder.RegisterModule(new QueryModel());
            builder.RegisterModule(new Command());

            builder.RegisterModule(new Bindings.S7.Query());
            builder.RegisterModule(new Bindings.S7.QueryListGridView());
            builder.RegisterModule(new Bindings.S7.QueryModel());
            builder.RegisterModule(new Bindings.S7.Command());
        }
        catch (Exception ex)
        {
            Console.WriteLine(@"Autofac ConfigureContainer: " + ex.Message + " " + ex.StackTrace);
        }
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
        }

        app.UseStaticFiles();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapBlazorHub();
            endpoints.MapFallbackToPage("/_Host");
        });
    }
}