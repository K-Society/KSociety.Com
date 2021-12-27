using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KSociety.Com.Domain.Repository.View.Common;
using KSociety.Com.Srv.Contract.Query.View.Common.List.GridView;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;

namespace KSociety.Com.Srv.Behavior.Query.View.Common.List.GridView;

public class QueryAsync : IQueryAsync
{
    private readonly ILogger<QueryAsync> _logger;
    private readonly IMapper _mapper;
    private readonly ITagGroupReady _tagGroupReadyRepository;

    public QueryAsync(
        ILoggerFactory loggerFactory,
        IMapper mapper,
        ITagGroupReady tagGroupReadyRepository
    )
    {
        _logger = loggerFactory.CreateLogger<QueryAsync>();
        _mapper = mapper;
        _tagGroupReadyRepository = tagGroupReadyRepository;
    }

    public async ValueTask<Srv.Dto.View.Common.List.GridView.TagGroupReady> TagGroupReadyAsync(CallContext context = default)
    {
        _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);

        var repository = await _tagGroupReadyRepository.GetAllTagGroupReadyAsync();
        var tagGroupItems = repository.ToList().Select(
            tagGroup => _mapper.Map<Srv.Dto.View.Common.TagGroupReady>(tagGroup)
        ).ToList();

        var output = new Srv.Dto.View.Common.List.GridView.TagGroupReady(tagGroupItems);

        return output;
    }
}