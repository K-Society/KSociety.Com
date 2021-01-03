using System;
using System.Threading.Tasks;
using KSociety.Base.Srv.Dto;
using KSociety.Com.Srv.Contract.Query.S7.Model;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;
using KSociety.Com.Srv.Dto.S7;

namespace KSociety.Com.Srv.Behavior.Query.S7.Model
{
    public class QueryAsync : IQueryAsync
    {
        private readonly ILogger<QueryAsync> _logger;
        private readonly Contract.Query.S7.IQueryAsync _query;
        private readonly Contract.Query.S7.ListKeyValue.IQueryAsync _queryS7KeyValue;
        private readonly Contract.Query.Common.ListKeyValue.IQueryAsync _queryKeyValue;

        public QueryAsync(
            ILoggerFactory loggerFactory,
            Contract.Query.S7.IQueryAsync query,
            Contract.Query.S7.ListKeyValue.IQueryAsync queryS7KeyValue,
            Contract.Query.Common.ListKeyValue.IQueryAsync queryKeyValue
        )
        {
            _logger = loggerFactory.CreateLogger<QueryAsync>();
            _query = query;
            _queryS7KeyValue = queryS7KeyValue;
            _queryKeyValue = queryKeyValue;
        }

        public async ValueTask<Srv.Dto.S7.Model.S7Tag> GetS7TagModelByIdAsync(IdObject idObject, CallContext context = default)
        {
            _logger.LogTrace("Query Behavior: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);
            Srv.Dto.S7.S7Tag tag;
            if (idObject.Id.Equals(Guid.Empty))
            {
                tag = new S7Tag();
            }
            else
            {
                tag = await _query.GetS7TagByIdAsync(idObject, context);
            }

            var automationTypeId = await _queryKeyValue.AutomationTypeIdAsync(context);
            var analogDigitalSignal = await _queryKeyValue.AnalogDigitalSignalAsync(context);
            var tagGroupId = await _queryKeyValue.TagGroupIdAsync(context);
            var inputOutput = await _queryKeyValue.InputOutputAsync(context);
            var connectionId = await _queryKeyValue.ConnectionIdAsync(context);
            var areaId = await _queryS7KeyValue.AreaIdAsync(context);
            var wordLenId = await _queryS7KeyValue.WordLenIdAsync(context);
            var bitOfByte = await _queryKeyValue.BitOfByteAsync(context);

            return new Srv.Dto.S7.Model.S7Tag(
                tag, automationTypeId.List, analogDigitalSignal.List,
                tagGroupId.List, inputOutput.List, connectionId.List,
                areaId.List, wordLenId.List, bitOfByte.List);
        }

        public async ValueTask<Srv.Dto.S7.Model.S7Connection> GetS7ConnectionModelByIdAsync(IdObject idObject, CallContext context = default)
        {
            _logger.LogTrace("Query Behavior: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);
            Srv.Dto.S7.S7Connection connection;

            if (idObject.Id.Equals(Guid.Empty))
            {
                connection = new S7Connection();
            }
            else
            {
                connection = await _query.GetS7ConnectionByIdAsync(idObject, context);
            }

            var automationTypeId = await _queryKeyValue.AutomationTypeIdAsync(context);
            var connectionTypeId = await _queryS7KeyValue.ConnectionTypeIdAsync(context);
            var cpuTypeId = await _queryS7KeyValue.CpuTypeIdAsync(context);

            return new Srv.Dto.S7.Model.S7Connection(connection, automationTypeId.List, connectionTypeId.List, cpuTypeId.List);
        }
    }
}
