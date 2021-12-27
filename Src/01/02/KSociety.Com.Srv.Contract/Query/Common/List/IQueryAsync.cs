using System.Threading.Tasks;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Query.Common.List;

[Service]
public interface IQueryAsync
{
    //[OperationContract]
    //Task<Dto.Common.List.Tag> TagQueryAsync(Expression<Func<Domain.Db.Entity.Common.Tag, bool>> filter);

    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    ValueTask<Srv.Dto.Common.List.Tag> TagAsync(CallContext context = default);

    //[OperationContract(Name = "TagAsync")]
    ////[FaultContract(typeof(BusinessFault))]
    //Task<Dto.Common.List.GridView.Tag> TagAsync();

    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    ValueTask<Srv.Dto.Common.List.Tag> TagByGroupIdAsync(Srv.Dto.Common.GroupId groupId, CallContext context = default);

    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    ValueTask<Srv.Dto.Common.List.Tag> TagByGroupNameAsync(Srv.Dto.Common.GroupName groupName, CallContext context = default);

    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    ValueTask<Srv.Dto.Common.List.TagGroup> TagGroupAsync(CallContext context = default);

    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    ValueTask<Srv.Dto.Common.List.Connection> ConnectionAsync(CallContext context = default);
}