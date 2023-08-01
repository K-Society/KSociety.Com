using KSociety.Base.App.Shared;
using KSociety.Com.App.Dto.Req.Export.Logix;
using KSociety.Com.Domain.Repository.Logix;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.App.ReqHdlr.Export.Logix;

public class LogixTagReqHdlr :
    IRequestHandlerWithResponse<LogixTag, KSociety.Com.App.Dto.Res.Export.Logix.LogixTag>,
    IRequestHandlerWithResponseAsync<LogixTag, KSociety.Com.App.Dto.Res.Export.Logix.LogixTag>
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly ILogger<LogixTagReqHdlr> _logger;
    private readonly ITag _tagRepository;

    public LogixTagReqHdlr(ILoggerFactory loggerFactory, ITag tagRepository)
    {
        _loggerFactory = loggerFactory;
        _logger = _loggerFactory.CreateLogger<LogixTagReqHdlr>();
        _tagRepository = tagRepository;
    }

    public KSociety.Com.App.Dto.Res.Export.Logix.LogixTag Execute(LogixTag request)
    {
        _tagRepository.ExportCsv(request.FileName);

        return new KSociety.Com.App.Dto.Res.Export.Logix.LogixTag(true);
    }

    public async ValueTask<KSociety.Com.App.Dto.Res.Export.Logix.LogixTag> ExecuteAsync(LogixTag request, CancellationToken cancellationToken = default)
    {
        await _tagRepository.ExportCsvAsync(request.FileName, cancellationToken).ConfigureAwait(false);

        return new KSociety.Com.App.Dto.Res.Export.Logix.LogixTag(true);
    }
}