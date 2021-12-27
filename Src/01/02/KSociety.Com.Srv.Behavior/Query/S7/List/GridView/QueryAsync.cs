using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KSociety.Com.Srv.Contract.Query.S7.List.GridView;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;

namespace KSociety.Com.Srv.Behavior.Query.S7.List.GridView;

public class QueryAsync : IQueryAsync
{
    private readonly ILogger<QueryAsync> _logger;
    private readonly IMapper _mapper;
    private readonly Domain.Repository.S7.IConnection _s7ConnectionRepository;
    private readonly Domain.Repository.S7.ITag _s7TagRepository;
    private readonly Contract.Query.Common.ListKeyValue.IQueryAsync _queryListKeyValue;
    private readonly Contract.Query.S7.ListKeyValue.IQueryAsync _queryS7ListKeyValue;

    public QueryAsync(
        ILoggerFactory loggerFactory,
        IMapper mapper,
        Domain.Repository.S7.IConnection s7ConnectionRepository,
        Domain.Repository.S7.ITag s7TagRepository,
        Contract.Query.Common.ListKeyValue.IQueryAsync queryListKeyValue,
        Contract.Query.S7.ListKeyValue.IQueryAsync queryS7ListKeyValue
    )
    {
        _logger = loggerFactory.CreateLogger<QueryAsync>();
        _mapper = mapper;
        _s7ConnectionRepository = s7ConnectionRepository;
        _s7TagRepository = s7TagRepository;
        _queryListKeyValue = queryListKeyValue;
        _queryS7ListKeyValue = queryS7ListKeyValue;
    }

    public async ValueTask<Dto.S7.List.GridView.S7Connection> S7ConnectionAsync(CallContext context = default)
    {
        _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);

        var repository = await _s7ConnectionRepository.GetAllS7ConnectionAsync();
        var connectionItems = repository.ToList().Select(
            connection => _mapper.Map<Srv.Dto.S7.S7Connection>(connection)
        ).ToList();

        var connectionTypeDns = await _queryS7ListKeyValue.ConnectionTypeIdAsync(context);

        var cpuTypeDns = await _queryS7ListKeyValue.CpuTypeIdAsync(context);

        var output = new Srv.Dto.S7.List.GridView.S7Connection(connectionItems, connectionTypeDns.List, cpuTypeDns.List);

        return output;
    }

    public async ValueTask<Srv.Dto.S7.List.GridView.S7Tag> S7TagAsync(CallContext context = default)
    {
        _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);

        var repository = await _s7TagRepository.GetAllS7TagAsync();

        var tagItems = repository.ToList().Select(
            tag => _mapper.Map<Srv.Dto.S7.S7Tag>(tag)
        ).ToList();

        var commonAnalogDigitalDns = await _queryListKeyValue.AnalogDigitalSignalAsync();

        var commonTagGroupDns = await _queryListKeyValue.TagGroupIdAsync(context);

        var commonInOutDns = await _queryListKeyValue.InputOutputAsync(context);

        var s7ConnectionDns = await _queryS7ListKeyValue.S7ConnectionIdAsync(context);

        var areaDns = await _queryS7ListKeyValue.AreaIdAsync(context);

        var wordLenDns = await _queryS7ListKeyValue.WordLenIdAsync(context);

        var bitOfByteDns = await _queryListKeyValue.BitOfByteAsync(context);

        var output = new Srv.Dto.S7.List.GridView.S7Tag(
            tagItems,
            commonAnalogDigitalDns.List, commonTagGroupDns.List,
            commonInOutDns.List, s7ConnectionDns.List, areaDns.List,
            wordLenDns.List, bitOfByteDns.List);

        return output;
    }
}