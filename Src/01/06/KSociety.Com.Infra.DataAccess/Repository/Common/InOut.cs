using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KSociety.Base.Infra.Shared.Class;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.Domain.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Infra.DataAccess.Repository.Common;

public class InOut : RepositoryBase<ComContext, Domain.Entity.Common.InOut>, IInOut
{
    public InOut(ILoggerFactory logFactory, IDatabaseFactory<ComContext> databaseFactory) 
        : base(logFactory, databaseFactory)
    {
    }

    public IEnumerable<Domain.Entity.Common.InOut> GetAllInOut()
    {
        return FindAll().OrderBy(x => x.InputOutput).AsNoTracking().ToList();
    }

    public async ValueTask<IEnumerable<Domain.Entity.Common.InOut>> GetAllInOutAsync()
    {
        return await FindAll().OrderBy(x => x.InputOutput).AsNoTracking().ToListAsync();
    }
}