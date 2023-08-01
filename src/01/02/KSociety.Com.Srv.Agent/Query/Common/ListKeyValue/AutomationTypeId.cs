using KSociety.Base.Srv.Agent;
using KSociety.Base.Srv.Dto;
using KSociety.Com.Srv.Contract.Query.Common.ListKeyValue;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.Srv.Agent.Query.Common.ListKeyValue;

public class AutomationTypeId : KSociety.Base.Srv.Agent.Connection, KSociety.Com.Srv.Agent.Interface.Query.Common.ListKeyValue.IAutomationTypeId
{
    public AutomationTypeId(IAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        : base(agentConfiguration, loggerFactory)
    {

    }

    public ListKeyValuePair<int, string> LoadData(CancellationToken cancellationToken = default)
    {
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<IQuery>();

                return client.AutomationTypeId(ConnectionOptions(cancellationToken));
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
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<IQueryAsync>();

                return await client.AutomationTypeIdAsync(ConnectionOptions(cancellationToken));
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return null;
    }
}