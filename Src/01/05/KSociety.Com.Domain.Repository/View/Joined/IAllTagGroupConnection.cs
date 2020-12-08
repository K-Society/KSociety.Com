using System.Collections.Generic;
using System.Threading.Tasks;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.Domain.Entity.View.Joined;

namespace KSociety.Com.Domain.Repository.View.Joined
{
    public interface IAllTagGroupConnection : IRepository<AllTagGroupConnection>
    {
        IEnumerable<AllTagGroupConnection> GetAllTagGroupConnection();

        ValueTask<IEnumerable<AllTagGroupConnection>> GetAllTagGroupConnectionAsync();
    }
}
