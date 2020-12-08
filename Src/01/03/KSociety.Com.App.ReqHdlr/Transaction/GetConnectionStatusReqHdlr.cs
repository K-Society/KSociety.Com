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
    public class GetConnectionStatusReqHdlr 
        : IRequestHandlerWithResponse<GetConnectionStatus, KSociety.Com.App.Dto.Res.Transaction.GetConnectionStatus>,
            IRequestHandlerWithResponseAsync<GetConnectionStatus, KSociety.Com.App.Dto.Res.Transaction.GetConnectionStatus>
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

        public KSociety.Com.App.Dto.Res.Transaction.GetConnectionStatus Execute(GetConnectionStatus request)
        {
            var output = new KSociety.Com.App.Dto.Res.Transaction.GetConnectionStatus();

            try
            {
                var result = _startup.GetConnectionStatus(new ConnectionStatusIntegrationEvent(request.GroupName + ".automation.connection", request.GroupName, request.ConnectionName));

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

        public async ValueTask<KSociety.Com.App.Dto.Res.Transaction.GetConnectionStatus> ExecuteAsync(GetConnectionStatus request, CancellationToken cancellationToken = default)
        {
            var output = new KSociety.Com.App.Dto.Res.Transaction.GetConnectionStatus();

            try
            {
                var result = await _startup
                    .GetConnectionStatusAsync(new ConnectionStatusIntegrationEvent(request.GroupName + ".automation.connection", request.GroupName, request.ConnectionName)).ConfigureAwait(false);

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
}
