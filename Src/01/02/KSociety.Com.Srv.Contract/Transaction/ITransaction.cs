using System.Collections.Generic;
using KSociety.Com.App.Dto.Req.Transaction;
using KSociety.Com.Srv.Dto;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Transaction
{
    [Service]
    public interface ITransaction
    {
        [Operation]
        IEnumerable<HeartBeat> SendHeartBeat(CallContext context = default);

        //[OperationContract]
        //IEnumerable<TagIntegrationEvent> NotifyTagInvoke(NotifyTagReq notifyTagReq, CallContext context = default);

        //[OperationContract]
        //IAsyncEnumerable<TagReadIntegrationEvent> NotifyTagReadAsync(NotifyTagReq notifyTagReq, CallContext context = default);


        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        App.Dto.Res.Transaction.GetConnectionStatus ConnectionStatus(GetConnectionStatus request, CallContext context = default);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        App.Dto.Res.Transaction.SetTagValue SetTagValue(SetTagValue request, CallContext context = default);

        //[OperationContract]
        ////[FaultContract(typeof(BusinessFault))]
        //ValueTask<bool> WriteTagValueAsync(WriteTagValue request, CallContext context = default);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        App.Dto.Res.Transaction.GetTagValue GetTagValue(GetTagValue request, CallContext context = default);
    }
}
