using System;
using System.Threading;
using System.Threading.Tasks;
using KSociety.Base.Srv.Dto;
using KSociety.Com.Pre.Model.Interface.Query.Common.Model;
using KSociety.Com.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.Model.Class.Query.Common.Model
{
    public class Connection : IConnection
    {
        private readonly Srv.Agent.Query.Common.Model.Connection _connection;
        private readonly ILogger<Connection> _logger;

        public Connection(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Connection>();
            _connection = new Srv.Agent.Query.Common.Model.Connection(agentConfiguration, loggerFactory);
        }

        public Srv.Dto.Common.Model.Connection Find(KbIdObject idObject, CancellationToken cancellationToken = default)
        {
            try
            {
                return _connection.GetConnectionModelById(idObject);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " - " + ex.StackTrace);
            }

            return new Srv.Dto.Common.Model.Connection();
        }

        public async ValueTask<Srv.Dto.Common.Model.Connection> FindAsync(KbIdObject idObject, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _connection.GetConnectionModelByIdAsync(idObject);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " - " + ex.StackTrace);
            }

            return await new ValueTask<Srv.Dto.Common.Model.Connection>();
        }
    }
}
