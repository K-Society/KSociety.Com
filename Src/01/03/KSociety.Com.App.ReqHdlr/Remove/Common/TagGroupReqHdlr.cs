using KSociety.Base.App.Shared;
using KSociety.Base.Infra.Abstraction.Interface;
using KSociety.Com.App.Dto.Req.Remove.Common;
using KSociety.Com.Domain.Repository.Common;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.App.ReqHdlr.Remove.Common;

public class TagGroupReqHdlr :
    IRequestHandlerWithResponse<TagGroup, KSociety.Com.App.Dto.Res.Remove.Common.TagGroup>,
    IRequestHandlerWithResponseAsync<TagGroup, KSociety.Com.App.Dto.Res.Remove.Common.TagGroup>
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

    public KSociety.Com.App.Dto.Res.Remove.Common.TagGroup Execute(TagGroup request)
    {
        var commonTagGroup = _tagGroupRepository.Find(request.Id); //.GetAllTagGroup().SingleOrDefault(tag => tag.Id == request.Id);

        _tagGroupRepository.Delete(commonTagGroup);

        return new KSociety.Com.App.Dto.Res.Remove.Common.TagGroup(_unitOfWork.Commit() > 0);
    }

    public async ValueTask<KSociety.Com.App.Dto.Res.Remove.Common.TagGroup> ExecuteAsync(TagGroup request, CancellationToken cancellationToken = default)
    {
        var commonTagGroup = await _tagGroupRepository.FindAsync(cancellationToken, request.Id).ConfigureAwait(false); //.GetAllTagGroup().SingleOrDefault(tag => tag.Id == request.Id);

        _tagGroupRepository.Delete(commonTagGroup);

        return new KSociety.Com.App.Dto.Res.Remove.Common.TagGroup(await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false) > 0);
    }
}