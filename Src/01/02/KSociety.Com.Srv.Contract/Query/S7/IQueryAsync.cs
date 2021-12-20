using System.Threading.Tasks;
using KSociety.Base.Srv.Dto;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Query.S7;

[Service]
public interface IQueryAsync
{
    //[OperationContract]
    //Dto.Common.TagGroup GetTagGroupById(IdObject idObject, CallContext context = default);

    [Operation]
    ValueTask<Srv.Dto.S7.S7Connection> GetS7ConnectionByIdAsync(IdObject idObject, CallContext context = default);

    [Operation]
    ValueTask<Srv.Dto.S7.S7Tag> GetS7TagByIdAsync(IdObject idObject, CallContext context = default);
}