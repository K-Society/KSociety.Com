using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KSociety.Base.Infra.Shared.Class;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.Domain.Repository.View.Joined;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Infra.DataAccess.Repository.View.Joined;

public class AllConnection<TContext> : RepositoryBase<TContext, Domain.Entity.View.Joined.AllConnection>, IAllConnection
    where TContext : DatabaseContext
{
    public AllConnection(ILoggerFactory logFactory, IDatabaseFactory<TContext> databaseFactory) 
        : base(logFactory, databaseFactory)
    {
    }

    public IEnumerable<Domain.Entity.View.Joined.AllConnection> GetAllConnection()
    {
        return FindAll().OrderBy(x => x.ConnectionName).ToList();
    }

    public async ValueTask<IEnumerable<Domain.Entity.View.Joined.AllConnection>> GetAllConnectionAsync()
    {
        return await FindAll().OrderBy(x => x.ConnectionName).ToListAsync();
    }
}