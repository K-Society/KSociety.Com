using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KSociety.Base.Infra.Shared.Class;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.Domain.Repository.Logix;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Infra.DataAccess.Repository.Logix
{
    public class Tag : RepositoryBase<ComContext, Domain.Entity.Logix.LogixTag>, ITag
    {
        public Tag(ILoggerFactory logFactory, IDatabaseFactory<ComContext> databaseFactory) 
            : base(logFactory, databaseFactory)
        {
        }

        public IEnumerable<Domain.Entity.Logix.LogixTag> GetAllLogixTag()
        {
            return FindAll().OrderBy(x => x.Name).ToList();
        }

        public async ValueTask<IEnumerable<Domain.Entity.Logix.LogixTag>> GetAllLogixTagAsync()
        {
            return await FindAll().OrderBy(x => x.Name).ToListAsync();
        }
    }
}
