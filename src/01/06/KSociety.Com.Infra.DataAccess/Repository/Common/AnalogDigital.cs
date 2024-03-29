﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KSociety.Base.Infra.Shared.Class;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.Domain.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Infra.DataAccess.Repository.Common;

public class AnalogDigital<TContext>
    : RepositoryBase<TContext, Domain.Entity.Common.AnalogDigital>, IAnalogDigital 
    where TContext : DatabaseContext
{
    public AnalogDigital(ILoggerFactory logFactory, IDatabaseFactory<TContext> databaseFactory) 
        : base(logFactory, databaseFactory)
    {
    }

    public IEnumerable<Domain.Entity.Common.AnalogDigital> GetAllAnalogDigital()
    {
        return FindAll().OrderBy(x => x.AnalogDigitalSignal).AsNoTracking().ToList();
    }

    public async ValueTask<IEnumerable<Domain.Entity.Common.AnalogDigital>> GetAllAnalogDigitalAsync()
    {
        return await FindAll().OrderBy(x => x.AnalogDigitalSignal).AsNoTracking().ToListAsync();
    }

}