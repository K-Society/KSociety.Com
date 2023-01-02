using KSociety.Base.Infra.Abstraction.Interface;
using KSociety.Com.Infra.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Infra.Transfer.MySql;

public sealed class MySqlComContext : ComContext
{
    public MySqlComContext(ILoggerFactory loggerFactory, IDatabaseConfiguration configuration, IMediator mediator)
        : base(loggerFactory, configuration, mediator)
    {

    }

    public MySqlComContext(DbContextOptions<MySqlComContext> options)
        : base(options)
    {

    }
}
