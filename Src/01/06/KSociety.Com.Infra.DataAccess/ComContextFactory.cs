using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace KSociety.Com.Infra.DataAccess
{
    public class ComContextFactory : IDesignTimeDbContextFactory<ComContext>
    {
        //public static readonly Microsoft.Extensions.Options.IOptionsMonitor<ConsoleLoggerOptions> ConsoleOptionsMonitor = new OptionsMonitor<ConsoleLoggerOptions>();

        ////static LoggerFactory object
        //public static readonly ILoggerFactory loggerFactory = new LoggerFactory(new[] {
        //    new ConsoleLoggerProvider(Microsoft.Extensions.Options.IOptionsMonitor<ConsoleLoggerOptions>)
        //});

        //or
        //public static readonly ILoggerFactory loggerFactory  = new LoggerFactory().AddConsole((_,___) => true);


        public ComContext CreateDbContext(string[] args)
        {

            //Console.WriteLine(@"ComContextFactory: ");
            var optionBuilder = new DbContextOptionsBuilder<ComContext>();
            optionBuilder
                .UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Database=KSociety.Com;AttachDbFilename=C:\DB\ComDb.mdf;Integrated Security=True;Connect Timeout=30;");
            return new ComContext(optionBuilder.Options);
        }
    }
}
