using System.Threading;
using System.Threading.Tasks;
using KSociety.Base.Srv.Dto;
using KSociety.Com.Pre.Model.Interface.Query.Common.ListKeyValue;
using KSociety.Com.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.Model.Class.Query.Common.ListKeyValue
{
    public class InputOutput : IInputOutput
    {
        private readonly Srv.Agent.Query.Common.ListKeyValue.InputOutput _inOut;

        public InputOutput(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        {
            _inOut = new Srv.Agent.Query.Common.ListKeyValue.InputOutput(agentConfiguration, loggerFactory);
        }

        public KbListKeyValuePair<string, string> LoadData(CancellationToken cancellationToken = default)
        {
            return _inOut.LoadData();
        }

        public async ValueTask<KbListKeyValuePair<string, string>> LoadDataAsync(CancellationToken cancellationToken = default)
        {
            return await _inOut.LoadDataAsync();
        }
    }
}
