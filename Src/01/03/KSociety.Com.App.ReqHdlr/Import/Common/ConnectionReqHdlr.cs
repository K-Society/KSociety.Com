using KSociety.Base.App.Shared;
using KSociety.Com.App.Dto.Req.Import.Common;
using KSociety.Com.Domain.Repository.Common;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.App.ReqHdlr.Import.Common
{
    public class ConnectionReqHdlr :
        IRequestHandlerWithResponse<Connection, KSociety.Com.App.Dto.Res.Import.Common.Connection>,
        IRequestHandlerWithResponseAsync<Connection, KSociety.Com.App.Dto.Res.Import.Common.Connection>
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<ConnectionReqHdlr> _logger;
        private readonly IConnection _connectionRepository;

        public ConnectionReqHdlr(ILoggerFactory loggerFactory, IConnection connectionRepository)
        {
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<ConnectionReqHdlr>();
            _connectionRepository = connectionRepository;
        }

        public KSociety.Com.App.Dto.Res.Import.Common.Connection Execute(Connection request)
        {
            _connectionRepository.ImportCsv(request.ByteArray);

            return new KSociety.Com.App.Dto.Res.Import.Common.Connection(true);
        }

        public async ValueTask<KSociety.Com.App.Dto.Res.Import.Common.Connection> ExecuteAsync(Connection request, CancellationToken cancellationToken = default)
        {
            try
            {
                await _connectionRepository.ImportCsvAsync(request.ByteArray, cancellationToken).ConfigureAwait(false);

                return new KSociety.Com.App.Dto.Res.Import.Common.Connection(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + ": " + ex.Message + " - " + ex.StackTrace);
            }

            return new KSociety.Com.App.Dto.Res.Import.Common.Connection(false);
        }
    }
}
