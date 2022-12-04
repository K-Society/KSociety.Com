using KSociety.Base.App.Shared;
using KSociety.Base.Infra.Abstraction.Interface;
using KSociety.Com.App.Dto.Req.ModifyField.Common;
using KSociety.Com.Domain.Repository.Common;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.App.ReqHdlr.ModifyField.Common;

public class ConnectionReqHdlr :
    IRequestHandlerWithResponse<Connection, KSociety.Com.App.Dto.Res.ModifyField.Common.Connection>,
    IRequestHandlerWithResponseAsync<Connection, KSociety.Com.App.Dto.Res.ModifyField.Common.Connection>
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

    public KSociety.Com.App.Dto.Res.ModifyField.Common.Connection Execute(Connection request)
    {
        var commonConnection = _connectionRepository.Find(request.Id); //.GetAllConnection().SingleOrDefault(g => g.Id == request.Id);
        commonConnection?.ModifyField(request.FieldName, request.Value);
        return new KSociety.Com.App.Dto.Res.ModifyField.Common.Connection(_unitOfWork.Commit() > 0);
    }

    public async ValueTask<KSociety.Com.App.Dto.Res.ModifyField.Common.Connection> ExecuteAsync(Connection request, CancellationToken cancellationToken = default)
    {
        var commonConnection = await _connectionRepository.FindAsync(cancellationToken, request.Id).ConfigureAwait(false); //.GetAllConnection().SingleOrDefault(g => g.Id == request.Id);
        commonConnection?.ModifyField(request.FieldName, request.Value);
        var result = await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false);
        return new KSociety.Com.App.Dto.Res.ModifyField.Common.Connection(result > 0);
    }
}