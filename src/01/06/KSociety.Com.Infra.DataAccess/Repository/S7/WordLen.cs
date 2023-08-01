using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KSociety.Base.Infra.Shared.Class;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.Domain.Repository.S7;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Infra.DataAccess.Repository.S7;

public class WordLen<TContext> : RepositoryBase<TContext, Domain.Entity.S7.WordLen>, IWordLen
    where TContext : DatabaseContext
{
    public WordLen(ILoggerFactory logFactory, IDatabaseFactory<TContext> databaseFactory) 
        : base(logFactory, databaseFactory)
    {
    }

    public IEnumerable<Domain.Entity.S7.WordLen> GetAllWordLen()
    {
        return FindAll().OrderBy(x => x.WordLenName).AsNoTracking().ToList();
    }

    public async ValueTask<IEnumerable<Domain.Entity.S7.WordLen>> GetAllWordLenAsync()
    {
        return await FindAll().OrderBy(x => x.WordLenName).AsNoTracking().ToListAsync();
    }
}