using System.Threading;
using System.Threading.Tasks;
using KSociety.Base.Srv.Dto;
using KSociety.Com.Pre.Model.Interface.Query.Common.ListKeyValue;
using KSociety.Com.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.Model.Class.Query.Common.ListKeyValue
{
    public class AnalogDigitalSignal : IAnalogDigitalSignal
    {
        private readonly Srv.Agent.Query.Common.ListKeyValue.AnalogDigitalSignal _analogDigital;

        public AnalogDigitalSignal(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        {
            _analogDigital = new Srv.Agent.Query.Common.ListKeyValue.AnalogDigitalSignal(agentConfiguration, loggerFactory);
        }

        public KbListKeyValuePair<string, string> LoadData(CancellationToken cancellationToken = default)
        {
            return _analogDigital.LoadData();
        }

        public async ValueTask<KbListKeyValuePair<string, string>> LoadDataAsync(CancellationToken cancellationToken = default)
        {
            return await _analogDigital.LoadDataAsync();
        }
    }
}
