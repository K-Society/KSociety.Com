using System.Threading.Tasks;
using KSociety.Base.Srv.Dto;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Query.S7.Model;

[Service]
public interface IQueryAsync
{
    [Operation]
    ValueTask<Srv.Dto.S7.Model.S7Tag> GetS7TagModelByIdAsync(IdObject idObject, CallContext context = default);

    [Operation]
    ValueTask<Srv.Dto.S7.Model.S7Connection> GetS7ConnectionModelByIdAsync(IdObject idObject, CallContext context = default);
}