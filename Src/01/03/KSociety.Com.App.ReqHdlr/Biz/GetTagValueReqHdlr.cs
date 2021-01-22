using System;
using System.Threading;
using System.Threading.Tasks;
using KSociety.Base.App.Shared;
using KSociety.Com.App.Dto.Req.Biz;
using KSociety.Com.Biz.Event;
using KSociety.Com.Biz.Interface;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.App.ReqHdlr.Biz
{
    public class GetTagValueReqHdlr :
        IRequestHandlerWithResponse<GetTagValue, KSociety.Com.App.Dto.Res.Biz.GetTagValue>,
        IRequestHandlerWithResponseAsync<GetTagValue, KSociety.Com.App.Dto.Res.Biz.GetTagValue>
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<GetTagValueReqHdlr> _logger;
        private readonly IBiz _startup;

        public GetTagValueReqHdlr(ILoggerFactory loggerFactory, IBiz startup /*IMapper mapper*/)
        {
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<GetTagValueReqHdlr>();
            _startup = startup;
            //_mapper = mapper;

        }

        public KSociety.Com.App.Dto.Res.Biz.GetTagValue Execute(GetTagValue request)
        {
            var output = new KSociety.Com.App.Dto.Res.Biz.GetTagValue();
            //_logger.Trace("GetTagValue Execute: " + request.GroupName + " - " + request.TagName + " - " + _startup.SystemGroups.Count);
            try
            {

                var result = _startup.GetTagValue(new TagReadIntegrationEvent(request.GroupName + ".automation.read", ".automation.read", request.GroupName, request.TagName));
                output.GroupName = result.GroupName;
                output.TagName = result.TagName;
                output.Value = result.TagValue;
                
            }
            catch (Exception ex)
            {
                _logger.LogError("GetTagValue Execute:  " + ex.Message + " - " + ex.StackTrace);
            }
            return output;
        }

        public async ValueTask<KSociety.Com.App.Dto.Res.Biz.GetTagValue> ExecuteAsync(GetTagValue request, CancellationToken cancellationToken = default)
        {
            var output = new KSociety.Com.App.Dto.Res.Biz.GetTagValue();
            //_logger.Trace("GetTagValue Execute: " + request.GroupName + " - " + request.TagName + " - " + _startup.SystemGroups.Count);
            try
            {
                //_startup.GetTagValue(new TagReadIntegrationEvent(request.GroupName + ".automation.readCmd", request.GroupName, request.TagName));

                var result = await _startup.GetTagValueAsync(new TagReadIntegrationEvent(request.GroupName + ".automation.read", ".automation.read", request.GroupName, request.TagName)).ConfigureAwait(false);
                output.GroupName = result.GroupName;
                output.TagName = result.TagName;
                output.Value = result.TagValue;
                
            }
            catch (Exception ex)
            {
                _logger.LogError("GetTagValue Execute:  " + ex.Message + " - " + ex.StackTrace);
            }
            return output;
        }
    }
}
