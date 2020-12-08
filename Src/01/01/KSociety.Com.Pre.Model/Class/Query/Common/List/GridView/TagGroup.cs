using System.Threading;
using System.Threading.Tasks;
using KSociety.Com.Pre.Model.Interface.Query.Common.List.GridView;
using KSociety.Com.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.Model.Class.Query.Common.List.GridView
{
    public class TagGroup : ITagGroup
    {
        private readonly Srv.Agent.Query.Common.List.GridView.TagGroup _tagGroup;
        public TagGroup(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        {
            _tagGroup = new Srv.Agent.Query.Common.List.GridView.TagGroup(agentConfiguration, loggerFactory);
        }

        public Srv.Dto.Common.List.GridView.TagGroup LoadAllRecords(CancellationToken cancellationToken = default)
        {
            return _tagGroup.LoadAllRecords();
        }

        public async ValueTask<Srv.Dto.Common.List.GridView.TagGroup> LoadAllRecordsAsync(CancellationToken cancellationToken = default)
        {
            return await _tagGroup.LoadAllRecordsAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
