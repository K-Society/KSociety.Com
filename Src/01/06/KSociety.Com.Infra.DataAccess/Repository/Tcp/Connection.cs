using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KSociety.Base.Infra.Shared.Class;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.Domain.Repository.Tcp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Infra.DataAccess.Repository.Tcp;

public class Connection<TContext> : RepositoryBase<TContext, Domain.Entity.Tcp.TcpConnection>, IConnection
    where TContext : DatabaseContext
{
    public Connection(ILoggerFactory logFactory, IDatabaseFactory<TContext> databaseFactory)
        : base(logFactory, databaseFactory)
    {
    }

    public IEnumerable<Domain.Entity.Tcp.TcpConnection> GetAllTcpConnection()
    {
        return FindAll().OrderBy(x => x.Name).ToList();
    }

    public async ValueTask<IEnumerable<Domain.Entity.Tcp.TcpConnection>> GetAllTcpConnectionAsync()
    {
        return await FindAll().OrderBy(x => x.Name).ToListAsync();
    }
}