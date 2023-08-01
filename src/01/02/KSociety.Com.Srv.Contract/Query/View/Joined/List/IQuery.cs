using KSociety.Com.Srv.Dto.View.Joined.List;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Query.View.Joined.List;

//[ServiceContract(Name = "Com.Query.View.Joined.List", Namespace = Constants.Namespace)]
[Service]
public interface IQuery
{
    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    AllTagGroupAllConnection AllTagGroupAllConnection(CallContext context = default);

    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    AllTagGroupAllConnection AllTagGroupAllConnectionByName(Srv.Dto.View.Joined.GroupName groupName, CallContext context = default);

    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    AllConnection AllConnection(CallContext context = default);
}