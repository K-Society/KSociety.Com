using AutoMapper;
using KSociety.Base.App.Shared;
using KSociety.Base.Infra.Abstraction.Interface;
using KSociety.Com.App.Dto.Req.Add.Logix;
using KSociety.Com.Domain.Repository.Logix;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.App.ReqHdlr.Copy.Logix;

public class LogixConnectionReqHdlr :
    IRequestHandlerWithResponse<LogixConnection, KSociety.Com.App.Dto.Res.Add.Logix.LogixConnection>,
    IRequestHandlerWithResponseAsync<LogixConnection, KSociety.Com.App.Dto.Res.Add.Logix.LogixConnection>
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly ILogger<LogixConnectionReqHdlr> _logger;
    private readonly IDatabaseUnitOfWork _unitOfWork;
    private readonly IConnection _connectionRepository;
    private readonly IMapper _mapper;

    public LogixConnectionReqHdlr(ILoggerFactory loggerFactory, IDatabaseUnitOfWork unitOfWork, IConnection connectionRepository, IMapper mapper)
    {
        _loggerFactory = loggerFactory;
        _logger = _loggerFactory.CreateLogger<LogixConnectionReqHdlr>();
        _unitOfWork = unitOfWork;
        _connectionRepository = connectionRepository;
        _mapper = mapper;
    }

    public KSociety.Com.App.Dto.Res.Add.Logix.LogixConnection Execute(LogixConnection request)
    {

        var logixConnection = _mapper.Map<Domain.Entity.Logix.LogixConnection>(request);
        _connectionRepository.Add(logixConnection);
        return _unitOfWork.Commit() == -1 ? new KSociety.Com.App.Dto.Res.Add.Logix.LogixConnection(Guid.Empty) : new KSociety.Com.App.Dto.Res.Add.Logix.LogixConnection(logixConnection.Id);
    }

    public async ValueTask<KSociety.Com.App.Dto.Res.Add.Logix.LogixConnection> ExecuteAsync(LogixConnection request, CancellationToken cancellationToken = default)
    {

        var logixConnection = _mapper.Map<Domain.Entity.Logix.LogixConnection>(request);
        await _connectionRepository.AddAsync(logixConnection, cancellationToken).ConfigureAwait(false);
        return await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false) == -1 ? new KSociety.Com.App.Dto.Res.Add.Logix.LogixConnection(Guid.Empty) : new KSociety.Com.App.Dto.Res.Add.Logix.LogixConnection(logixConnection.Id);
    }
}