using System.Collections.Generic;
using System.Threading.Tasks;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.Domain.Entity.S7;

namespace KSociety.Com.Domain.Repository.S7
{
    public interface IArea : IRepository<Area>
    {
        IEnumerable<Area> GetAllArea();

        ValueTask<IEnumerable<Area>> GetAllAreaAsync();
    }
}
