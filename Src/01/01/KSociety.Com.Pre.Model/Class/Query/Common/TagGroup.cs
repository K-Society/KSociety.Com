using System;
using System.Threading;
using System.Threading.Tasks;
using KSociety.Base.Srv.Dto;
using KSociety.Com.Pre.Model.Interface.Query.Common;
using KSociety.Com.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.Model.Class.Query.Common
{
    public class TagGroup : ITagGroup
    {
        private readonly Srv.Agent.Query.Common.TagGroup _tagGroup;
        private readonly ILogger<TagGroup> _logger;

        public TagGroup(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<TagGroup>();
            _tagGroup = new Srv.Agent.Query.Common.TagGroup(agentConfiguration, loggerFactory);
        }

        public Srv.Dto.Common.TagGroup Find(KbIdObject idObject, CancellationToken cancellationToken = default)
        {
            //_logger.LogTrace("Find: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                return _tagGroup.GetTagGroupById(idObject);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " - " + ex.StackTrace);
            }

            return new Srv.Dto.Common.TagGroup();
        }

        public async ValueTask<Srv.Dto.Common.TagGroup> FindAsync(KbIdObject idObject, CancellationToken cancellationToken = default)
        {
            //_logger.LogTrace("FindAsync: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + idObject.Id);
            try
            {
                return await _tagGroup.GetTagGroupByIdAsync(idObject);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " - " + ex.StackTrace);
            }

            return await new ValueTask<Srv.Dto.Common.TagGroup>();
        }
    }
}
