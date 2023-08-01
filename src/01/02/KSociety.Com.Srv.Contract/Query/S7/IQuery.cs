using KSociety.Base.Srv.Dto;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Query.S7;

[Service]
public interface IQuery
{
    //[OperationContract]
    //Dto.Common.TagGroup GetTagGroupById(IdObject idObject, CallContext context = default);

    [Operation]
    Srv.Dto.S7.S7Connection GetS7ConnectionById(IdObject idObject, CallContext context = default);

    [Operation]
    Srv.Dto.S7.S7Tag GetS7TagById(IdObject idObject, CallContext context = default);
}