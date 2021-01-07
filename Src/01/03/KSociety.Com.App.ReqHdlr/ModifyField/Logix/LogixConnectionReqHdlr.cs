using System.Threading;
using System.Threading.Tasks;
using KSociety.Base.App.Shared;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.App.Dto.Req.ModifyField.Logix;
using KSociety.Com.Domain.Repository.Logix;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.App.ReqHdlr.ModifyField.Logix
{
    public class LogixConnectionReqHdlr :
        IRequestHandlerWithResponse<LogixConnection, KSociety.Com.App.Dto.Res.ModifyField.Logix.LogixConnection>,
        IRequestHandlerWithResponseAsync<LogixConnection, KSociety.Com.App.Dto.Res.ModifyField.Logix.LogixConnection>
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<LogixConnectionReqHdlr> _logger;
        private readonly IDatabaseUnitOfWork _unitOfWork;
        private readonly IConnection _connectionRepository;

        public LogixConnectionReqHdlr(ILoggerFactory loggerFactory, IDatabaseUnitOfWork unitOfWork, IConnection connectionRepository)
        {
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<LogixConnectionReqHdlr>();
            _unitOfWork = unitOfWork;
            _connectionRepository = connectionRepository;
        }

        public KSociety.Com.App.Dto.Res.ModifyField.Logix.LogixConnection Execute(LogixConnection request)
        {
            var logixConnection = _connectionRepository.Find(request.Id); //.GetAllLogixConnection().SingleOrDefault(g => g.Id == request.Id);
            logixConnection?.ModifyField(request.FieldName, request.Value);
            var result = _unitOfWork.Commit();
            return new KSociety.Com.App.Dto.Res.ModifyField.Logix.LogixConnection(result > 0);
        }

        public async ValueTask<KSociety.Com.App.Dto.Res.ModifyField.Logix.LogixConnection> ExecuteAsync(LogixConnection request, CancellationToken cancellationToken = default)
        {
            var logixConnection = await _connectionRepository.FindAsync(cancellationToken, request.Id).ConfigureAwait(false); //.GetAllLogixConnection().SingleOrDefault(g => g.Id == request.Id);
            logixConnection?.ModifyField(request.FieldName, request.Value);
            var result = await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false);
            return new KSociety.Com.App.Dto.Res.ModifyField.Logix.LogixConnection(result > 0);
        }
    }
}
