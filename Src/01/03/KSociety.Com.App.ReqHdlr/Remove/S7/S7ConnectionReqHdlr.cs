using KSociety.Base.App.Shared;
using KSociety.Base.Infra.Abstraction.Interface;
using KSociety.Com.App.Dto.Req.Remove.S7;
using KSociety.Com.Domain.Repository.S7;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.App.ReqHdlr.Remove.S7;

public class S7ConnectionReqHdlr :
    IRequestHandlerWithResponse<S7Connection, KSociety.Com.App.Dto.Res.Remove.S7.S7Connection>,
    IRequestHandlerWithResponseAsync<S7Connection, KSociety.Com.App.Dto.Res.Remove.S7.S7Connection>
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly ILogger<S7ConnectionReqHdlr> _logger;
    private readonly IDatabaseUnitOfWork _unitOfWork;
    private readonly IConnection _connectionRepository;

    public S7ConnectionReqHdlr(ILoggerFactory loggerFactory, IDatabaseUnitOfWork unitOfWork, IConnection connectionRepository)
    {
        _loggerFactory = loggerFactory;
        _logger = _loggerFactory.CreateLogger<S7ConnectionReqHdlr>();
        _unitOfWork = unitOfWork;
        _connectionRepository = connectionRepository;
    }

    public KSociety.Com.App.Dto.Res.Remove.S7.S7Connection Execute(S7Connection request)
    {
        var s7Connection = _connectionRepository.Find(request.Id); //.GetAllS7Connection().SingleOrDefault(g => g.Id == request.Id);

        _connectionRepository.Delete(s7Connection);

        return new KSociety.Com.App.Dto.Res.Remove.S7.S7Connection(_unitOfWork.Commit() > 0);
    }

    public async ValueTask<KSociety.Com.App.Dto.Res.Remove.S7.S7Connection> ExecuteAsync(S7Connection request, CancellationToken cancellationToken = default)
    {
        var s7Connection = await _connectionRepository.FindAsync(cancellationToken, request.Id).ConfigureAwait(false); //.GetAllS7Connection().SingleOrDefault(g => g.Id == request.Id);

        _connectionRepository.Delete(s7Connection);

        return new KSociety.Com.App.Dto.Res.Remove.S7.S7Connection(await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false) > 0);
    }
}