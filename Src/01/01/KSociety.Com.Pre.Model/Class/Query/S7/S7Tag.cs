using System;
using System.Threading;
using System.Threading.Tasks;
using KSociety.Base.Srv.Dto;
using KSociety.Com.Pre.Model.Interface.Query.S7;
using KSociety.Com.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.Model.Class.Query.S7
{
    public class S7Tag : IS7Tag
    {
        private readonly Srv.Agent.Query.S7.S7Tag _tag;
        private readonly ILogger<S7Tag> _logger;

        public S7Tag(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<S7Tag>();
            _tag = new Srv.Agent.Query.S7.S7Tag(agentConfiguration, loggerFactory);
        }

        public Srv.Dto.S7.S7Tag Find(IdObject idObject, CancellationToken cancellationToken = default)
        {
            //_logger.LogTrace("Find: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                return _tag.GetS7TagById(idObject);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " - " + ex.StackTrace);
            }

            return new Srv.Dto.S7.S7Tag();
        }

        public async ValueTask<Srv.Dto.S7.S7Tag> FindAsync(IdObject idObject, CancellationToken cancellationToken = default)
        {
            //_logger.LogTrace("FindAsync: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + idObject.Id);
            try
            {
                return await _tag.GetS7TagByIdAsync(idObject);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " - " + ex.StackTrace);
            }

            return await new ValueTask<Srv.Dto.S7.S7Tag>();
        }
    }
}
