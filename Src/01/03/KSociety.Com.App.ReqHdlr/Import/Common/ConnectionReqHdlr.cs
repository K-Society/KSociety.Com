using KSociety.Base.App.Shared;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.App.Dto.Req.Import.Common;
using KSociety.Com.Domain.Repository.Common;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.App.ReqHdlr.Import.Common;

public class ConnectionReqHdlr :
    IRequestHandlerWithResponse<Connection, KSociety.Com.App.Dto.Res.Import.Common.Connection>,
    IRequestHandlerWithResponseAsync<Connection, KSociety.Com.App.Dto.Res.Import.Common.Connection>
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly ILogger<ConnectionReqHdlr> _logger;
    private readonly IDatabaseUnitOfWork _unitOfWork;
    private readonly IConnection _connectionRepository;

    public ConnectionReqHdlr(ILoggerFactory loggerFactory, IDatabaseUnitOfWork unitOfWork, IConnection connectionRepository)
    {
        _loggerFactory = loggerFactory;
        _logger = _loggerFactory.CreateLogger<ConnectionReqHdlr>();
        _unitOfWork = unitOfWork;
        _connectionRepository = connectionRepository;
    }

    public KSociety.Com.App.Dto.Res.Import.Common.Connection Execute(Connection request)
    {
        var result = _connectionRepository.ImportCsv(request.ByteArray);
        var output = _unitOfWork.Commit();

        return output == -1 ? new KSociety.Com.App.Dto.Res.Import.Common.Connection(result)
            : new KSociety.Com.App.Dto.Res.Import.Common.Connection(false);
    }

    public async ValueTask<KSociety.Com.App.Dto.Res.Import.Common.Connection> ExecuteAsync(Connection request, CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await _connectionRepository.ImportCsvAsync(request.ByteArray, cancellationToken).ConfigureAwait(false);
            var output = await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false);

            //return new KSociety.Com.App.Dto.Res.Import.Common.Connection(true);

            return output == -1 ? new KSociety.Com.App.Dto.Res.Import.Common.Connection(result) : new KSociety.Com.App.Dto.Res.Import.Common.Connection(false);
        }
        catch (Exception ex)
        {
            _logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + ": " + ex.Message + " - " + ex.StackTrace);
        }

        return new KSociety.Com.App.Dto.Res.Import.Common.Connection(false);
    }
}