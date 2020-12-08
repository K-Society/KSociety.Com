using System;
using System.Threading;
using System.Threading.Tasks;
using KSociety.Base.Srv.Dto;
using KSociety.Com.Pre.Model.Interface.Query.S7;
using KSociety.Com.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.Model.Class.Query.S7
{
    public class S7Connection : IS7Connection
    {
        private readonly Srv.Agent.Query.S7.S7Connection _s7Connection;
        private readonly ILogger<S7Connection> _logger;

        public S7Connection(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<S7Connection>();
            _s7Connection = new Srv.Agent.Query.S7.S7Connection(agentConfiguration, loggerFactory);
        }

        public Srv.Dto.S7.S7Connection Find(KbIdObject idObject, CancellationToken cancellationToken = default)
        {
            //_logger.LogTrace("Find: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                return _s7Connection.GetS7ConnectionById(idObject);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " - " + ex.StackTrace);
            }

            return new Srv.Dto.S7.S7Connection();
        }

        public async ValueTask<Srv.Dto.S7.S7Connection> FindAsync(KbIdObject idObject, CancellationToken cancellationToken = default)
        {
            //_logger.LogTrace("FindAsync: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + idObject.Id);
            try
            {
                return await _s7Connection.GetS7ConnectionByIdAsync(idObject);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " - " + ex.StackTrace);
            }

            return await new ValueTask<Srv.Dto.S7.S7Connection>();
        }
    }
}
