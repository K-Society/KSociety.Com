using System;
using System.Threading;
using System.Threading.Tasks;
using KSociety.Base.Srv.Dto;
using KSociety.Com.Pre.Model.Interface.Query.Common.ListKeyValue;
using KSociety.Com.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.Model.Class.Query.Common.ListKeyValue
{
    public class ConnectionId : IConnectionId
    {
        private readonly Srv.Agent.Query.Common.ListKeyValue.ConnectionId _connection;

        public ConnectionId(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        {
            _connection = new Srv.Agent.Query.Common.ListKeyValue.ConnectionId(agentConfiguration, loggerFactory);
        }

        public KbListKeyValuePair<Guid, string> LoadData(CancellationToken cancellationToken = default)
        {
            return _connection.LoadData();
        }

        public async ValueTask<KbListKeyValuePair<Guid, string>> LoadDataAsync(CancellationToken cancellationToken = default)
        {
            return await _connection.LoadDataAsync();
        }
    }
}
