using AutoMapper;
using KSociety.Base.App.Shared;
using KSociety.Base.Infra.Abstraction.Interface;
using KSociety.Com.App.Dto.Req.Copy.Common;
using KSociety.Com.Domain.Repository.Common;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.App.ReqHdlr.Copy.Common;

public class ConnectionReqHdlr :
    IRequestHandlerWithResponse<Connection, KSociety.Com.App.Dto.Res.Copy.Common.Connection>,
    IRequestHandlerWithResponseAsync<Connection, KSociety.Com.App.Dto.Res.Copy.Common.Connection>
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly ILogger<ConnectionReqHdlr> _logger;
    private readonly IDatabaseUnitOfWork _unitOfWork;
    private readonly IConnection _connectionRepository;
    private readonly IMapper _mapper;

    public ConnectionReqHdlr(ILoggerFactory loggerFactory, IDatabaseUnitOfWork unitOfWork, IConnection connectionRepository, IMapper mapper)
    {
        _loggerFactory = loggerFactory;
        _logger = _loggerFactory.CreateLogger<ConnectionReqHdlr>();
        _unitOfWork = unitOfWork;
        _connectionRepository = connectionRepository;
        _mapper = mapper;
    }

    public KSociety.Com.App.Dto.Res.Copy.Common.Connection Execute(Connection request)
    {
        var commonConnection = _mapper.Map<Domain.Entity.Common.Connection>(request);
        _connectionRepository.Add(commonConnection);
        return _unitOfWork.Commit() == -1 ? new KSociety.Com.App.Dto.Res.Copy.Common.Connection(Guid.Empty) : new KSociety.Com.App.Dto.Res.Copy.Common.Connection(commonConnection.Id);
    }

    public async ValueTask<KSociety.Com.App.Dto.Res.Copy.Common.Connection> ExecuteAsync(Connection request, CancellationToken cancellationToken = default)
    {
        var commonConnection = _mapper.Map<Domain.Entity.Common.Connection>(request);
        await _connectionRepository.AddAsync(commonConnection, cancellationToken).ConfigureAwait(false);
        return await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false) == -1 ? new KSociety.Com.App.Dto.Res.Copy.Common.Connection(Guid.Empty) : new KSociety.Com.App.Dto.Res.Copy.Common.Connection(commonConnection.Id);
    }

}