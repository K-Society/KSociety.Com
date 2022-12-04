using KSociety.Base.App.Shared;
using KSociety.Base.Infra.Abstraction.Interface;
using KSociety.Com.App.Dto.Req.Remove.Common;
using KSociety.Com.Domain.Repository.Common;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.App.ReqHdlr.Remove.Common;

public class TagReqHdlr :
    IRequestHandlerWithResponse<Tag, KSociety.Com.App.Dto.Res.Remove.Common.Tag>,
    IRequestHandlerWithResponseAsync<Tag, KSociety.Com.App.Dto.Res.Remove.Common.Tag>
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly ILogger<TagReqHdlr> _logger;
    private readonly IDatabaseUnitOfWork _unitOfWork;
    private readonly ITag _tagRepository;

    public TagReqHdlr(ILoggerFactory loggerFactory, IDatabaseUnitOfWork unitOfWork, ITag tagRepository)
    {
        _loggerFactory = loggerFactory;
        _logger = _loggerFactory.CreateLogger<TagReqHdlr>();
        _unitOfWork = unitOfWork;
        _tagRepository = tagRepository;
    }

    public KSociety.Com.App.Dto.Res.Remove.Common.Tag Execute(Tag request)
    {
        var commonTag = _tagRepository.Find(request.Id); //.GetAllTag().SingleOrDefault(tag => tag.Id == request.Id);

        _tagRepository.Delete(commonTag);

        return new KSociety.Com.App.Dto.Res.Remove.Common.Tag(_unitOfWork.Commit() > 0);
    }

    public async ValueTask<KSociety.Com.App.Dto.Res.Remove.Common.Tag> ExecuteAsync(Tag request, CancellationToken cancellationToken = default)
    {
        var commonTag = await _tagRepository.FindAsync(cancellationToken, request.Id).ConfigureAwait(false); //.GetAllTag().SingleOrDefault(tag => tag.Id == request.Id);

        _tagRepository.Delete(commonTag);

        return new KSociety.Com.App.Dto.Res.Remove.Common.Tag(await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false) > 0);
    }
}