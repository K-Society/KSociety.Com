using KSociety.Base.Srv.Agent;
using KSociety.Base.Srv.Dto;
using KSociety.Com.Srv.Contract.Query.Common.Model;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.Srv.Agent.Query.Common.Model;

public class Tag : KSociety.Base.Srv.Agent.Connection, KSociety.Com.Srv.Agent.Interface.Query.Common.Model.ITag
{
    public Tag(IAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        : base(agentConfiguration, loggerFactory)
    {
            
    }

    public Srv.Dto.Common.Model.Tag Find(IdObject idObject, CancellationToken cancellationToken = default)
    {
        Logger.LogTrace("Query Agent: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " " + idObject.Id);
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<IQuery>();

                return client.GetTagModelById(idObject, ConnectionOptions(cancellationToken));
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return new Dto.Common.Model.Tag();
    }

    public async ValueTask<Srv.Dto.Common.Model.Tag> FindAsync(IdObject idObject, CancellationToken cancellationToken = default)
    {
        Logger.LogTrace("Query Agent: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " " + idObject.Id);
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<IQueryAsync>();

                return await client.GetTagModelByIdAsync(idObject, ConnectionOptions(cancellationToken));
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return await new ValueTask<Dto.Common.Model.Tag>();
    }
}