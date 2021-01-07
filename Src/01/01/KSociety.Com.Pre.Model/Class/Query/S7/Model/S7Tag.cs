using System;
using System.Threading;
using System.Threading.Tasks;
using KSociety.Base.Srv.Dto;
using KSociety.Com.Pre.Model.Interface.Query.S7.Model;
using KSociety.Com.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.Model.Class.Query.S7.Model
{
    public class S7Tag : IS7Tag
    {
        private readonly Srv.Agent.Query.S7.Model.S7Tag _s7Tag;
        private readonly ILogger<S7Tag> _logger;

        public S7Tag(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<S7Tag>();
            _s7Tag = new Srv.Agent.Query.S7.Model.S7Tag(agentConfiguration, loggerFactory);
        }

        public Srv.Dto.S7.Model.S7Tag Find(IdObject idObject, CancellationToken cancellationToken = default)
        {
            try
            {
                return _s7Tag.GetS7TagModelById(idObject);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " - " + ex.StackTrace);
            }

            return new Srv.Dto.S7.Model.S7Tag();
        }

        public async ValueTask<Srv.Dto.S7.Model.S7Tag> FindAsync(IdObject idObject, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _s7Tag.GetS7TagModelByIdAsync(idObject);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " - " + ex.StackTrace);
            }

            return await new ValueTask<Srv.Dto.S7.Model.S7Tag>();
        }
    }
}
