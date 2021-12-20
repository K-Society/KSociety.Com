using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using KSociety.Base.App.Shared;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.App.Dto.Req.Update.S7;
using KSociety.Com.Domain.Repository.S7;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.App.ReqHdlr.Update.S7;

public class S7ConnectionReqHdlr :
    IRequestHandlerWithResponse<S7Connection, KSociety.Com.App.Dto.Res.Update.S7.S7Connection>,
    IRequestHandlerWithResponseAsync<S7Connection, KSociety.Com.App.Dto.Res.Update.S7.S7Connection>
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly ILogger<S7ConnectionReqHdlr> _logger;
    private readonly IDatabaseUnitOfWork _unitOfWork;
    private readonly IConnection _connectionRepository;
    private readonly IMapper _mapper;

    public S7ConnectionReqHdlr(ILoggerFactory loggerFactory, IDatabaseUnitOfWork unitOfWork, IConnection connectionRepository, IMapper mapper)
    {
        _loggerFactory = loggerFactory;
        _logger = _loggerFactory.CreateLogger<S7ConnectionReqHdlr>();
        _unitOfWork = unitOfWork;
        _connectionRepository = connectionRepository;
        _mapper = mapper;
    }

    public KSociety.Com.App.Dto.Res.Update.S7.S7Connection Execute(S7Connection request)
    {
        var s7Connection = _mapper.Map<Domain.Entity.S7.S7Connection>(request);
        _connectionRepository.Update(s7Connection);
        return _unitOfWork.Commit() == -1 ? new KSociety.Com.App.Dto.Res.Update.S7.S7Connection(Guid.Empty) : new KSociety.Com.App.Dto.Res.Update.S7.S7Connection(s7Connection.Id);
    }

    public async ValueTask<KSociety.Com.App.Dto.Res.Update.S7.S7Connection> ExecuteAsync(S7Connection request, CancellationToken cancellationToken = default)
    {
        var s7Connection = _mapper.Map<Domain.Entity.S7.S7Connection>(request);
        _connectionRepository.Update(s7Connection);
        var result = await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false);
        return result == -1 ? new KSociety.Com.App.Dto.Res.Update.S7.S7Connection(Guid.Empty) : new KSociety.Com.App.Dto.Res.Update.S7.S7Connection(s7Connection.Id);
    }
}