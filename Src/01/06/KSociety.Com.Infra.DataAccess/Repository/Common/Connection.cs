using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KSociety.Base.Infra.Shared.Class;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.Domain.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Infra.DataAccess.Repository.Common;

public class Connection<TContext> 
    : Repository<TContext, Domain.Entity.Common.Connection, CsvClassMap.Common.Connection>, IConnection
    where TContext : DatabaseContext
{
    public Connection(ILoggerFactory logFactory, IDatabaseFactory<TContext> databaseFactory) 
        : base(logFactory, databaseFactory)
    {
    }

    public IEnumerable<Domain.Entity.Common.Connection> GetAllConnection()
    {
        return FindAll().OrderBy(x => x.Name).ToList();
    }

    public async ValueTask<IEnumerable<Domain.Entity.Common.Connection>> GetAllConnectionAsync()
    {
        return await FindAll().OrderBy(x => x.Name).ToListAsync();
    }
}