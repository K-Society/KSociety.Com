using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using KSociety.Base.App.Shared;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.App.Dto.Req.Add.S7;
using KSociety.Com.Domain.Repository.S7;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.App.ReqHdlr.Add.S7
{
    public class S7ConnectionReqHdlr :
        IRequestHandlerWithResponse<S7Connection, KSociety.Com.App.Dto.Res.Add.S7.S7Connection>,
        IRequestHandlerWithResponseAsync<S7Connection, KSociety.Com.App.Dto.Res.Add.S7.S7Connection>
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<S7ConnectionReqHdlr> _logger;
        private readonly IDbUnitOfWork _unitOfWork;
        private readonly IConnection _connectionRepository;
        private readonly IMapper _mapper;

        public S7ConnectionReqHdlr(ILoggerFactory loggerFactory, IDbUnitOfWork unitOfWork, IConnection connectionRepository, IMapper mapper)
        {
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<S7ConnectionReqHdlr>();
            _unitOfWork = unitOfWork;
            _connectionRepository = connectionRepository;
            _mapper = mapper;
        }

        public KSociety.Com.App.Dto.Res.Add.S7.S7Connection Execute(S7Connection request)
        {
            var s7Connection = _mapper.Map<Domain.Entity.S7.S7Connection>(request);
            _connectionRepository.Add(s7Connection);
            return _unitOfWork.Commit() == -1 ? new KSociety.Com.App.Dto.Res.Add.S7.S7Connection(Guid.Empty) : new KSociety.Com.App.Dto.Res.Add.S7.S7Connection(s7Connection.Id);
        }

        public async ValueTask<KSociety.Com.App.Dto.Res.Add.S7.S7Connection> ExecuteAsync(S7Connection request, CancellationToken cancellationToken = default)
        {
            var s7Connection = _mapper.Map<Domain.Entity.S7.S7Connection>(request);
            var addResult = await _connectionRepository.AddAsync(s7Connection, cancellationToken).ConfigureAwait(false);
            //_logger.LogTrace("S7ConnectionReqHdlr: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + " Result: " + addResult.Entity.Id + " " + s7Connection.Id);
            var result = await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false);
            _logger.LogTrace("S7ConnectionReqHdlr: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " Result: " + result + " " + s7Connection.Id);
            return result == -1 ? new KSociety.Com.App.Dto.Res.Add.S7.S7Connection(Guid.Empty) : new KSociety.Com.App.Dto.Res.Add.S7.S7Connection(s7Connection.Id);
        }
    }
}
