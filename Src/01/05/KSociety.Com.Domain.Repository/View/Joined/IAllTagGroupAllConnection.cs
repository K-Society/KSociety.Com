using System.Collections.Generic;
using System.Threading.Tasks;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.Domain.Entity.View.Joined;

namespace KSociety.Com.Domain.Repository.View.Joined
{
    public interface IAllTagGroupAllConnection : IRepositoryBase<AllTagGroupAllConnection>
    { 
        IEnumerable<AllTagGroupAllConnection> GetAllTagGroupAllConnection();

        ValueTask<IEnumerable<AllTagGroupAllConnection>> GetAllTagGroupAllConnectionAsync();
    }
}
