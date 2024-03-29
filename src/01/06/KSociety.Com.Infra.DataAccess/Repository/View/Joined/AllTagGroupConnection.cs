﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KSociety.Base.Infra.Shared.Class;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.Domain.Repository.View.Joined;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Infra.DataAccess.Repository.View.Joined;

public class AllTagGroupConnection<TContext> : RepositoryBase<TContext, Domain.Entity.View.Joined.AllTagGroupConnection>, IAllTagGroupConnection
    where TContext : DatabaseContext
{
    public AllTagGroupConnection(ILoggerFactory logFactory, IDatabaseFactory<TContext> databaseFactory) 
        : base(logFactory, databaseFactory)
    {
    }

    public IEnumerable<Domain.Entity.View.Joined.AllTagGroupConnection> GetAllTagGroupConnection()
    {
        return FindAll().OrderBy(x => x.TagName).ToList();
    }

    public async ValueTask<IEnumerable<Domain.Entity.View.Joined.AllTagGroupConnection>> GetAllTagGroupConnectionAsync()
    {
        return await FindAll().OrderBy(x => x.TagName).ToListAsync();
    }
}