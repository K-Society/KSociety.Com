using AutoMapper;
using KSociety.Com.Srv.Contract.Query.S7.List.GridView;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;
using System.Linq;

namespace KSociety.Com.Srv.Behavior.Query.S7.List.GridView;

public class Query : IQuery
{
    private readonly ILogger<Query> _logger;
    private readonly IMapper _mapper;
    private readonly Domain.Repository.S7.IConnection _s7ConnectionRepository;
    private readonly Domain.Repository.S7.ITag _s7TagRepository;
    private readonly Contract.Query.Common.ListKeyValue.IQuery _queryListKeyValue;
    private readonly Contract.Query.S7.ListKeyValue.IQuery _queryS7ListKeyValue;

    public Query(
        ILogger<Query> logger,
        IMapper mapper,
        Domain.Repository.S7.IConnection s7ConnectionRepository,
        Domain.Repository.S7.ITag s7TagRepository,
        Contract.Query.Common.ListKeyValue.IQuery queryListKeyValue,
        Contract.Query.S7.ListKeyValue.IQuery queryS7ListKeyValue
    )
    {
        _logger = logger;
        _mapper = mapper;
        _s7ConnectionRepository = s7ConnectionRepository;
        _s7TagRepository = s7TagRepository;
        _queryListKeyValue = queryListKeyValue;
        _queryS7ListKeyValue = queryS7ListKeyValue;
    }

    public Dto.S7.List.GridView.S7Connection S7Connection(CallContext context = default)
    {
        _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);

        var repository = _s7ConnectionRepository.GetAllS7Connection();
        var connectionItems = repository.ToList().Select(
            connection => _mapper.Map<Srv.Dto.S7.S7Connection>(connection)
        ).ToList();

        var connectionTypeDns = _queryS7ListKeyValue.ConnectionTypeId(context);

        var cpuTypeDns = _queryS7ListKeyValue.CpuTypeId(context);

        var output = new Srv.Dto.S7.List.GridView.S7Connection(connectionItems, connectionTypeDns.List, cpuTypeDns.List);

        return output;
    }

    public Srv.Dto.S7.List.GridView.S7Tag S7Tag(CallContext context = default)
    {
        _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);

        var repository = _s7TagRepository.GetAllS7Tag();

        var tagItems = repository.ToList().Select(
            tag => _mapper.Map<Srv.Dto.S7.S7Tag>(tag)
        ).ToList();

        var commonAnalogDigitalDns = _queryListKeyValue.AnalogDigitalSignal(context);

        var commonTagGroupDns = _queryListKeyValue.TagGroupId(context);

        var commonInOutDns = _queryListKeyValue.InputOutput(context);

        var s7ConnectionDns = _queryS7ListKeyValue.S7ConnectionId(context);

        var areaDns = _queryS7ListKeyValue.AreaId(context);

        var wordLenDns = _queryS7ListKeyValue.WordLenId(context);

        var bitOfByteDns = _queryListKeyValue.BitOfByte(context);

        var output = new Srv.Dto.S7.List.GridView.S7Tag(
            tagItems,
            commonAnalogDigitalDns.List, commonTagGroupDns.List,
            commonInOutDns.List, s7ConnectionDns.List, areaDns.List,
            wordLenDns.List, bitOfByteDns.List);

        return output;
    }
}