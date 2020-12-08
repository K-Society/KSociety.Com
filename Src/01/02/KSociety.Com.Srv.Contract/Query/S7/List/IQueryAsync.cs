using System.Threading.Tasks;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Query.S7.List
{
    [Service]
    public interface IQueryAsync
    {
        //[OperationContract]
        ////[FaultContract(typeof(BusinessFault))]
        //Dto.S7.List.Area Area();

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        ValueTask<Srv.Dto.S7.List.Area> AreaAsync(CallContext context = default);

        //[OperationContract]
        ////[FaultContract(typeof(BusinessFault))]
        //Dto.S7.List.Connection Connection();


    }
}
