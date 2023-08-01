using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Query.View.Joined;

//[ServiceContract(Name = "Com.Query.View.Joined", Namespace = Constants.Namespace)]
[Service]
public interface IQuery
{
    //[OperationContract]
    ////[FaultContract(typeof(BusinessFault))]
    //Task<AllTagGroupAllConnection> AllTagGroupAllConnectionByNameAsync(string groupName);
}