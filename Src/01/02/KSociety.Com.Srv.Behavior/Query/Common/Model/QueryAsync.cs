using System;
using System.Threading.Tasks;
using KSociety.Base.Srv.Dto;
using KSociety.Com.Srv.Contract.Query.Common.Model;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;
using KSociety.Com.Srv.Dto.Common;

namespace KSociety.Com.Srv.Behavior.Query.Common.Model
{
    public class QueryAsync : IQueryAsync
    {
        private readonly ILogger<QueryAsync> _logger;
        private readonly Contract.Query.Common.IQueryAsync _query;
        private readonly Contract.Query.Common.ListKeyValue.IQueryAsync _queryKeyValue;

        public QueryAsync(
            ILoggerFactory loggerFactory,
            Contract.Query.Common.IQueryAsync query,
            Contract.Query.Common.ListKeyValue.IQueryAsync queryKeyValue
        )
        {
            _logger = loggerFactory.CreateLogger<QueryAsync>();
            _query = query;
            _queryKeyValue = queryKeyValue;
        }

        public async ValueTask<Srv.Dto.Common.Model.Tag> GetTagModelByIdAsync(IdObject idObject, CallContext context = default)
        {
            _logger.LogTrace("Query Behavior: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);
            Srv.Dto.Common.Tag tag;
            if (idObject.Id.Equals(Guid.Empty))
            {
                tag = new Tag();
            }
            else
            {
                tag = await _query.GetTagByIdAsync(idObject, context);
            }

            var automationTypeId = await _queryKeyValue.AutomationTypeIdAsync(context);
            var analogDigitalSignal = await _queryKeyValue.AnalogDigitalSignalAsync(context);
            var tagGroupId = await _queryKeyValue.TagGroupIdAsync(context);
            var inputOutput = await _queryKeyValue.InputOutputAsync(context);
            var connectionId = await _queryKeyValue.ConnectionIdAsync(context);

            return new Srv.Dto.Common.Model.Tag(tag, automationTypeId.List, analogDigitalSignal.List, tagGroupId.List, inputOutput.List, connectionId.List);
        }

        public async ValueTask<Srv.Dto.Common.Model.Connection> GetConnectionModelByIdAsync(IdObject idObject, CallContext context = default)
        {
            _logger.LogTrace("Query Behavior: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);
            Srv.Dto.Common.Connection connection;

            if (idObject.Id.Equals(Guid.Empty))
            {
                connection = new Connection();
            }
            else
            {
                connection = await _query.GetConnectionByIdAsync(idObject, context);
            }

            var automationTypeId = await _queryKeyValue.AutomationTypeIdAsync(context);
            return new Srv.Dto.Common.Model.Connection(connection, automationTypeId.List);
        }
    }
}
