using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using KSociety.Base.App.Shared;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.App.Dto.Req.Add.Common;
using KSociety.Com.Domain.Repository.Common;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.App.ReqHdlr.Add.Common
{
    public class TagGroupReqHdlr :
        IRequestHandlerWithResponse<TagGroup, KSociety.Com.App.Dto.Res.Add.Common.TagGroup>,
        IRequestHandlerWithResponseAsync<TagGroup, KSociety.Com.App.Dto.Res.Add.Common.TagGroup>
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<TagGroupReqHdlr> _logger;
        private readonly IDbUnitOfWork _unitOfWork;
        private readonly ITagGroup _tagGroupRepository;
        private readonly IMapper _mapper;

        public TagGroupReqHdlr(ILoggerFactory loggerFactory, IDbUnitOfWork unitOfWork, ITagGroup tagGroupRepository, IMapper mapper)
        {
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<TagGroupReqHdlr>();
            _unitOfWork = unitOfWork;
            _tagGroupRepository = tagGroupRepository;
            _mapper = mapper;
        }

        public KSociety.Com.App.Dto.Res.Add.Common.TagGroup Execute(TagGroup request)
        {
            var commonTagGroup = _mapper.Map<Domain.Entity.Common.TagGroup>(request);
            var entityEntry = _tagGroupRepository.Add(commonTagGroup);
            return _unitOfWork.Commit() == -1 ? new KSociety.Com.App.Dto.Res.Add.Common.TagGroup(Guid.Empty) : new KSociety.Com.App.Dto.Res.Add.Common.TagGroup(commonTagGroup.Id);
        }

        public async ValueTask<KSociety.Com.App.Dto.Res.Add.Common.TagGroup> ExecuteAsync(TagGroup request, CancellationToken cancellationToken = default)
        {
            var commonTagGroup = _mapper.Map<Domain.Entity.Common.TagGroup>(request);
            var entityEntry = await _tagGroupRepository.AddAsync(commonTagGroup, cancellationToken).ConfigureAwait(false);
            var result = await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false);
            return result == -1 ? new KSociety.Com.App.Dto.Res.Add.Common.TagGroup(Guid.Empty) : new KSociety.Com.App.Dto.Res.Add.Common.TagGroup(commonTagGroup.Id);
        }
    }
}
