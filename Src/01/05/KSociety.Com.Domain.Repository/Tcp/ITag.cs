using System.Collections.Generic;
using System.Threading.Tasks;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.Domain.Entity.Tcp;

namespace KSociety.Com.Domain.Repository.Tcp
{
    public interface ITag : IRepositoryBase<TcpTag>
    {
        IEnumerable<TcpTag> GetAllTcpTag();

        ValueTask<IEnumerable<TcpTag>> GetAllTcpTagAsync();
    }
}
