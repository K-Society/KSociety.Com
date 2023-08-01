using KSociety.Base.Srv.Dto;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Query.S7.Model;

[Service]
public interface IQuery
{
    [Operation]
    Srv.Dto.S7.Model.S7Tag GetS7TagModelById(IdObject idObject, CallContext context = default);

    [Operation]
    Srv.Dto.S7.Model.S7Connection GetS7ConnectionModelById(IdObject idObject, CallContext context = default);
}