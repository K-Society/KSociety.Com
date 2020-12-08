using System.Threading;
using System.Threading.Tasks;
using KSociety.Com.Pre.Model.Interface.Query.S7.List.GridView;
using KSociety.Com.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.Model.Class.Query.S7.List.GridView
{
    public class S7Tag : IS7Tag
    {
        private readonly Srv.Agent.Query.S7.List.GridView.S7Tag _s7Tag;

        public S7Tag(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        {
            _s7Tag = new Srv.Agent.Query.S7.List.GridView.S7Tag(agentConfiguration, loggerFactory);
        }

        public Srv.Dto.S7.List.GridView.S7Tag LoadAllRecords(CancellationToken cancellationToken = default)
        {
            return _s7Tag.LoadAllRecords();
        }

        public async ValueTask<Srv.Dto.S7.List.GridView.S7Tag> LoadAllRecordsAsync(CancellationToken cancellationToken = default)
        {
            return await _s7Tag.LoadAllRecordsAsync();
        }
    }
}
