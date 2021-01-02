using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using KSociety.Base.App.Shared;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.App.Dto.Req.Update.Common;
using KSociety.Com.Domain.Repository.Common;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.App.ReqHdlr.Update.Common
{
    public class ConnectionReqHdlr :
        IRequestHandlerWithResponse<Connection, KSociety.Com.App.Dto.Res.Update.Common.Connection>,
        IRequestHandlerWithResponseAsync<Connection, KSociety.Com.App.Dto.Res.Update.Common.Connection>
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

        public KSociety.Com.App.Dto.Res.Update.Common.Connection Execute(Connection request)
        {
            var commonConnection = _mapper.Map<Domain.Entity.Common.Connection>(request);
            var entryEntity = _connectionRepository.Update(commonConnection);
            var result = _unitOfWork.Commit();
            return result == -1 ? new KSociety.Com.App.Dto.Res.Update.Common.Connection(Guid.Empty) : new KSociety.Com.App.Dto.Res.Update.Common.Connection(commonConnection.Id);
        }

        public async ValueTask<KSociety.Com.App.Dto.Res.Update.Common.Connection> ExecuteAsync(Connection request, CancellationToken cancellationToken = default)
        {
            var commonConnection = _mapper.Map<Domain.Entity.Common.Connection>(request);
            var entryEntity = _connectionRepository.Update(commonConnection);
            var result = await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false);
            return result == -1 ? new KSociety.Com.App.Dto.Res.Update.Common.Connection(Guid.Empty) : new KSociety.Com.App.Dto.Res.Update.Common.Connection(commonConnection.Id);
        }
    }
}
