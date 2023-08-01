using KSociety.Com.App.Dto.Req.Biz;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.Srv.Agent.Interface.Biz;

public interface IBiz
{
    IAsyncEnumerable<Dto.HeartBeat> SendHeartBeatAsync(CancellationToken cancellationToken = default);

    IAsyncEnumerable<Dto.Biz.NotifyTagRes> NotifyTagInvokeAsync(Dto.Biz.NotifyTagReq request, CancellationToken cancellationToken = default);

    ValueTask<App.Dto.Res.Biz.GetConnectionStatus> GetConnectionStatusAsync(GetConnectionStatus request, CancellationToken cancellationToken = default);

    ValueTask<App.Dto.Res.Biz.GetTagValue> GetTagValueAsync(GetTagValue request, CancellationToken cancellationToken = default);

    ValueTask<App.Dto.Res.Biz.SetTagValue> SetTagValueAsync(SetTagValue request, CancellationToken cancellationToken = default);
}