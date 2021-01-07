using System.Threading.Tasks;
using KSociety.Base.Srv.Dto;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Query.Common
{
    [Service]
    public interface IQueryAsync
    {
        [Operation]
        ValueTask<Srv.Dto.Common.TagGroup> GetTagGroupByIdAsync(IdObject idObject, CallContext context = default);

        [Operation]
        ValueTask<Srv.Dto.Common.Tag> GetTagByIdAsync(IdObject idObject, CallContext context = default);

        [Operation]
        ValueTask<Srv.Dto.Common.Connection> GetConnectionByIdAsync(IdObject idObject, CallContext context = default);
    }
}
