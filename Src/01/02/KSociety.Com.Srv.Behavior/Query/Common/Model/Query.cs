using System;
using KSociety.Base.Srv.Dto;
using KSociety.Com.Srv.Contract.Query.Common.Model;
using Microsoft.Extensions.Logging;
using KSociety.Com.Srv.Dto.Common;
using ProtoBuf.Grpc;

namespace KSociety.Com.Srv.Behavior.Query.Common.Model;

public class Query : IQuery
{
    private readonly ILogger<Query> _logger;
    private readonly Contract.Query.Common.IQuery _query;
    private readonly Contract.Query.Common.ListKeyValue.IQuery _queryKeyValue;

    public Query(
        ILogger<Query> logger,
        Contract.Query.Common.IQuery query,
        Contract.Query.Common.ListKeyValue.IQuery queryKeyValue
    )
    {
        _logger = logger;
        _query = query;
        _queryKeyValue = queryKeyValue;
    }

    public Srv.Dto.Common.Model.Tag GetTagModelById(IdObject idObject, CallContext context = default)
    {
        _logger.LogTrace("Query Behavior: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);
        Srv.Dto.Common.Tag tag;
        if (idObject.Id.Equals(Guid.Empty))
        {
            tag = new Tag();
        }
        else
        {
            tag = _query.GetTagById(idObject, context);
        }

        var automationTypeId = _queryKeyValue.AutomationTypeId(context);
        var analogDigitalSignal = _queryKeyValue.AnalogDigitalSignal(context);
        var tagGroupId = _queryKeyValue.TagGroupId(context);
        var inputOutput = _queryKeyValue.InputOutput(context);
        var connectionId = _queryKeyValue.ConnectionId(context);

        return new Srv.Dto.Common.Model.Tag(tag, automationTypeId.List, analogDigitalSignal.List, tagGroupId.List, inputOutput.List, connectionId.List);
    }

    public Srv.Dto.Common.Model.Connection GetConnectionModelById(IdObject idObject, CallContext context = default)
    {
        _logger.LogTrace("Query Behavior: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);
        Srv.Dto.Common.Connection connection;

        if (idObject.Id.Equals(Guid.Empty))
        {
            connection = new Connection();
        }
        else
        {
            connection = _query.GetConnectionById(idObject, context);
        }

        var automationTypeId = _queryKeyValue.AutomationTypeId();
        return new Srv.Dto.Common.Model.Connection(connection, automationTypeId.List);
    }
}