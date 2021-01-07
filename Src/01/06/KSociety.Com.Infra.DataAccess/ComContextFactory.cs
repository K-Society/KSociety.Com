using KSociety.Base.Infra.Shared.Class;
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
            DatabaseEngine dbEngine = DatabaseEngine.Sqlserver;

            if (args.Length > 0)
            {
                switch (args[0])
                {
                    case "Sqlserver":
                        dbEngine = DatabaseEngine.Sqlserver;
                        break;
                    case "Sqlite":
                        dbEngine = DatabaseEngine.Sqlite;
                        break;
                    case "Npgsql":
                        dbEngine = DatabaseEngine.Npgsql;
                        break;
                }
            }

            var optionBuilder = new DbContextOptionsBuilder<ComContext>();

            switch (dbEngine)
            {
                case DatabaseEngine.Sqlserver:
                    optionBuilder
                        .UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Database=KSociety.Com;AttachDbFilename=C:\DB\ComDb.mdf;Integrated Security=True;Connect Timeout=30;", sql => sql.MigrationsAssembly("KSociety.Com.Infra.Migration.SqlServer"));

                    break;

                case DatabaseEngine.Sqlite:
                    optionBuilder
                        .UseSqlite(@"Data Source=C:\DB\ComDb.db;", sql => sql.MigrationsAssembly("KSociety.Com.Infra.Migration.Sqlite"));

                    break;

                case DatabaseEngine.Npgsql:
                    break;
            }
            
            return new ComContext(optionBuilder.Options);
        }
    }
}
