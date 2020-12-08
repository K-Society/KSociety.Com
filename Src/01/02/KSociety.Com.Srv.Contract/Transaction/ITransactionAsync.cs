using System.Collections.Generic;
using System.Threading.Tasks;
using KSociety.Com.App.Dto.Req.Transaction;
using KSociety.Com.Biz.IntegrationEvent.Event;
using KSociety.Com.Srv.Dto;
using KSociety.Com.Srv.Dto.Biz;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Transaction
{
    [Service]
    public interface ITransactionAsync
    {
        [Operation]
        IAsyncEnumerable<HeartBeat> SendHeartBeatAsync(CallContext context = default);

        [Operation]
        IAsyncEnumerable<TagIntegrationEvent> NotifyTagInvokeAsync(NotifyTagReq notifyTagReq, CallContext context = default);

        //[OperationContract]
        //IAsyncEnumerable<TagReadIntegrationEvent> NotifyTagReadAsync(NotifyTagReq notifyTagReq, CallContext context = default);


        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        ValueTask<App.Dto.Res.Transaction.GetConnectionStatus> ConnectionStatusAsync(GetConnectionStatus request, CallContext context = default);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        ValueTask<App.Dto.Res.Transaction.SetTagValue> SetTagValueAsync(SetTagValue request, CallContext context = default);

        //[OperationContract]
        ////[FaultContract(typeof(BusinessFault))]
        //ValueTask<bool> WriteTagValueAsync(WriteTagValue request, CallContext context = default);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        ValueTask<App.Dto.Res.Transaction.GetTagValue> GetTagValueAsync(GetTagValue request, CallContext context = default);
    }
}
