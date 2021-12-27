using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KSociety.Base.Infra.Shared.Class;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.Domain.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Infra.DataAccess.Repository.Common;

public class AutomationType<TContext>
    : RepositoryBase<
        TContext,
        Domain.Entity.Common.AutomationType>, IAutomationType
    where TContext : DatabaseContext
{
    public AutomationType(ILoggerFactory logFactory, IDatabaseFactory<TContext> databaseFactory) 
        : base(logFactory, databaseFactory)
    {
    }

    public IEnumerable<Domain.Entity.Common.AutomationType> GetAllAutomationType()
    {
        return FindAll().OrderBy(x => x.Name).ToList();
    }

    public async ValueTask<IEnumerable<Domain.Entity.Common.AutomationType>> GetAllAutomationTypeAsync()
    {
        return await FindAll().OrderBy(x => x.Name).ToListAsync();
    }
}