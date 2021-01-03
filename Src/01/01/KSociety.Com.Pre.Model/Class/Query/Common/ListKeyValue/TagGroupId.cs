using System;
using System.Threading;
using System.Threading.Tasks;
using KSociety.Base.Srv.Dto;
using KSociety.Com.Pre.Model.Interface.Query.Common.ListKeyValue;
using KSociety.Com.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.Model.Class.Query.Common.ListKeyValue
{
    public class TagGroupId : ITagGroupId
    {
        private readonly Srv.Agent.Query.Common.ListKeyValue.TagGroup _tagGroup;

        public TagGroupId(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        {
            _tagGroup = new Srv.Agent.Query.Common.ListKeyValue.TagGroup(agentConfiguration, loggerFactory);
        }

        public ListKeyValuePair<Guid, string> LoadData(CancellationToken cancellationToken = default)
        {
            return _tagGroup.LoadData();
        }

        public async ValueTask<ListKeyValuePair<Guid, string>> LoadDataAsync(CancellationToken cancellationToken = default)
        {
            return await _tagGroup.LoadDataAsync();
        }
    }
}
