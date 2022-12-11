using AutoMapper;
using KSociety.Base.App.Shared;
using KSociety.Base.Infra.Abstraction.Interface;
using KSociety.Com.App.Dto.Req.Update.Common;
using KSociety.Com.Domain.Repository.Common;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.App.ReqHdlr.Update.Common;

public class TagGroupReqHdlr :
    IRequestHandlerWithResponse<TagGroup, KSociety.Com.App.Dto.Res.Update.Common.TagGroup>,
    IRequestHandlerWithResponseAsync<TagGroup, KSociety.Com.App.Dto.Res.Update.Common.TagGroup>
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly ILogger<TagGroupReqHdlr> _logger;
    private readonly IDatabaseUnitOfWork _unitOfWork;
    private readonly ITagGroup _tagGroupRepository;
    private readonly IMapper _mapper;

    public TagGroupReqHdlr(ILoggerFactory loggerFactory, IDatabaseUnitOfWork unitOfWork, ITagGroup tagGroupRepository, IMapper mapper)
    {
        _loggerFactory = loggerFactory;
        _logger = _loggerFactory.CreateLogger<TagGroupReqHdlr>();
        _unitOfWork = unitOfWork;
        _tagGroupRepository = tagGroupRepository;
        _mapper = mapper;
    }

    public KSociety.Com.App.Dto.Res.Update.Common.TagGroup Execute(TagGroup request)
    {
        var commonTagGroup = _mapper.Map<Domain.Entity.Common.TagGroup>(request);
        var entityEntry = _tagGroupRepository.Update(commonTagGroup);
        return _unitOfWork.Commit() == -1 ? new KSociety.Com.App.Dto.Res.Update.Common.TagGroup(Guid.Empty) : new KSociety.Com.App.Dto.Res.Update.Common.TagGroup(commonTagGroup.Id);
    }

    public async ValueTask<KSociety.Com.App.Dto.Res.Update.Common.TagGroup> ExecuteAsync(TagGroup request, CancellationToken cancellationToken = default)
    {
        var commonTagGroup = _mapper.Map<Domain.Entity.Common.TagGroup>(request);
        var entityEntry = _tagGroupRepository.Update(commonTagGroup);
        var result = await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false);
        return result == -1 ? new KSociety.Com.App.Dto.Res.Update.Common.TagGroup(Guid.Empty) : new KSociety.Com.App.Dto.Res.Update.Common.TagGroup(commonTagGroup.Id);
    }
}