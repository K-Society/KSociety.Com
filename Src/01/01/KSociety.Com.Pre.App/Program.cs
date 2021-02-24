using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Net;

namespace KSociety.Com.Pre.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Std.Log.Driver.ProtoModel.Configuration.ProtoBufConfiguration();
            //LogManager.Setup().SetupExtensions(s =>
            //    s.RegisterTarget<Std.Log.Driver.Targets.LogReceiverRabbitMqServiceAsync>(
            //        "LogReceiverRabbitMqServiceAsync"));

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(options =>
                    {
                        options.Listen(IPAddress.Any, 5002);
                    });
                    webBuilder.UseStaticWebAssets();
                    webBuilder.UseStartup<Startup>();
                });
    }
}
