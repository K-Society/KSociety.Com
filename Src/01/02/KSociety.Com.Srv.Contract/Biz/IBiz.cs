using System.Collections.Generic;
using KSociety.Com.App.Dto.Req.Biz;
using KSociety.Com.Srv.Dto;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Biz
{
    [Service]
    public interface IBiz
    {
        [Operation]
        IEnumerable<HeartBeat> SendHeartBeat(CallContext context = default);

        //[OperationContract]
        //IEnumerable<TagIntegrationEvent> NotifyTagInvoke(NotifyTagReq notifyTagReq, CallContext context = default);

        //[OperationContract]
        //IAsyncEnumerable<TagReadIntegrationEvent> NotifyTagReadAsync(NotifyTagReq notifyTagReq, CallContext context = default);


        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        App.Dto.Res.Biz.GetConnectionStatus ConnectionStatus(GetConnectionStatus request, CallContext context = default);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        App.Dto.Res.Biz.SetTagValue SetTagValue(SetTagValue request, CallContext context = default);

        //[OperationContract]
        ////[FaultContract(typeof(BusinessFault))]
        //ValueTask<bool> WriteTagValueAsync(WriteTagValue request, CallContext context = default);

        [Operation]
        //[FaultContract(typeof(BusinessFault))]
        App.Dto.Res.Biz.GetTagValue GetTagValue(GetTagValue request, CallContext context = default);
    }
}
