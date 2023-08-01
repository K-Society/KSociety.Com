using System.Threading.Tasks;
using KSociety.Base.Srv.Dto;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Query.Common.Model;

[Service]
public interface IQueryAsync
{
    [Operation]
    ValueTask<Srv.Dto.Common.Model.Tag> GetTagModelByIdAsync(IdObject idObject, CallContext context = default);

    [Operation]
    ValueTask<Srv.Dto.Common.Model.Connection> GetConnectionModelByIdAsync(IdObject idObject, CallContext context = default);
}