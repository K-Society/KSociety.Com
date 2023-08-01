using KSociety.Base.Srv.Agent;
using KSociety.Com.Srv.Contract.Query.Common.List.GridView;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.Srv.Agent.Query.Common.List.GridView;

public class Tag : KSociety.Base.Srv.Agent.Connection, KSociety.Com.Srv.Agent.Interface.Query.Common.List.GridView.ITag
{
    public Tag(IAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        : base(agentConfiguration, loggerFactory)
    {

    }

    public Srv.Dto.Common.List.GridView.Tag LoadAllRecords(CancellationToken cancellationToken = default)
    {
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<IQuery>();

                return client.Tag(ConnectionOptions(cancellationToken));
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return null;
    }

    public async ValueTask<Srv.Dto.Common.List.GridView.Tag> LoadAllRecordsAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<IQueryAsync>();

                return await client.TagAsync(ConnectionOptions(cancellationToken));
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return null;
    }
}