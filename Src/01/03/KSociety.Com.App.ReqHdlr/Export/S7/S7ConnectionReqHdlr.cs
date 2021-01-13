using KSociety.Base.App.Shared;
using KSociety.Com.App.Dto.Req.Export.S7;
using KSociety.Com.Domain.Repository.S7;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.App.ReqHdlr.Export.S7
{
    public class S7ConnectionReqHdlr :
        IRequestHandlerWithResponse<S7Connection, KSociety.Com.App.Dto.Res.Export.S7.S7Connection>,
        IRequestHandlerWithResponseAsync<S7Connection, KSociety.Com.App.Dto.Res.Export.S7.S7Connection>
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<S7ConnectionReqHdlr> _logger;
        private readonly IConnection _connectionRepository;

        public S7ConnectionReqHdlr(ILoggerFactory loggerFactory, IConnection connectionRepository)
        {
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<S7ConnectionReqHdlr>();
            _connectionRepository = connectionRepository;
        }

        public KSociety.Com.App.Dto.Res.Export.S7.S7Connection Execute(S7Connection request)
        {
            _connectionRepository.ExportCsv(request.FileName);

            return new KSociety.Com.App.Dto.Res.Export.S7.S7Connection(true);
        }

        public async ValueTask<KSociety.Com.App.Dto.Res.Export.S7.S7Connection> ExecuteAsync(S7Connection request, CancellationToken cancellationToken = default)
        {
            await _connectionRepository.ExportCsvAsync(request.FileName, cancellationToken).ConfigureAwait(false);

            return new KSociety.Com.App.Dto.Res.Export.S7.S7Connection(true);
        }
    }
}
