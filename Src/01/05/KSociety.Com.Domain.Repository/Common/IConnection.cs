using System.Collections.Generic;
using System.Threading.Tasks;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.Domain.Entity.Common;

namespace KSociety.Com.Domain.Repository.Common;

public interface IConnection : IRepository<Connection>
{
    IEnumerable<Connection> GetAllConnection();

    ValueTask<IEnumerable<Connection>> GetAllConnectionAsync();
}