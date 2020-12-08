using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Query.Common.List
{
    //[ServiceContract(Name = "Com.Query.Common.List", Namespace = Constants.Namespace)]
    [Service]
    public interface IQuery
    {
        //[OperationContract]
        //Task<Dto.Common.List.Tag> TagQueryAsync(Expression<Func<Domain.Db.Entity.Common.Tag, bool>> filter);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        Srv.Dto.Common.List.Tag Tag(CallContext context = default);

        //[OperationContract(Name = "TagAsync")]
        ////[FaultContract(typeof(BusinessFault))]
        //Task<Dto.Common.List.GridView.Tag> TagAsync();

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        Srv.Dto.Common.List.Tag TagByGroupId(Srv.Dto.Common.GroupId groupId, CallContext context = default);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        Srv.Dto.Common.List.Tag TagByGroupName(Srv.Dto.Common.GroupName groupName, CallContext context = default);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        Srv.Dto.Common.List.TagGroup TagGroup(CallContext context = default);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        Srv.Dto.Common.List.Connection Connection(CallContext context = default);
    }
}
