using KSociety.Base.App.Shared;
using KSociety.Com.App.Dto.Req.Export.Common;
using KSociety.Com.Domain.Repository.Common;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.App.ReqHdlr.Export.Common;

public class TagGroupReqHdlr :
    IRequestHandlerWithResponse<TagGroup, KSociety.Com.App.Dto.Res.Export.Common.TagGroup>,
    IRequestHandlerWithResponseAsync<TagGroup, KSociety.Com.App.Dto.Res.Export.Common.TagGroup>
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly ILogger<TagGroupReqHdlr> _logger;
    private readonly ITagGroup _tagGroupRepository;

    public TagGroupReqHdlr(ILoggerFactory loggerFactory, ITagGroup tagGroupRepository)
    {
        _loggerFactory = loggerFactory;
        _logger = _loggerFactory.CreateLogger<TagGroupReqHdlr>();
        _tagGroupRepository = tagGroupRepository;
    }

    public KSociety.Com.App.Dto.Res.Export.Common.TagGroup Execute(TagGroup request)
    {
        _tagGroupRepository.ExportCsv(request.FileName);

        return new KSociety.Com.App.Dto.Res.Export.Common.TagGroup(true);
    }

    public async ValueTask<KSociety.Com.App.Dto.Res.Export.Common.TagGroup> ExecuteAsync(TagGroup request, CancellationToken cancellationToken = default)
    {
        await _tagGroupRepository.ExportCsvAsync(request.FileName, cancellationToken).ConfigureAwait(false);

        return new KSociety.Com.App.Dto.Res.Export.Common.TagGroup(true);
    }
}