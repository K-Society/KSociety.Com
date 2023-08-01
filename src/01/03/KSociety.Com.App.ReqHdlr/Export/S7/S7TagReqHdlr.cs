using KSociety.Base.App.Shared;
using KSociety.Com.App.Dto.Req.Export.S7;
using KSociety.Com.Domain.Repository.S7;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.App.ReqHdlr.Export.S7;

public class S7TagReqHdlr :
    IRequestHandlerWithResponse<S7Tag, KSociety.Com.App.Dto.Res.Export.S7.S7Tag>,
    IRequestHandlerWithResponseAsync<S7Tag, KSociety.Com.App.Dto.Res.Export.S7.S7Tag>
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly ILogger<S7TagReqHdlr> _logger;
    private readonly ITag _tagRepository;

    public S7TagReqHdlr(ILoggerFactory loggerFactory, ITag tagRepository)
    {
        _loggerFactory = loggerFactory;
        _logger = _loggerFactory.CreateLogger<S7TagReqHdlr>();
        _tagRepository = tagRepository;
    }

    public KSociety.Com.App.Dto.Res.Export.S7.S7Tag Execute(S7Tag request)
    {
        _tagRepository.ExportCsv(request.FileName);

        return new KSociety.Com.App.Dto.Res.Export.S7.S7Tag(true);
    }

    public async ValueTask<KSociety.Com.App.Dto.Res.Export.S7.S7Tag> ExecuteAsync(S7Tag request, CancellationToken cancellationToken = default)
    {
        await _tagRepository.ExportCsvAsync(request.FileName, cancellationToken).ConfigureAwait(false);

        return new KSociety.Com.App.Dto.Res.Export.S7.S7Tag(true);
    }
}