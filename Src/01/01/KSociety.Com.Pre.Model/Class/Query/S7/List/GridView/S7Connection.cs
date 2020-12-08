using System.Threading;
using System.Threading.Tasks;
using KSociety.Com.Pre.Model.Interface.Query.S7.List.GridView;
using KSociety.Com.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.Model.Class.Query.S7.List.GridView
{
    public class S7Connection : IS7Connection
    {
        private readonly Srv.Agent.Query.S7.List.GridView.S7Connection _s7Connection;

        public S7Connection(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        {
            _s7Connection = new Srv.Agent.Query.S7.List.GridView.S7Connection(agentConfiguration, loggerFactory);
        }

        public Srv.Dto.S7.List.GridView.S7Connection LoadAllRecords(CancellationToken cancellationToken = default)
        {
            return _s7Connection.LoadAllRecords();
        }

        public async ValueTask<Srv.Dto.S7.List.GridView.S7Connection> LoadAllRecordsAsync(CancellationToken cancellationToken = default)
        {
            return await _s7Connection.LoadAllRecordsAsync();
        }
    }
}
