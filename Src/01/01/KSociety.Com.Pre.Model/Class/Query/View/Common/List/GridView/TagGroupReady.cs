using System.Threading;
using System.Threading.Tasks;
using KSociety.Com.Pre.Model.Interface.Query.View.Common.List.GridView;
using KSociety.Com.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.Model.Class.Query.View.Common.List.GridView
{
    public class TagGroupReady : ITagGroupReady
    {
        private readonly Srv.Agent.Query.View.Common.List.GridView.TagGroupReady _agGroupReady;

        public TagGroupReady(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        {
            _agGroupReady = new Srv.Agent.Query.View.Common.List.GridView.TagGroupReady(agentConfiguration, loggerFactory);
        }

        public Srv.Dto.View.Common.List.GridView.TagGroupReady LoadAllRecords(CancellationToken cancellationToken = default)
        {
            return _agGroupReady.LoadAllRecords();
        }

        public async ValueTask<Srv.Dto.View.Common.List.GridView.TagGroupReady> LoadAllRecordsAsync(CancellationToken cancellationToken = default)
        {
            return await _agGroupReady.LoadAllRecordsAsync();
        }
    }
}
