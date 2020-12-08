using System.Threading;
using System.Threading.Tasks;
using KSociety.Com.Pre.Model.Interface.Query.Logix.List.GridView;
using KSociety.Com.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.Model.Class.Query.Logix.List.GridView
{
    public class LogixConnection : ILogixConnection
    {
        private readonly Srv.Agent.Query.Logix.List.GridView.LogixConnection _logixConnection;

        public LogixConnection(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        {
            _logixConnection = new Srv.Agent.Query.Logix.List.GridView.LogixConnection(agentConfiguration, loggerFactory);
        }

        public Srv.Dto.Logix.List.GridView.LogixConnection LoadAllRecords(CancellationToken cancellationToken = default)
        {
            return _logixConnection.LoadAllRecords();
        }

        public async ValueTask<Srv.Dto.Logix.List.GridView.LogixConnection> LoadAllRecordsAsync(CancellationToken cancellationToken = default)
        {
            return await _logixConnection.LoadAllRecordsAsync();
        }
    }
}
