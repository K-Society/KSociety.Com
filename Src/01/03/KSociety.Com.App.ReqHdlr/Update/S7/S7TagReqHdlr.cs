using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using KSociety.Base.App.Shared;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.App.Dto.Req.Update.S7;
using KSociety.Com.Domain.Repository.S7;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.App.ReqHdlr.Update.S7
{
    public class S7TagReqHdlr :
        IRequestHandlerWithResponse<S7Tag, KSociety.Com.App.Dto.Res.Update.S7.S7Tag>,
        IRequestHandlerWithResponseAsync<S7Tag, KSociety.Com.App.Dto.Res.Update.S7.S7Tag>
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<S7TagReqHdlr> _logger;
        private readonly IDatabaseUnitOfWork _unitOfWork;
        private readonly ITag _tagRepository;
        private readonly IMapper _mapper;

        public S7TagReqHdlr(ILoggerFactory loggerFactory, IDatabaseUnitOfWork unitOfWork, ITag tagRepository, IMapper mapper)
        {
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<S7TagReqHdlr>();
            _unitOfWork = unitOfWork;
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public KSociety.Com.App.Dto.Res.Update.S7.S7Tag Execute(S7Tag request)
        {
            var s7Tag = _mapper.Map<Domain.Entity.S7.S7Tag>(request);
            _tagRepository.Update(s7Tag);
            var result = _unitOfWork.Commit();
            return result == -1 ? new KSociety.Com.App.Dto.Res.Update.S7.S7Tag(Guid.Empty) : new KSociety.Com.App.Dto.Res.Update.S7.S7Tag(s7Tag.Id);
        }

        public async ValueTask<KSociety.Com.App.Dto.Res.Update.S7.S7Tag> ExecuteAsync(S7Tag request, CancellationToken cancellationToken = default)
        {
            var s7Tag = _mapper.Map<Domain.Entity.S7.S7Tag>(request);
            _tagRepository.Update(s7Tag);
            var result = await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false);
            return result == -1 ? new KSociety.Com.App.Dto.Res.Update.S7.S7Tag(Guid.Empty) : new KSociety.Com.App.Dto.Res.Update.S7.S7Tag(s7Tag.Id);
        }
    }
}
