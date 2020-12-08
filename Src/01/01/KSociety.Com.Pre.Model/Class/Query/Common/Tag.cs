using System;
using System.Threading;
using System.Threading.Tasks;
using KSociety.Base.Srv.Dto;
using KSociety.Com.Pre.Model.Interface.Query.Common;
using KSociety.Com.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.Model.Class.Query.Common
{
    public class Tag : ITag
    {
        private readonly Srv.Agent.Query.Common.Tag _tag;
        private readonly ILogger<Tag> _logger;

        public Tag(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Tag>();
            _tag = new Srv.Agent.Query.Common.Tag(agentConfiguration, loggerFactory);
        }

        public Srv.Dto.Common.Tag Find(KbIdObject idObject, CancellationToken cancellationToken = default)
        {
            //_logger.LogTrace("Find: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                return _tag.GetTagById(idObject);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " - " + ex.StackTrace);
            }

            return new Srv.Dto.Common.Tag();
        }

        public async ValueTask<Srv.Dto.Common.Tag> FindAsync(KbIdObject idObject, CancellationToken cancellationToken = default)
        {
            //_logger.LogTrace("FindAsync: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + idObject.Id);
            try
            {
                return await _tag.GetTagByIdAsync(idObject);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " - " + ex.StackTrace);
            }

            return await new ValueTask<Srv.Dto.Common.Tag>();
        }
    }
}
