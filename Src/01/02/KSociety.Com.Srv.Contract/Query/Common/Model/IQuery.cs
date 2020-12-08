using KSociety.Base.Srv.Dto;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Query.Common.Model
{
    [Service]
    public interface IQuery
    {
        [Operation]
        Srv.Dto.Common.Model.Tag GetTagModelById(KbIdObject idObject, CallContext context = default);

        [Operation]
        Srv.Dto.Common.Model.Connection GetConnectionModelById(KbIdObject idObject, CallContext context = default);
    }
}
