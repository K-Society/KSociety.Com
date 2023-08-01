using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Query.S7.List;

//[ServiceContract(Name = "Com.Query.S7.List", Namespace = Constants.Namespace)]
[Service]
public interface IQuery
{
    //[OperationContract]
    ////[FaultContract(typeof(BusinessFault))]
    //Dto.S7.List.Area Area();

    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    Srv.Dto.S7.List.Area Area(CallContext context = default);

    //[OperationContract]
    ////[FaultContract(typeof(BusinessFault))]
    //Dto.S7.List.Connection Connection();


}