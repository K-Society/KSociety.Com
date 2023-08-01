using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KSociety.Base.Infra.Shared.Class;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.Domain.Repository.Logix;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Infra.DataAccess.Repository.Logix;

public class Connection<TContext> : RepositoryBase<TContext, Domain.Entity.Logix.LogixConnection>, IConnection
    where TContext : DatabaseContext
{
    public Connection(ILoggerFactory logFactory, IDatabaseFactory<TContext> databaseFactory) 
        : base(logFactory, databaseFactory)
    {
    }

    public IEnumerable<Domain.Entity.Logix.LogixConnection> GetAllLogixConnection()
    {
        return FindAll().OrderBy(x => x.Name).ToList();
    }

    public async ValueTask<IEnumerable<Domain.Entity.Logix.LogixConnection>> GetAllLogixConnectionAsync()
    {
        return await FindAll().OrderBy(x => x.Name).ToListAsync();
    }
}