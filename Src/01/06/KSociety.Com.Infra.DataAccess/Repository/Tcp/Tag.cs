using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KSociety.Base.Infra.Shared.Class;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.Domain.Repository.Tcp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Infra.DataAccess.Repository.Tcp;

public class Tag : RepositoryBase<ComContext, Domain.Entity.Tcp.TcpTag>, ITag
{
    public Tag(ILoggerFactory logFactory, IDatabaseFactory<ComContext> databaseFactory)
        : base(logFactory, databaseFactory)
    {
    }

    public IEnumerable<Domain.Entity.Tcp.TcpTag> GetAllTcpTag()
    {
        return FindAll().OrderBy(x => x.Name).ToList();
    }

    public async ValueTask<IEnumerable<Domain.Entity.Tcp.TcpTag>> GetAllTcpTagAsync()
    {
        return await FindAll().OrderBy(x => x.Name).ToListAsync();
    }
}