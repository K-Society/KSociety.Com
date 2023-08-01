using AutoMapper;
using KSociety.Base.App.Shared;
using KSociety.Base.Infra.Abstraction.Interface;
using KSociety.Com.App.Dto.Req.Add.Common;
using KSociety.Com.Domain.Repository.Common;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.App.ReqHdlr.Add.Common;

public class TagReqHdlr :
    IRequestHandlerWithResponse<Tag, KSociety.Com.App.Dto.Res.Add.Common.Tag>,
    IRequestHandlerWithResponseAsync<Tag, KSociety.Com.App.Dto.Res.Add.Common.Tag>
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly ILogger<TagReqHdlr> _logger;
    private readonly IDatabaseUnitOfWork _unitOfWork;
    private readonly ITag _tagRepository;
    private readonly IMapper _mapper;

    public TagReqHdlr(ILoggerFactory loggerFactory, IDatabaseUnitOfWork unitOfWork, ITag tagRepository, IMapper mapper)
    {
        _loggerFactory = loggerFactory;
        _logger = _loggerFactory.CreateLogger<TagReqHdlr>();
        _unitOfWork = unitOfWork;
        _tagRepository = tagRepository;
        _mapper = mapper;
    }

    public KSociety.Com.App.Dto.Res.Add.Common.Tag Execute(Tag request)
    {
        var commonTag = _mapper.Map<Domain.Entity.Common.Tag>(request);
        _tagRepository.Add(commonTag);
        var result = _unitOfWork.Commit();
        return result == -1 ? new KSociety.Com.App.Dto.Res.Add.Common.Tag(Guid.Empty) : new KSociety.Com.App.Dto.Res.Add.Common.Tag(commonTag.Id);
    }

    public async ValueTask<KSociety.Com.App.Dto.Res.Add.Common.Tag> ExecuteAsync(Tag request, CancellationToken cancellationToken = default)
    {
        var commonTag = _mapper.Map<Domain.Entity.Common.Tag>(request);
        await _tagRepository.AddAsync(commonTag, cancellationToken).ConfigureAwait(false);
        var result = await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false);
        return result == -1 ? new KSociety.Com.App.Dto.Res.Add.Common.Tag(Guid.Empty) : new KSociety.Com.App.Dto.Res.Add.Common.Tag(commonTag.Id);
    }
}