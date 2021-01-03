using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using KSociety.Base.App.Shared;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.App.Dto.Req.Copy.Common;
using KSociety.Com.Domain.Repository.Common;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.App.ReqHdlr.Copy.Common
{
    public class TagReqHdlr :
        IRequestHandlerWithResponse<Tag, KSociety.Com.App.Dto.Res.Copy.Common.Tag>,
        IRequestHandlerWithResponseAsync<Tag, KSociety.Com.App.Dto.Res.Copy.Common.Tag>
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<TagReqHdlr> _logger;
        private readonly IDatabaseUnitOfWork _unitOfWork;
        private readonly ITag _tagRepository;
        private readonly IMapper _mapper;

        public TagReqHdlr(ILoggerFactory loggerFactory, IDatabaseUnitOfWork unitOfWork, ITag tagRepository, IMapper mapper)
        {
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<TagReqHdlr>();
            _unitOfWork = unitOfWork;
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public KSociety.Com.App.Dto.Res.Copy.Common.Tag Execute(Tag request)
        {
            var commonTag = _mapper.Map<Domain.Entity.Common.Tag>(request);
            _tagRepository.Add(commonTag);
            return _unitOfWork.Commit() == -1 ? new KSociety.Com.App.Dto.Res.Copy.Common.Tag(Guid.Empty) : new KSociety.Com.App.Dto.Res.Copy.Common.Tag(commonTag.Id);
        }

        public async ValueTask<KSociety.Com.App.Dto.Res.Copy.Common.Tag> ExecuteAsync(Tag request, CancellationToken cancellationToken = default)
        {
            var commonTag = _mapper.Map<Domain.Entity.Common.Tag>(request);
            await _tagRepository.AddAsync(commonTag, cancellationToken).ConfigureAwait(false);
            return await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false) == -1 ? new KSociety.Com.App.Dto.Res.Copy.Common.Tag(Guid.Empty) : new KSociety.Com.App.Dto.Res.Copy.Common.Tag(commonTag.Id);
        }
    }
}
