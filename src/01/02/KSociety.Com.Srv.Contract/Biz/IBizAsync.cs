using System.Collections.Generic;
using System.Threading.Tasks;
using KSociety.Com.App.Dto.Req.Biz;
using KSociety.Com.Srv.Dto;
using KSociety.Com.Srv.Dto.Biz;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Com.Srv.Contract.Biz;

[Service]
public interface IBizAsync
{
    [Operation]
    IAsyncEnumerable<HeartBeat> SendHeartBeatAsync(CallContext context = default);

    [Operation]
    IAsyncEnumerable<NotifyTagRes> NotifyTagInvokeAsync(NotifyTagReq notifyTagReq, CallContext context = default);

    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    ValueTask<App.Dto.Res.Biz.GetConnectionStatus> ConnectionStatusAsync(GetConnectionStatus request, CallContext context = default);

    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    ValueTask<App.Dto.Res.Biz.SetTagValue> SetTagValueAsync(SetTagValue request, CallContext context = default);

    [Operation]
    //[FaultContract(typeof(BusinessFault))]
    ValueTask<App.Dto.Res.Biz.GetTagValue> GetTagValueAsync(GetTagValue request, CallContext context = default);
}