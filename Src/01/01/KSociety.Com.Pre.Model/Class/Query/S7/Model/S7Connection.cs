using System;
using System.Threading;
using System.Threading.Tasks;
using KSociety.Base.Srv.Dto;
using KSociety.Com.Pre.Model.Interface.Query.S7.Model;
using KSociety.Com.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.Model.Class.Query.S7.Model
{
    public class S7Connection : IS7Connection
    {
        private readonly Srv.Agent.Query.S7.Model.S7Connection _s7Connection;
        private readonly ILogger<S7Connection> _logger;

        public S7Connection(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<S7Connection>();
            _s7Connection = new Srv.Agent.Query.S7.Model.S7Connection(agentConfiguration, loggerFactory);
        }

        public Srv.Dto.S7.Model.S7Connection Find(IdObject idObject, CancellationToken cancellationToken = default)
        {
            try
            {
                return _s7Connection.GetS7ConnectionModelById(idObject);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " - " + ex.StackTrace);
            }

            return new Srv.Dto.S7.Model.S7Connection();
        }

        public async ValueTask<Srv.Dto.S7.Model.S7Connection> FindAsync(IdObject idObject, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _s7Connection.GetS7ConnectionModelByIdAsync(idObject);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " - " + ex.StackTrace);
            }

            return await new ValueTask<Srv.Dto.S7.Model.S7Connection>();
        }
    }
}
