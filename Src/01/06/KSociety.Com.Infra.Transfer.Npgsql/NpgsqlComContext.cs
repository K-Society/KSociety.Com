using KSociety.Base.Infra.Abstraction.Interface;
using KSociety.Com.Infra.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Infra.Transfer.Npgsql;

public sealed class NpgsqlComContext : ComContext
{
    public NpgsqlComContext(ILoggerFactory loggerFactory, IDatabaseConfiguration configuration, IMediator mediator)
        : base(loggerFactory, configuration, mediator)
    {

    }

    public NpgsqlComContext(DbContextOptions<NpgsqlComContext> options)
        : base(options)
    {

    }
}
