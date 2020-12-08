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
        ValueTask<Srv.Dto.Common.TagGroup> GetTagGroupByIdAsync(KbIdObject idObject, CallContext context = default);

        [Operation]
        ValueTask<Srv.Dto.Common.Tag> GetTagByIdAsync(KbIdObject idObject, CallContext context = default);

        [Operation]
        ValueTask<Srv.Dto.Common.Connection> GetConnectionByIdAsync(KbIdObject idObject, CallContext context = default);
    }
}
