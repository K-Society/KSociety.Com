using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using KSociety.Base.Srv.Dto;
using KSociety.Com.Srv.Contract.Query.Common.ListKeyValue;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Client;

namespace KSociety.Com.Srv.Agent.Query.Common.ListKeyValue
{
    public class AutomationTypeId : KSociety.Base.Srv.Agent.Connection, KSociety.Com.Srv.Agent.Interface.Query.Common.ListKeyValue.IAutomationTypeId
    {
        public AutomationTypeId(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
            : base(agentConfiguration, loggerFactory)
        {

        }

        public ListKeyValuePair<int, string> LoadData(CancellationToken cancellationToken = default)
        {
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<IQuery>();

                    return client.AutomationTypeId(callContext);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return null;
        }

        public async ValueTask<ListKeyValuePair<int, string>> LoadDataAsync(CancellationToken cancellationToken = default)
        {
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<IQueryAsync>();

                    return await client.AutomationTypeIdAsync(callContext);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return null;
        }
    }
}
