using System;
using KSociety.Base.Srv.Dto;
using KSociety.Com.Srv.Contract.Query.S7.Model;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;
using KSociety.Com.Srv.Dto.S7;

namespace KSociety.Com.Srv.Behavior.Query.S7.Model;

public class Query : IQuery
{
    private readonly ILogger<Query> _logger;
    private readonly Contract.Query.S7.IQuery _query;
    private readonly Contract.Query.S7.ListKeyValue.IQuery _queryS7KeyValue;
    private readonly Contract.Query.Common.ListKeyValue.IQuery _queryKeyValue;

    public Query(
        ILogger<Query> logger,
        Contract.Query.S7.IQuery query,
        Contract.Query.S7.ListKeyValue.IQuery queryS7KeyValue,
        Contract.Query.Common.ListKeyValue.IQuery queryKeyValue
    )
    {
        _logger = logger;
        _query = query;
        _queryS7KeyValue = queryS7KeyValue;
        _queryKeyValue = queryKeyValue;
    }

    public Srv.Dto.S7.Model.S7Tag GetS7TagModelById(IdObject idObject, CallContext context = default)
    {
        _logger.LogTrace("Query Behavior: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);
        Srv.Dto.S7.S7Tag tag;
        if (idObject.Id.Equals(Guid.Empty))
        {
            tag = new S7Tag();
        }
        else
        {
            tag = _query.GetS7TagById(idObject, context);
        }

        var automationTypeId = _queryKeyValue.AutomationTypeId(context);
        var analogDigitalSignal = _queryKeyValue.AnalogDigitalSignal(context);
        var tagGroupId = _queryKeyValue.TagGroupId(context);
        var inputOutput = _queryKeyValue.InputOutput(context);
        var connectionId = _queryKeyValue.ConnectionId(context);
        var areaId = _queryS7KeyValue.AreaId(context);
        var wordLenId = _queryS7KeyValue.WordLenId(context);
        var bitOfByte = _queryKeyValue.BitOfByte(context);

        return new Srv.Dto.S7.Model.S7Tag(
            tag, automationTypeId.List, analogDigitalSignal.List, 
            tagGroupId.List, inputOutput.List, connectionId.List,
            areaId.List, wordLenId.List, bitOfByte.List);
    }

    public Srv.Dto.S7.Model.S7Connection GetS7ConnectionModelById(IdObject idObject, CallContext context = default)
    {
        _logger.LogTrace("Query Behavior: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);
        Srv.Dto.S7.S7Connection connection;

        if (idObject.Id.Equals(Guid.Empty))
        {
            connection = new S7Connection();
        }
        else
        {
            connection = _query.GetS7ConnectionById(idObject, context);
        }

        var automationTypeId = _queryKeyValue.AutomationTypeId(context);
        var connectionTypeId = _queryS7KeyValue.ConnectionTypeId(context);
        var cpuTypeId = _queryS7KeyValue.CpuTypeId(context);

        return new Srv.Dto.S7.Model.S7Connection(connection, automationTypeId.List, connectionTypeId.List, cpuTypeId.List);
    }
}