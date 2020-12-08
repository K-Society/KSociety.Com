using System.Threading;
using System.Threading.Tasks;
using KSociety.Base.Srv.Dto;
using KSociety.Com.Pre.Model.Interface.Query.Common.ListKeyValue;
using KSociety.Com.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.Model.Class.Query.Common.ListKeyValue
{
    public class AutomationTypeId : IAutomationTypeId
    {
        private readonly Srv.Agent.Query.Common.ListKeyValue.AutomationTypeId _automationType;

        public AutomationTypeId(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        {
            _automationType = new Srv.Agent.Query.Common.ListKeyValue.AutomationTypeId(agentConfiguration, loggerFactory);
        }

        public KbListKeyValuePair<int, string> LoadData(CancellationToken cancellationToken = default)
        {
            return _automationType.LoadData();
        }

        public async ValueTask<KbListKeyValuePair<int, string>> LoadDataAsync(CancellationToken cancellationToken = default)
        {
            return await _automationType.LoadDataAsync();
        }
    }
}
