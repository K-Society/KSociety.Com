using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KSociety.Base.Infra.Shared.Class;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.Domain.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Infra.DataAccess.Repository.Common;

//public class Bit<TContext> : RepositoryBase<ComContext, Domain.Entity.Common.Bit>, IBit
public class Bit<TContext> : RepositoryBase<TContext, Domain.Entity.Common.Bit>, IBit 
    where TContext : DatabaseContext
{
    public Bit(ILoggerFactory logFactory, IDatabaseFactory<TContext> databaseFactory) 
        : base(logFactory, databaseFactory)
    {
    }

    public IEnumerable<Domain.Entity.Common.Bit> GetAllBit()
    {
        return FindAll().OrderBy(x => x.BitOfByte).AsNoTracking().ToList();
    }

    public async ValueTask<IEnumerable<Domain.Entity.Common.Bit>> GetAllBitAsync()
    {
        return await FindAll().OrderBy(x => x.BitOfByte).AsNoTracking().ToListAsync();
    }

}