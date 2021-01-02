using System;
using System.Threading;
using System.Threading.Tasks;
using KSociety.Base.Srv.Dto;
using KSociety.Com.Pre.Model.Interface.Query.Common.Model;
using KSociety.Com.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.Model.Class.Query.Common.Model
{
    public class Tag : ITag
    {
        private readonly Srv.Agent.Query.Common.Model.Tag _tag;
        private readonly ILogger<Tag> _logger;

        public Tag(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Tag>();
            _tag = new Srv.Agent.Query.Common.Model.Tag(agentConfiguration, loggerFactory);
        }

        public Srv.Dto.Common.Model.Tag Find(IdObject idObject, CancellationToken cancellationToken = default)
        {
            try
            {
                return _tag.GetTagModelById(idObject);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " - " + ex.StackTrace);
            }

            return new Srv.Dto.Common.Model.Tag();
        }

        public async ValueTask<Srv.Dto.Common.Model.Tag> FindAsync(IdObject idObject, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _tag.GetTagModelByIdAsync(idObject);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " - " + ex.StackTrace);
            }

            return await new ValueTask<Srv.Dto.Common.Model.Tag>();
        }
    }
}
