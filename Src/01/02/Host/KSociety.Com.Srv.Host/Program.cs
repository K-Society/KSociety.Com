using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Net;
using System.Threading.Tasks;

namespace KSociety.Com.Srv.Host
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            KSociety.Log.Serilog.Sinks.RabbitMq.ProtoModel.Configuration.ProtoBufConfiguration();
            
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            global::Serilog.Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();

            try
            {
                //logger.Debug("Com Server init main");
                global::Serilog.Log.Information("Com Server init main");
                await CreateHostBuilder(args).Build().RunAsync();
            }
            catch (Exception ex)
            {
                //NLog: catch setup errors
                //logger.Error(ex, "Stopped program because of exception");
                global::Serilog.Log.Fatal(ex, "Stopped program because of exception");
                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                //NLog.LogManager.Shutdown();

                global::Serilog.Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .UseSerilog()
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(options =>
                    {
                        options.Listen(IPAddress.Any, 5001, listenOptions =>
                        {
                            listenOptions.Protocols = HttpProtocols.Http2;
                        });
                    });
                    webBuilder.UseStartup<Startup>();
                });
                
    }
}
