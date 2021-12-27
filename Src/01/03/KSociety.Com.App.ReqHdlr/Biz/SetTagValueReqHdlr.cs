using System;
using System.Threading;
using System.Threading.Tasks;
using KSociety.Base.App.Shared;
using KSociety.Com.App.Dto.Req.Biz;
using KSociety.Com.Biz.Event;
using KSociety.Com.Biz.Interface;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.App.ReqHdlr.Biz;

public class SetTagValueReqHdlr :
    IRequestHandlerWithResponse<SetTagValue, KSociety.Com.App.Dto.Res.Biz.SetTagValue>,
    IRequestHandlerWithResponseAsync<SetTagValue, KSociety.Com.App.Dto.Res.Biz.SetTagValue>
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly ILogger<SetTagValueReqHdlr> _logger;
    private readonly IBiz _startup;

    public SetTagValueReqHdlr(ILoggerFactory loggerFactory, IBiz startup /*IMapper mapper*/)
    {
        _loggerFactory = loggerFactory;
        _logger = _loggerFactory.CreateLogger<SetTagValueReqHdlr>();
        _startup = startup;
        //_mapper = mapper;
    }

    public KSociety.Com.App.Dto.Res.Biz.SetTagValue Execute(SetTagValue request)
    {
        var output = new KSociety.Com.App.Dto.Res.Biz.SetTagValue();

        try
        {
            var result = _startup.SetTagValue(new TagWriteIntegrationEvent(request.GroupName + ".automation.write", request.GroupName + ".automation.write.client.com", request.GroupName, request.TagName, request.Value));
            output.GroupName = result.GroupName;
            output.TagName = result.TagName;
            output.Result = true;
        }
        catch (Exception ex)
        {
            _logger.LogError("SetTagValue Execute:  " + ex.Message + " - " + ex.StackTrace);
        }

        return output;
    }

    public async ValueTask<KSociety.Com.App.Dto.Res.Biz.SetTagValue> ExecuteAsync(SetTagValue request, CancellationToken cancellationToken = default)
    {
        var output = new KSociety.Com.App.Dto.Res.Biz.SetTagValue();
        //_logger.LogTrace("GetTagValue ExecuteAsync: " + request.GroupName + " - " + request.TagName + " - " + _startup.SystemGroups.Count);
        try
        {
            var result = await _startup.SetTagValueAsync(new TagWriteIntegrationEvent(request.GroupName + ".automation.write", request.GroupName + ".automation.write.client.com", request.GroupName, request.TagName, request.Value)).ConfigureAwait(false);
            output.GroupName = result.GroupName;
            output.TagName = result.TagName;
            output.Result = true;
        }
        catch (Exception ex)
        {
            _logger.LogError("SetTagValue Execute:  " + ex.Message + " - " + ex.StackTrace);
        }
        return output;
    }
}