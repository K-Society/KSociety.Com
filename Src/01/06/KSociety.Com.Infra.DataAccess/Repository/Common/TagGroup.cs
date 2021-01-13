using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KSociety.Base.Infra.Shared.Class;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.Domain.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Infra.DataAccess.Repository.Common
{
    public class TagGroup : Repository<ComContext, Domain.Entity.Common.TagGroup, CsvClassMap.Common.TagGroup>, ITagGroup
    {
        public TagGroup(ILoggerFactory logFactory, IDatabaseFactory<ComContext> databaseFactory)
            : base(logFactory, databaseFactory)
        {
        }

        public IEnumerable<Domain.Entity.Common.TagGroup> GetAllTagGroup()
        {
            return FindAll().OrderBy(x => x.Name).ToList();
        }

        public async ValueTask<IEnumerable<Domain.Entity.Common.TagGroup>> GetAllTagGroupAsync()
        {
            return await FindAll().OrderBy(x => x.Name).ToListAsync();
        }

        //public IEnumerable<Domain.Com.Entity.Common.TagGroup> TagGroupQuery(Expression<Func<Domain.Com.Entity.Common.TagGroup, bool>> filter)
        //{
        //    return Query(filter);
        //}

        //public async ValueTask<IEnumerable<Domain.Com.Entity.Common.TagGroup>> TagGroupQueryAsync(Expression<Func<Domain.Com.Entity.Common.TagGroup, bool>> filter)
        //{
        //    return Query(filter);
        //}
    }
}
