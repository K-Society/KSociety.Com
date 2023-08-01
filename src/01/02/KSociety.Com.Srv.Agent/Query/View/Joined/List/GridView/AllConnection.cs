using KSociety.Base.Srv.Agent;
using KSociety.Com.Srv.Contract.Query.View.Joined.List.GridView;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.Srv.Agent.Query.View.Joined.List.GridView;

public class AllConnection : KSociety.Base.Srv.Agent.Connection
{
    public AllConnection(IAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        : base(agentConfiguration, loggerFactory)
    {

    }

    public Srv.Dto.View.Joined.List.GridView.AllConnection LoadAllRecords(CancellationToken cancellationToken = default)
    {
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<IQuery>();

                return client.AllConnection(ConnectionOptions(cancellationToken));
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return null;
    }

    public async Task<Srv.Dto.View.Joined.List.GridView.AllConnection> LoadAllRecordsAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<IQueryAsync>();

                return await client.AllConnectionAsync(ConnectionOptions(cancellationToken));
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return null;
    }
}