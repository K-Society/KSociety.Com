using System.Collections.Generic;
using System.Threading.Tasks;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.Domain.Entity.Common;

namespace KSociety.Com.Domain.Repository.Common;

public interface ITagGroup : IRepository<TagGroup>
{
    IEnumerable<TagGroup> GetAllTagGroup();

    ValueTask<IEnumerable<TagGroup>> GetAllTagGroupAsync();

    //IEnumerable<TagGroup> TagGroupQuery(Expression<Func<TagGroup, bool>> filter);

    //ValueTask<IEnumerable<TagGroup>> TagGroupAsyncAsync(Expression<Func<TagGroup, bool>> filter);
}