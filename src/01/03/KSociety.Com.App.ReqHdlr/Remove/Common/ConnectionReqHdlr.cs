using KSociety.Base.App.Shared;
using KSociety.Base.Infra.Abstraction.Interface;
using KSociety.Com.App.Dto.Req.Remove.Common;
using KSociety.Com.Domain.Repository.Common;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.App.ReqHdlr.Remove.Common;

public class ConnectionReqHdlr :
    IRequestHandlerWithResponse<Connection, KSociety.Com.App.Dto.Res.Remove.Common.Connection>,
    IRequestHandlerWithResponseAsync<Connection, KSociety.Com.App.Dto.Res.Remove.Common.Connection>
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly ILogger<ConnectionReqHdlr> _logger;
    private readonly IDatabaseUnitOfWork _unitOfWork;
    private readonly IConnection _connectionRepository;

    public ConnectionReqHdlr(ILoggerFactory loggerFactory, IDatabaseUnitOfWork unitOfWork, IConnection connectionRepository)
    {
        _loggerFactory = loggerFactory;
        _logger = _loggerFactory.CreateLogger<ConnectionReqHdlr>();
        _unitOfWork = unitOfWork;
        _connectionRepository = connectionRepository;
    }

    public KSociety.Com.App.Dto.Res.Remove.Common.Connection Execute(Connection request)
    {
        var commonConnection = _connectionRepository.Find(request.Id); //.GetAllConnection().SingleOrDefault(g => g.Id == request.Id);

        _connectionRepository.Delete(commonConnection);

        return new KSociety.Com.App.Dto.Res.Remove.Common.Connection(_unitOfWork.Commit() > 0);
    }

    public async ValueTask<KSociety.Com.App.Dto.Res.Remove.Common.Connection> ExecuteAsync(Connection request, CancellationToken cancellationToken = default)
    {
        var commonConnection = await _connectionRepository.FindAsync(cancellationToken, request.Id).ConfigureAwait(false); //.GetAllConnection().SingleOrDefault(g => g.Id == request.Id);

        _connectionRepository.Delete(commonConnection);

        return new KSociety.Com.App.Dto.Res.Remove.Common.Connection(await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false) > 0);
    }
}