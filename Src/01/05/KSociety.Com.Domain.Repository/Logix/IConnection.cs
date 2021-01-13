using System.Collections.Generic;
using System.Threading.Tasks;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.Domain.Entity.Logix;

namespace KSociety.Com.Domain.Repository.Logix
{
    public interface IConnection : IRepositoryBase<LogixConnection>
    {
        IEnumerable<LogixConnection> GetAllLogixConnection();

        ValueTask<IEnumerable<LogixConnection>> GetAllLogixConnectionAsync();
    }
}
