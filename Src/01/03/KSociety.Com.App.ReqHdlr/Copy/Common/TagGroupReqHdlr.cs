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
    public class TagGroupReqHdlr :
        IRequestHandlerWithResponse<TagGroup, KSociety.Com.App.Dto.Res.Copy.Common.TagGroup>,
        IRequestHandlerWithResponseAsync<TagGroup, KSociety.Com.App.Dto.Res.Copy.Common.TagGroup>
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<TagGroupReqHdlr> _logger;
        private readonly IDatabaseUnitOfWork _unitOfWork;
        private readonly ITagGroup _tagGroupRepository;
        private readonly IMapper _mapper;

        public TagGroupReqHdlr(ILoggerFactory loggerFactory, IDatabaseUnitOfWork unitOfWork, ITagGroup tagGroupRepository, IMapper mapper)
        {
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<TagGroupReqHdlr>();
            _unitOfWork = unitOfWork;
            _tagGroupRepository = tagGroupRepository;
            _mapper = mapper;
        }

        public KSociety.Com.App.Dto.Res.Copy.Common.TagGroup Execute(TagGroup request)
        {
            var commonTagGroup = _mapper.Map<Domain.Entity.Common.TagGroup>(request);
            _tagGroupRepository.Add(commonTagGroup);
            return _unitOfWork.Commit() == -1 ? new KSociety.Com.App.Dto.Res.Copy.Common.TagGroup(Guid.Empty) : new KSociety.Com.App.Dto.Res.Copy.Common.TagGroup(commonTagGroup.Id);
        }

        public async ValueTask<KSociety.Com.App.Dto.Res.Copy.Common.TagGroup> ExecuteAsync(TagGroup request, CancellationToken cancellationToken = default)
        { 
            var commonTagGroup = _mapper.Map<Domain.Entity.Common.TagGroup>(request);
            await _tagGroupRepository.AddAsync(commonTagGroup, cancellationToken).ConfigureAwait(false);
            return await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false) == -1 ? new KSociety.Com.App.Dto.Res.Copy.Common.TagGroup(Guid.Empty) : new KSociety.Com.App.Dto.Res.Copy.Common.TagGroup(commonTagGroup.Id);
        }
    }
}
