﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KSociety.Base.Infra.Shared.Class;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.Domain.Repository.S7;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Infra.DataAccess.Repository.S7;

public class Area<TContext> : RepositoryBase<TContext, Domain.Entity.S7.Area>, IArea
    where TContext : DatabaseContext
{
    public Area(ILoggerFactory logFactory, IDatabaseFactory<TContext> databaseFactory) 
        : base(logFactory, databaseFactory)
    {
    }

    public IEnumerable<Domain.Entity.S7.Area> GetAllArea()
    {
        return FindAll().OrderBy(x => x.AreaName).AsNoTracking().ToList();
    }

    public async ValueTask<IEnumerable<Domain.Entity.S7.Area>> GetAllAreaAsync()
    {
        return await FindAll().OrderBy(x => x.AreaName).AsNoTracking().ToListAsync();
    }
}