using System.Collections.Generic;
using System.Threading.Tasks;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.Domain.Entity.S7;

namespace KSociety.Com.Domain.Repository.S7
{
    public interface IConnection : IRepository<S7Connection>
    {
        IEnumerable<S7Connection> GetAllS7Connection();

        ValueTask<IEnumerable<S7Connection>> GetAllS7ConnectionAsync();
    }
}
