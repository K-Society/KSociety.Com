﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KSociety.Base.Infra.Shared.Class;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.Domain.Repository.View.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Infra.DataAccess.Repository.View.Common
{
    public class TagGroupReady : RepositoryBase<ComContext, Domain.Entity.View.Common.TagGroupReady>, ITagGroupReady
    {
        public TagGroupReady(ILoggerFactory logFactory, IDatabaseFactory<ComContext> databaseFactory) 
            : base(logFactory, databaseFactory)
        {
        }

        public IEnumerable<Domain.Entity.View.Common.TagGroupReady> GetAllTagGroupReady()
        {
            try
            {
                return FindAll().OrderBy(x => x.Name).ToList();
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " - " + ex.StackTrace);
                return new List<Domain.Entity.View.Common.TagGroupReady>();
            }
        }

        public async ValueTask<IEnumerable<Domain.Entity.View.Common.TagGroupReady>> GetAllTagGroupReadyAsync()
        {
            try
            {
                return await FindAll().OrderBy(x => x.Name).ToListAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " - " + ex.StackTrace);
                return await new ValueTask<IEnumerable<Domain.Entity.View.Common.TagGroupReady>>();
            }
        }
    }
}
