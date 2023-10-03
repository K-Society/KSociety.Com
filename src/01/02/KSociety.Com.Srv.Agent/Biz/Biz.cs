using KSociety.Base.Srv.Agent;
using KSociety.Com.App.Dto.Req.Biz;
using KSociety.Com.Srv.Contract.Biz;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc.Client;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.Srv.Agent.Biz;

public class Biz : KSociety.Base.Srv.Agent.Connection, KSociety.Com.Srv.Agent.Interface.Biz.IBiz
{
    public Biz(IAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        : base(agentConfiguration, loggerFactory)
    {

    }

    public IEnumerable<Dto.HeartBeat> SendHeartBeat(CancellationToken cancellationToken = default)
    {
        using (Channel)
        {
            var client = Channel.CreateGrpcService<IBiz>();

            return client.SendHeartBeat(ConnectionOptions(cancellationToken));
        }

    }

    public IAsyncEnumerable<Dto.HeartBeat> SendHeartBeatAsync(CancellationToken cancellationToken = default)
    {
        using (Channel)
        {
            var client = Channel.CreateGrpcService<IBizAsync>();

            return client.SendHeartBeatAsync(ConnectionOptions(cancellationToken));
        }
            
    }

    public IAsyncEnumerable<Dto.Biz.NotifyTagRes> NotifyTagInvokeAsync(Dto.Biz.NotifyTagReq request, CancellationToken cancellationToken = default)
    {
        using (Channel)
        {
            var client = Channel.CreateGrpcService<IBizAsync>();

            return client.NotifyTagInvokeAsync(request, ConnectionOptions(cancellationToken));
        }
    }

    public App.Dto.Res.Biz.GetConnectionStatus ConnectionStatus(GetConnectionStatus request, CancellationToken cancellationToken = default)
    {
        var output = new App.Dto.Res.Biz.GetConnectionStatus();
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<IBiz>();

                var result = client.ConnectionStatus(request, ConnectionOptions(cancellationToken));

                output = result;
            }
        }
        catch (Exception ex)
        {
            Logger?.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }

    public async ValueTask<App.Dto.Res.Biz.GetConnectionStatus> GetConnectionStatusAsync(GetConnectionStatus request, CancellationToken cancellationToken = default)
    {
        var output = new App.Dto.Res.Biz.GetConnectionStatus();
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<IBizAsync>();

                var result = await client.ConnectionStatusAsync(request, ConnectionOptions(cancellationToken));

                output = result;
            }
        }
        catch (Exception ex)
        {
            Logger?.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }

    public App.Dto.Res.Biz.SetTagValue SetTagValue(SetTagValue request, CancellationToken cancellationToken = default)
    {
        var output = new App.Dto.Res.Biz.SetTagValue();
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<IBiz>();

                var result = client.SetTagValue(request, ConnectionOptions(cancellationToken));

                output = result;
            }
        }
        catch (Exception ex)
        {
            Logger?.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }

    public async ValueTask<App.Dto.Res.Biz.SetTagValue> SetTagValueAsync(SetTagValue request, CancellationToken cancellationToken = default)
    {
        var output = new App.Dto.Res.Biz.SetTagValue();
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<IBizAsync>();

                var result = await client.SetTagValueAsync(request, ConnectionOptions(cancellationToken));

                output = result;
            }
        }
        catch (Exception ex)
        {
            Logger?.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }

    public App.Dto.Res.Biz.GetTagValue GetTagValue(GetTagValue request, CancellationToken cancellationToken = default)
    {
        var output = new App.Dto.Res.Biz.GetTagValue();
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<IBiz>();

                var result = client.GetTagValue(request, ConnectionOptions(cancellationToken));

                output = result;
            }
        }
        catch (Exception ex)
        {
            Logger?.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }

    public async ValueTask<App.Dto.Res.Biz.GetTagValue> GetTagValueAsync(GetTagValue request, CancellationToken cancellationToken = default)
    {
        var output = new App.Dto.Res.Biz.GetTagValue();
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<IBizAsync>();

                var result = await client.GetTagValueAsync(request, ConnectionOptions(cancellationToken));

                output = result;
            }
        }
        catch (Exception ex)
        {
            Logger?.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return output;
    }
}