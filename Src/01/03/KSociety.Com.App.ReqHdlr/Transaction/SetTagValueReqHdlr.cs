using System;
using System.Threading;
using System.Threading.Tasks;
using KSociety.Base.App.Shared;
using KSociety.Com.App.Dto.Req.Transaction;
using KSociety.Com.Biz.IntegrationEvent.Event;
using KSociety.Com.Biz.Interface;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.App.ReqHdlr.Transaction
{
    public class SetTagValueReqHdlr :
        IRequestHandlerWithResponse<SetTagValue, KSociety.Com.App.Dto.Res.Transaction.SetTagValue>,
        IRequestHandlerWithResponseAsync<SetTagValue, KSociety.Com.App.Dto.Res.Transaction.SetTagValue>
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

        public KSociety.Com.App.Dto.Res.Transaction.SetTagValue Execute(SetTagValue request)
        {
            var output = new KSociety.Com.App.Dto.Res.Transaction.SetTagValue();

            try
            {
                var result = _startup.SetTagValue(new TagWriteIntegrationEvent(request.GroupName + ".automation.write", ".automation.write", request.GroupName, request.TagName, request.Value));
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

        public async ValueTask<KSociety.Com.App.Dto.Res.Transaction.SetTagValue> ExecuteAsync(SetTagValue request, CancellationToken cancellationToken = default)
        {
            var output = new KSociety.Com.App.Dto.Res.Transaction.SetTagValue();
            //_logger.Trace("GetTagValue Execute: " + request.GroupName + " - " + request.TagName + " - " + _startup.SystemGroups.Count);
            try
            {
                var result = await _startup
                    .SetTagValueAsync(new TagWriteIntegrationEvent(request.GroupName + ".automation.write", ".automation.write", request.GroupName, request.TagName, request.Value)).ConfigureAwait(false);
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
}
