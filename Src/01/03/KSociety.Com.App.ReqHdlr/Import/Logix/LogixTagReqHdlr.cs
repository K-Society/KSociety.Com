using KSociety.Base.App.Shared;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.App.Dto.Req.Import.Logix;
using KSociety.Com.Domain.Repository.Logix;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.App.ReqHdlr.Import.Logix;

public class LogixTagReqHdlr :
    IRequestHandlerWithResponse<LogixTag, KSociety.Com.App.Dto.Res.Import.Logix.LogixTag>,
    IRequestHandlerWithResponseAsync<LogixTag, KSociety.Com.App.Dto.Res.Import.Logix.LogixTag>
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly ILogger<LogixTagReqHdlr> _logger;
    private readonly IDatabaseUnitOfWork _unitOfWork;
    private readonly ITag _tagRepository;

    public LogixTagReqHdlr(ILoggerFactory loggerFactory, IDatabaseUnitOfWork unitOfWork, ITag tagRepository)
    {
        _loggerFactory = loggerFactory;
        _logger = _loggerFactory.CreateLogger<LogixTagReqHdlr>();
        _unitOfWork = unitOfWork;
        _tagRepository = tagRepository;
    }

    public KSociety.Com.App.Dto.Res.Import.Logix.LogixTag Execute(LogixTag request)
    {
        var result = _tagRepository.ImportCsv(request.ByteArray);
        var output = _unitOfWork.Commit();

        return output == -1 ? new KSociety.Com.App.Dto.Res.Import.Logix.LogixTag(result)
            : new KSociety.Com.App.Dto.Res.Import.Logix.LogixTag(false);
    }

    public async ValueTask<KSociety.Com.App.Dto.Res.Import.Logix.LogixTag> ExecuteAsync(LogixTag request, CancellationToken cancellationToken = default)
    {
        var result = await _tagRepository.ImportCsvAsync(request.ByteArray, cancellationToken).ConfigureAwait(false);
        var output = await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false);

        //return new KSociety.Com.App.Dto.Res.Import.Logix.LogixTag(true);

        return output == -1 ? new KSociety.Com.App.Dto.Res.Import.Logix.LogixTag(result) : new KSociety.Com.App.Dto.Res.Import.Logix.LogixTag(false);
    }
}