using System.Threading;
using System.Threading.Tasks;
using KSociety.Com.Pre.Model.Interface.Query.Logix.List.GridView;
using KSociety.Com.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.Model.Class.Query.Logix.List.GridView
{
    public class LogixTag : ILogixTag
    {
        private readonly Srv.Agent.Query.Logix.List.GridView.LogixTag _logixTag;

        public LogixTag(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        {
            _logixTag = new Srv.Agent.Query.Logix.List.GridView.LogixTag(agentConfiguration, loggerFactory);
        }

        public Srv.Dto.Logix.List.GridView.LogixTag LoadAllRecords(CancellationToken cancellationToken = default)
        {
            return _logixTag.LoadAllRecords();
        }

        public async ValueTask<Srv.Dto.Logix.List.GridView.LogixTag> LoadAllRecordsAsync(CancellationToken cancellationToken = default)
        {
            return await _logixTag.LoadAllRecordsAsync();
        }
    }
}
