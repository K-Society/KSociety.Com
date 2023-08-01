using System;
using System.Threading;
using System.Threading.Tasks;
using KSociety.Base.App.Shared;
using KSociety.Com.App.Dto.Req.Biz;
using KSociety.Com.Biz.Event;
using KSociety.Com.Biz.Interface;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.App.ReqHdlr.Biz;

public class GetConnectionStatusReqHdlr 
    : IRequestHandlerWithResponse<GetConnectionStatus, KSociety.Com.App.Dto.Res.Biz.GetConnectionStatus>,
        IRequestHandlerWithResponseAsync<GetConnectionStatus, KSociety.Com.App.Dto.Res.Biz.GetConnectionStatus>
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly ILogger<GetConnectionStatusReqHdlr> _logger;
    private readonly IBiz _startup;

    public GetConnectionStatusReqHdlr(ILoggerFactory loggerFactory, IBiz startup /*IMapper mapper*/)
    {
        _loggerFactory = loggerFactory;
        _logger = _loggerFactory.CreateLogger<GetConnectionStatusReqHdlr>();
        _startup = startup;
        //_mapper = mapper;
    }

    public KSociety.Com.App.Dto.Res.Biz.GetConnectionStatus Execute(GetConnectionStatus request)
    {
        var output = new KSociety.Com.App.Dto.Res.Biz.GetConnectionStatus();

        try
        {
            var result = _startup.GetConnectionStatus(new ConnectionStatusIntegrationEvent(request.GroupName + ".automation.connection.server", request.GroupName + ".automation.connection.client.com", request.GroupName, request.ConnectionName));

            output.GroupName = result.GroupName;
            output.ConnectionName = result.ConnectionName;
            output.ConnectionRead = result.ConnectionRead;
            output.ConnectionWrite = result.ConnectionWrite;
        }
        catch (Exception ex)
        {
            _logger.LogError("SetTagValue Execute:  " + ex.Message + " - " + ex.StackTrace);
        }

        return output;
    }

    public async ValueTask<KSociety.Com.App.Dto.Res.Biz.GetConnectionStatus> ExecuteAsync(GetConnectionStatus request, CancellationToken cancellationToken = default)
    {
        var output = new KSociety.Com.App.Dto.Res.Biz.GetConnectionStatus();

        try
        {
            var result = await _startup.GetConnectionStatusAsync(new ConnectionStatusIntegrationEvent(request.GroupName + ".automation.connection.server", request.GroupName + ".automation.connection.client.com", request.GroupName, request.ConnectionName)).ConfigureAwait(false);

            output.GroupName = result.GroupName;
            output.ConnectionName = result.ConnectionName;
            output.ConnectionRead = result.ConnectionRead;
            output.ConnectionWrite = result.ConnectionWrite;
        }
        catch (Exception ex)
        {
            _logger.LogError("SetTagValue Execute:  " + ex.Message + " - " + ex.StackTrace);
        }

        return output;
    }
}