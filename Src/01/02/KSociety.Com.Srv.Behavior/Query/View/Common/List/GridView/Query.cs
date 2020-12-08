using AutoMapper;
using KSociety.Com.Domain.Repository.View.Common;
using KSociety.Com.Srv.Contract.Query.View.Common.List.GridView;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;
using System.Linq;

namespace KSociety.Com.Srv.Behavior.Query.View.Common.List.GridView
{
    public class Query : IQuery
    {
        private readonly ILogger<Query> _logger;
        private readonly IMapper _mapper;
        private readonly ITagGroupReady _tagGroupReadyRepository;

        public Query(
            ILogger<Query> logger,
            IMapper mapper,
            ITagGroupReady tagGroupReadyRepository
        )
        {
            _logger = logger;
            _mapper = mapper;
            _tagGroupReadyRepository = tagGroupReadyRepository;
        }

        public Dto.View.Common.List.GridView.TagGroupReady TagGroupReady(CallContext context = default)
        {
            _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);

            var repository = _tagGroupReadyRepository.GetAllTagGroupReady();
            var tagGroupItems = repository.ToList().Select(
                tagGroup => _mapper.Map<Srv.Dto.View.Common.TagGroupReady>(tagGroup)
            ).ToList();

            var output = new Srv.Dto.View.Common.List.GridView.TagGroupReady(tagGroupItems);

            return output;
        }
    }
}
