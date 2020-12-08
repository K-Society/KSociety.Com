using System;
using System.Threading;
using System.Threading.Tasks;
using KSociety.Base.Srv.Dto;
using KSociety.Com.Pre.Model.Interface.Query.Common;
using KSociety.Com.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.Model.Class.Query.Common
{
    public class Connection : IConnection
    {
        private readonly Srv.Agent.Query.Common.Connection _connection;
        private readonly ILogger<Connection> _logger;

        public Connection(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Connection>();
            _connection = new Srv.Agent.Query.Common.Connection(agentConfiguration, loggerFactory);
        }

        public Srv.Dto.Common.Connection Find(KbIdObject idObject, CancellationToken cancellationToken = default)
        {
            //_logger.LogTrace("Find: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                return _connection.GetConnectionById(idObject);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " - " + ex.StackTrace);
            }

            return new Srv.Dto.Common.Connection();
        }

        public async ValueTask<Srv.Dto.Common.Connection> FindAsync(KbIdObject idObject, CancellationToken cancellationToken = default)
        {
            //_logger.LogTrace("FindAsync: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + idObject.Id);
            try
            {
                return await _connection.GetConnectionByIdAsync(idObject);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " - " + ex.StackTrace);
            }

            return await new ValueTask<Srv.Dto.Common.Connection>();
        }
    }
}
