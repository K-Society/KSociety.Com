using System;
using System.Net;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Formatting.Json;
using KSociety.Log.Serilog.Sinks.RabbitMq;

namespace KSociety.Com.Srv.Host
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            KSociety.Log.Serilog.Sinks.RabbitMq.ProtoModel.Configuration.ProtoBufConfiguration();
            //LogManager.Setup().SetupExtensions(s =>
            //    s.RegisterTarget<Std.Log.Driver.Targets.LogReceiverRabbitMqServiceAsync>(
            //        "LogReceiverRabbitMqServiceAsync"));
            //LogManager.Setup().SetupExtensions(s =>
            //    s.RegisterTarget<Std.Log.Driver.Targets.LogReceiverGrpcServiceAsync>(
            //        "LogReceiverGrpcServiceAsync"));
            // NLog: setup the logger first to catch all errors
            //var logger = LogManager.GetCurrentClassLogger();//NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

            //var config = new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.json")
            //    .Build();

            ////Initialize Logger
            //Log.Logger = new LoggerConfiguration()
            //    .ReadFrom.Configuration(config)
            //    .CreateLogger();

            //var config = new RabbitMqClientConfiguration
            //{
            //    Port = 5672,
            //    DeliveryMode = RabbitMqDeliveryMode.NonDurable,
            //    Exchange = "k-society_log_test",
            //    Username = "KSociety",
            //    Password = "KSociety",
            //    ExchangeType = "fanout",
            //    Hostnames = { "localhost"}
            //};

            //foreach (string hostname in _config["RABBITMQ_HOSTNAMES"])
            //{
            //    config.Hostnames.Add(hostname);
            //}

            //var connectionFactory = new ConnectionFactory
            //{
            //    HostName = "localhost",
            //    UserName = "",
            //    Password = "",
            //    AutomaticRecoveryEnabled = true,
            //    NetworkRecoveryInterval = TimeSpan.FromSeconds(10),
            //    RequestedHeartbeat = TimeSpan.FromSeconds(10),
            //    DispatchConsumersAsync = true
            //};

            //var exchangeDeclareParameters = new ExchangeDeclareParameters("k-society_log",
            //    EventBus.ExchangeType.Fanout,
            //    false,
            //    true);

            //var queueDeclareParameters =new QueueDeclareParameters(false, false, true);

            global::Serilog.Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.RabbitMq((connectionFactory, exchangeDeclareParameters, queueDeclareParameters, sinkConfiguration) => {
                    connectionFactory.HostName = "localhost";
                    connectionFactory.UserName = "KSociety";
                    connectionFactory.Password = "KSociety";
                    connectionFactory.AutomaticRecoveryEnabled = true;
                    connectionFactory.NetworkRecoveryInterval = TimeSpan.FromSeconds(10);
                    connectionFactory.RequestedHeartbeat = TimeSpan.FromSeconds(10);
                    connectionFactory.DispatchConsumersAsync = true;

                    exchangeDeclareParameters.BrokerName = "k-society_log";
                    exchangeDeclareParameters.ExchangeType = KSociety.Base.EventBus.ExchangeType.Direct.ToString().ToLower();
                    exchangeDeclareParameters.ExchangeDurable = false;
                    exchangeDeclareParameters.ExchangeAutoDelete = true;

                    queueDeclareParameters.QueueDurable = false;
                    queueDeclareParameters.QueueExclusive = false;
                    queueDeclareParameters.QueueAutoDelete = true;
                    sinkConfiguration.TextFormatter = new JsonFormatter();
                }).MinimumLevel.Verbose().CreateLogger();


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
                            //listenOptions.UseHttps();
                        });

                        //options.Listen(IPAddress.Any, 5002, listenOptions =>
                        //{
                        //    listenOptions.Protocols = HttpProtocols.Http2;
                        //    //listenOptions.UseHttps();
                        //});
                    });
                    webBuilder.UseStartup<Startup>();
                });
                //.ConfigureServices((hostContext, services) =>
                //{
                //    services.AddHostedService<Worker>();
                //})
                //.ConfigureLogging(logging =>
                //{
                //    //logging.AddFilter("Grpc", LogLevel.Error);
                //    logging.ClearProviders();
                //    //logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                //    //logging.AddNLog(config);
                //    //logging.AddFilter<ConsoleLoggerProvider>(level => level == LogLevel.None);
                //    //logging.AddFilter<Microsoft>(level => level == LogLevel.None);
                //    //logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                //    //logging.AddFilter("Kestrel", LogLevel.None);
                //    //logging.AddFilter("System", LogLevel.Critical);
                //    //logging.AddFilter("Grpc", LogLevel.Critical);
                //});

        //.UseNLog();  // NLog: setup NLog for Dependency injection
    }
}
