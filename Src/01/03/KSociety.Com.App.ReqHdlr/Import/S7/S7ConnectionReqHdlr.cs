using KSociety.Base.App.Shared;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.App.Dto.Req.Import.S7;
using KSociety.Com.Domain.Repository.S7;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.App.ReqHdlr.Import.S7;

public class S7ConnectionReqHdlr :
    IRequestHandlerWithResponse<S7Connection, KSociety.Com.App.Dto.Res.Import.S7.S7Connection>,
    IRequestHandlerWithResponseAsync<S7Connection, KSociety.Com.App.Dto.Res.Import.S7.S7Connection>
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly ILogger<S7ConnectionReqHdlr> _logger;
    private readonly IDatabaseUnitOfWork _unitOfWork;
    private readonly IConnection _connectionRepository;

    public S7ConnectionReqHdlr(ILoggerFactory loggerFactory, IDatabaseUnitOfWork unitOfWork, IConnection connectionRepository)
    {
        _loggerFactory = loggerFactory;
        _logger = _loggerFactory.CreateLogger<S7ConnectionReqHdlr>();
        _unitOfWork = unitOfWork;
        _connectionRepository = connectionRepository;
    }

    public KSociety.Com.App.Dto.Res.Import.S7.S7Connection Execute(S7Connection request)
    {
        var result = _connectionRepository.ImportCsv(request.ByteArray);
        var output = _unitOfWork.Commit();

        return output == -1 ? new KSociety.Com.App.Dto.Res.Import.S7.S7Connection(result)
            : new KSociety.Com.App.Dto.Res.Import.S7.S7Connection(false);
    }

    public async ValueTask<KSociety.Com.App.Dto.Res.Import.S7.S7Connection> ExecuteAsync(S7Connection request, CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await _connectionRepository.ImportCsvAsync(request.ByteArray, cancellationToken).ConfigureAwait(false);
            var output = await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false);

            return output == -1 ? new KSociety.Com.App.Dto.Res.Import.S7.S7Connection(result) : new KSociety.Com.App.Dto.Res.Import.S7.S7Connection(false);
        }
        catch (Exception ex)
        {
            _logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + ": " + ex.Message + " - " + ex.StackTrace);
        }

        return new KSociety.Com.App.Dto.Res.Import.S7.S7Connection(false);
    }
}