using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KSociety.Base.Infra.Shared.Class;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.Domain.Repository.View.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Infra.DataAccess.Repository.View.Common;

public class TagGroupReady<TContext> : RepositoryBase<TContext, Domain.Entity.View.Common.TagGroupReady>, ITagGroupReady
    where TContext : DatabaseContext
{
    public TagGroupReady(ILoggerFactory logFactory, IDatabaseFactory<TContext> databaseFactory) 
        : base(logFactory, databaseFactory)
    {
    }

    public IEnumerable<Domain.Entity.View.Common.TagGroupReady> GetAllTagGroupReady()
    {
        try
        {
            var results = FindAll();
            if (results is not null)
            {
                return results.OrderBy(x => x.Name).ToList();
            }
            Logger.LogWarning("{0}.{1} {2}", GetType().FullName, System.Reflection.MethodBase.GetCurrentMethod()?.Name, "No data!");
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);
        }
        return new List<Domain.Entity.View.Common.TagGroupReady>();
    }

    public async ValueTask<IEnumerable<Domain.Entity.View.Common.TagGroupReady>> GetAllTagGroupReadyAsync()
    {
        try
        {
            return await FindAll().OrderBy(x => x.Name).ToListAsync();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);
            return await new ValueTask<IEnumerable<Domain.Entity.View.Common.TagGroupReady>>();
        }
    }
}