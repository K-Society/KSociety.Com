using System.Threading;
using System.Threading.Tasks;
using KSociety.Base.App.Shared;
using KSociety.Com.App.Dto.Req.Export.Common;
using KSociety.Com.Domain.Repository.Common;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.App.ReqHdlr.Export.Common;

public class ConnectionReqHdlr :
    IRequestHandlerWithResponse<Connection, KSociety.Com.App.Dto.Res.Export.Common.Connection>,
    IRequestHandlerWithResponseAsync<Connection, KSociety.Com.App.Dto.Res.Export.Common.Connection>
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

    public KSociety.Com.App.Dto.Res.Export.Common.Connection Execute(Connection request)
    {
        _connectionRepository.ExportCsv(request.FileName);

        return new KSociety.Com.App.Dto.Res.Export.Common.Connection(true);
    }

    public async ValueTask<KSociety.Com.App.Dto.Res.Export.Common.Connection> ExecuteAsync(Connection request, CancellationToken cancellationToken = default)
    {
        await _connectionRepository.ExportCsvAsync(request.FileName, cancellationToken).ConfigureAwait(false);

        return new KSociety.Com.App.Dto.Res.Export.Common.Connection(true);
    }
}