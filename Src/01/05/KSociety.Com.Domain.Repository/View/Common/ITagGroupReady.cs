using System.Collections.Generic;
using System.Threading.Tasks;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.Domain.Entity.View.Common;

namespace KSociety.Com.Domain.Repository.View.Common
{
    public interface ITagGroupReady : IRepositoryBase<TagGroupReady>
    {
        IEnumerable<TagGroupReady> GetAllTagGroupReady();

        ValueTask<IEnumerable<TagGroupReady>> GetAllTagGroupReadyAsync();
    }
}
