using System;
using System.Threading;
using System.Threading.Tasks;
using KSociety.Com.Pre.Model.Interface.Query.Common.List.GridView;
using KSociety.Com.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.Model.Class.Query.Common.List.GridView
{
    public class Connection : IConnection
    {
        private readonly ILogger<Connection> _logger;
        private readonly Srv.Agent.Query.Common.List.GridView.Connection _connection;

        public Connection(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Connection>();
            _connection = new Srv.Agent.Query.Common.List.GridView.Connection(agentConfiguration, loggerFactory);
        }

        public Srv.Dto.Common.List.GridView.Connection LoadAllRecords(CancellationToken cancellationToken = default)
        {
            return _connection.LoadAllRecords();
        }

        public async ValueTask<Srv.Dto.Common.List.GridView.Connection> LoadAllRecordsAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _connection.LoadAllRecordsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
                return await new ValueTask<Srv.Dto.Common.List.GridView.Connection>();
            }
        }
    }
}
