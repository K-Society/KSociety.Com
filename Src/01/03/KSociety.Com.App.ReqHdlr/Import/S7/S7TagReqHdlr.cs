using KSociety.Base.App.Shared;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.App.Dto.Req.Import.S7;
using KSociety.Com.Domain.Repository.S7;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.App.ReqHdlr.Import.S7;

public class S7TagReqHdlr :
    IRequestHandlerWithResponse<S7Tag, KSociety.Com.App.Dto.Res.Import.S7.S7Tag>,
    IRequestHandlerWithResponseAsync<S7Tag, KSociety.Com.App.Dto.Res.Import.S7.S7Tag>
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly ILogger<S7TagReqHdlr> _logger;
    private readonly IDatabaseUnitOfWork _unitOfWork;
    private readonly ITag _tagRepository;

    public S7TagReqHdlr(ILoggerFactory loggerFactory, IDatabaseUnitOfWork unitOfWork, ITag tagRepository)
    {
        _loggerFactory = loggerFactory;
        _logger = _loggerFactory.CreateLogger<S7TagReqHdlr>();
        _unitOfWork = unitOfWork;
        _tagRepository = tagRepository;
    }

    public KSociety.Com.App.Dto.Res.Import.S7.S7Tag Execute(S7Tag request)
    {
        var result = _tagRepository.ImportCsv(request.ByteArray);
        var output = _unitOfWork.Commit();
        return output == -1 ? new KSociety.Com.App.Dto.Res.Import.S7.S7Tag(result)
            : new KSociety.Com.App.Dto.Res.Import.S7.S7Tag(false);
    }

    public async ValueTask<KSociety.Com.App.Dto.Res.Import.S7.S7Tag> ExecuteAsync(S7Tag request, CancellationToken cancellationToken = default)
    {
        var result = await _tagRepository.ImportCsvAsync(request.ByteArray, cancellationToken).ConfigureAwait(false);
        var output = await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false);
        return output == -1 ? new KSociety.Com.App.Dto.Res.Import.S7.S7Tag(result) : new KSociety.Com.App.Dto.Res.Import.S7.S7Tag(false);
    }
}