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
    public class ConnectionType : RepositoryBase<ComContext, Domain.Entity.S7.ConnectionType>, IConnectionType
    {
        public ConnectionType(ILoggerFactory logFactory, IDatabaseFactory<ComContext> databaseFactory) 
            : base(logFactory, databaseFactory)
        {
        }


        public IEnumerable<Domain.Entity.S7.ConnectionType> GetAllConnectionType()
        {
            return FindAll().OrderBy(x => x.Name).AsNoTracking().ToList();
        }

        public async ValueTask<IEnumerable<Domain.Entity.S7.ConnectionType>> GetAllConnectionTypeAsync()
        {
            return await FindAll().OrderBy(x => x.Name).AsNoTracking().ToListAsync();
        }
    }
}
