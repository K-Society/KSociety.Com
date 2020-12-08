using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KSociety.Base.Infra.Shared.Class;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.Domain.Repository.S7;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Infra.DataAccess.Repository.S7
{
    public class Tag : RepositoryBase<ComContext, Domain.Entity.S7.S7Tag>, ITag
    {
        public Tag(ILoggerFactory logFactory, IDatabaseFactory<ComContext> databaseFactory) 
            : base(logFactory, databaseFactory)
        {
        }

        public IEnumerable<Domain.Entity.S7.S7Tag> GetAllS7Tag()
        {
            return FindAll().OrderBy(x => x.Name).ToList();
        }

        public async ValueTask<IEnumerable<Domain.Entity.S7.S7Tag>> GetAllS7TagAsync()
        {
            return await FindAll().OrderBy(x => x.Name).ToListAsync();
        }
    }
}
