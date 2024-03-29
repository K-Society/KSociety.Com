﻿using AutoMapper;
using KSociety.Base.App.Shared;
using KSociety.Base.Infra.Abstraction.Interface;
using KSociety.Com.App.Dto.Req.Add.Logix;
using KSociety.Com.Domain.Repository.Logix;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.App.ReqHdlr.Update.Logix;

public class LogixTagReqHdlr :
    IRequestHandlerWithResponse<LogixTag, KSociety.Com.App.Dto.Res.Update.Logix.LogixTag>,
    IRequestHandlerWithResponseAsync<LogixTag, KSociety.Com.App.Dto.Res.Update.Logix.LogixTag>
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly ILogger<LogixTagReqHdlr> _logger;
    private readonly IDatabaseUnitOfWork _unitOfWork;
    private readonly ITag _tagRepository;
    private readonly IMapper _mapper;

    public LogixTagReqHdlr(ILoggerFactory loggerFactory, IDatabaseUnitOfWork unitOfWork, ITag tagRepository, IMapper mapper)
    {
        _loggerFactory = loggerFactory;
        _logger = _loggerFactory.CreateLogger<LogixTagReqHdlr>();
        _unitOfWork = unitOfWork;
        _tagRepository = tagRepository;
        _mapper = mapper;
    }

    public KSociety.Com.App.Dto.Res.Update.Logix.LogixTag Execute(LogixTag request)
    {

        var logixTag = _mapper.Map<Domain.Entity.Logix.LogixTag>(request);
        _tagRepository.Update(logixTag);
        return _unitOfWork.Commit() == -1 ? new KSociety.Com.App.Dto.Res.Update.Logix.LogixTag(Guid.Empty) : new KSociety.Com.App.Dto.Res.Update.Logix.LogixTag(logixTag.Id);
    }

    public async ValueTask<KSociety.Com.App.Dto.Res.Update.Logix.LogixTag> ExecuteAsync(LogixTag request, CancellationToken cancellationToken = default)
    {

        var logixTag = _mapper.Map<Domain.Entity.Logix.LogixTag>(request);
        _tagRepository.Update(logixTag);
        return await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false) == -1 ? new KSociety.Com.App.Dto.Res.Update.Logix.LogixTag(Guid.Empty) : new KSociety.Com.App.Dto.Res.Update.Logix.LogixTag(logixTag.Id);
    }
}