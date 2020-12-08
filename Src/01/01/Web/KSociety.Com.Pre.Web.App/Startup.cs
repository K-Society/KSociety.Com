using System;
using Autofac;
using KSociety.Com.Pre.Web.App.Bindings.Common;
using KSociety.Com.Pre.Web.App.Bindings.Control;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KSociety.Com.Pre.Web.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Srv.Agent.ProtoModel.Configuration.ProtoBufConfiguration();
            services.AddControllersWithViews();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Common",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "S7",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "Logix",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
