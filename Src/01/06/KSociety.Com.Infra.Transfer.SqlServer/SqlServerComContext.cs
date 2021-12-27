using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.Infra.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Infra.Transfer.SqlServer;

public sealed class SqlServerComContext : ComContext
{
    public SqlServerComContext(ILoggerFactory loggerFactory, IDatabaseConfiguration configuration, IMediator mediator)
        : base(loggerFactory, configuration, mediator)
    {

    }

    public SqlServerComContext(DbContextOptions<SqlServerComContext> options)
        : base(options)
    {

    }
}