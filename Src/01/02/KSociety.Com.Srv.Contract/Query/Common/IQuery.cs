using KSociety.Base.Srv.Dto;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Query.Common
{
    [Service]
    public interface IQuery
    {
        [Operation]
        Srv.Dto.Common.TagGroup GetTagGroupById(KbIdObject idObject, CallContext context = default);

        [Operation]
        Srv.Dto.Common.Tag GetTagById(KbIdObject idObject, CallContext context = default);

        [Operation]
        Srv.Dto.Common.Connection GetConnectionById(KbIdObject idObject, CallContext context = default);
    }
}
