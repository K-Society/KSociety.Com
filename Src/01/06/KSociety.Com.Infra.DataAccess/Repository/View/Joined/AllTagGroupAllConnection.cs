using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KSociety.Base.Infra.Shared.Class;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.Domain.Repository.View.Joined;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Infra.DataAccess.Repository.View.Joined
{
    public class AllTagGroupAllConnection : RepositoryBase<ComContext, Domain.Entity.View.Joined.AllTagGroupAllConnection>, IAllTagGroupAllConnection
    {
        public AllTagGroupAllConnection(ILoggerFactory logFactory, IDatabaseFactory<ComContext> databaseFactory) 
            : base(logFactory, databaseFactory)
        {
        }

        public IEnumerable<Domain.Entity.View.Joined.AllTagGroupAllConnection> GetAllTagGroupAllConnection()
        {
            return FindAll().OrderBy(x => x.TagName).ToList();
        }

        public async ValueTask<IEnumerable<Domain.Entity.View.Joined.AllTagGroupAllConnection>> GetAllTagGroupAllConnectionAsync()
        {
            return await FindAll().OrderBy(x => x.TagName).ToListAsync();
        }
    }
}
