using System.Collections.Generic;
using System.Threading.Tasks;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.Domain.Entity.Logix;

namespace KSociety.Com.Domain.Repository.Logix;

public interface ITag : IRepository<LogixTag>
{
    IEnumerable<LogixTag> GetAllLogixTag();

    ValueTask<IEnumerable<LogixTag>> GetAllLogixTagAsync();
}