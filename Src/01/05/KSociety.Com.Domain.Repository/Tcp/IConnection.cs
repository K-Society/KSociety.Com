using System.Collections.Generic;
using System.Threading.Tasks;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.Domain.Entity.Tcp;

namespace KSociety.Com.Domain.Repository.Tcp
{
    public interface IConnection : IRepository<TcpConnection>
    {
        IEnumerable<TcpConnection> GetAllTcpConnection();

        ValueTask<IEnumerable<TcpConnection>> GetAllTcpConnectionAsync();
    }
}
