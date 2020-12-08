using System.Collections.Generic;
using System.Threading.Tasks;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.Domain.Entity.S7;

namespace KSociety.Com.Domain.Repository.S7
{
    public interface ITag : IRepository<S7Tag>
    {
        IEnumerable<S7Tag> GetAllS7Tag();

        ValueTask<IEnumerable<S7Tag>> GetAllS7TagAsync();
    }
}
