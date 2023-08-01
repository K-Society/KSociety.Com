using KSociety.Base.App.Shared;
using KSociety.Base.Infra.Abstraction.Interface;
using KSociety.Com.App.Dto.Req.Import.Common;
using KSociety.Com.Domain.Repository.Common;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.App.ReqHdlr.Import.Common;

public class TagGroupReqHdlr :
    IRequestHandlerWithResponse<TagGroup, KSociety.Com.App.Dto.Res.Import.Common.TagGroup>,
    IRequestHandlerWithResponseAsync<TagGroup, KSociety.Com.App.Dto.Res.Import.Common.TagGroup>
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly ILogger<TagGroupReqHdlr> _logger;
    private readonly IDatabaseUnitOfWork _unitOfWork;
    private readonly ITagGroup _tagGroupRepository;

    public TagGroupReqHdlr(ILoggerFactory loggerFactory, IDatabaseUnitOfWork unitOfWork, ITagGroup tagGroupRepository)
    {
        _loggerFactory = loggerFactory;
        _logger = _loggerFactory.CreateLogger<TagGroupReqHdlr>();
        _unitOfWork = unitOfWork;
        _tagGroupRepository = tagGroupRepository;
    }

    public KSociety.Com.App.Dto.Res.Import.Common.TagGroup Execute(TagGroup request)
    {
        var result = _tagGroupRepository.ImportCsv(request.ByteArray);
        var output = _unitOfWork.Commit();

        return output == -1 ? new KSociety.Com.App.Dto.Res.Import.Common.TagGroup(result)
            : new KSociety.Com.App.Dto.Res.Import.Common.TagGroup(false);
    }

    public async ValueTask<KSociety.Com.App.Dto.Res.Import.Common.TagGroup> ExecuteAsync(TagGroup request, CancellationToken cancellationToken = default)
    {
        var result = await _tagGroupRepository.ImportCsvAsync(request.ByteArray, cancellationToken).ConfigureAwait(false);
        var output = await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false);

        //return new KSociety.Com.App.Dto.Res.Import.Common.TagGroup(true);

        return output == -1 ? new KSociety.Com.App.Dto.Res.Import.Common.TagGroup(result) : new KSociety.Com.App.Dto.Res.Import.Common.TagGroup(false);
    }
}