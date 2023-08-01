using KSociety.Base.Infra.Abstraction.Interface;
using KSociety.Com.Infra.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Infra.Transfer.Sqlite;

public sealed class SqliteComContext : ComContext
{
    public SqliteComContext(ILoggerFactory loggerFactory, IDatabaseConfiguration configuration, IMediator mediator)
        : base(loggerFactory, configuration, mediator)
    {

    }

    public SqliteComContext(DbContextOptions<SqliteComContext> options)
        : base(options)
    {

    }
}