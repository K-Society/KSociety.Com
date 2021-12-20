using System.Threading;
using System.Threading.Tasks;
using KSociety.Base.App.Shared;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.App.Dto.Req.ModifyField.Common;
using KSociety.Com.Domain.Repository.Common;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.App.ReqHdlr.ModifyField.Common;

public class TagGroupReqHdlr :
    IRequestHandlerWithResponse<TagGroup, KSociety.Com.App.Dto.Res.ModifyField.Common.TagGroup>,
    IRequestHandlerWithResponseAsync<TagGroup, KSociety.Com.App.Dto.Res.ModifyField.Common.TagGroup>
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

    public KSociety.Com.App.Dto.Res.ModifyField.Common.TagGroup Execute(TagGroup request)
    {
        var commonTagGroup = _tagGroupRepository.Find(request.Id); //.GetAllTagGroup().SingleOrDefault(tagGroup => tagGroup.Id == request.Id);
        commonTagGroup?.ModifyField(request.FieldName, request.Value);

        var result = _unitOfWork.Commit();

        return new KSociety.Com.App.Dto.Res.ModifyField.Common.TagGroup(result > 0);
    }

    public async ValueTask<KSociety.Com.App.Dto.Res.ModifyField.Common.TagGroup> ExecuteAsync(TagGroup request, CancellationToken cancellationToken = default)
    {
        var commonTagGroup = await _tagGroupRepository.FindAsync(cancellationToken, request.Id).ConfigureAwait(false); //.GetAllTagGroup().SingleOrDefault(tagGroup => tagGroup.Id == request.Id);
        commonTagGroup?.ModifyField(request.FieldName, request.Value);

        var result = await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false);
        return new KSociety.Com.App.Dto.Res.ModifyField.Common.TagGroup(result > 0);
    }
}