using KSociety.Base.Srv.Agent;
using KSociety.Base.Srv.Dto;
using KSociety.Com.Srv.Contract.Query.Common;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.Srv.Agent.Query.Common;

public class Connection : KSociety.Base.Srv.Agent.Connection, KSociety.Com.Srv.Agent.Interface.Query.Common.IConnection
{
    public Connection(IAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        : base(agentConfiguration, loggerFactory)
    {

    }

    public Srv.Dto.Common.Connection Find(IdObject idObject, CancellationToken cancellationToken = default)
    {
        Logger.LogTrace("Query Agent: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " " + idObject.Id);
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<IQuery>();

                return client.GetConnectionById(idObject, ConnectionOptions(cancellationToken));
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return new Dto.Common.Connection();
    }

    public async ValueTask<Srv.Dto.Common.Connection> FindAsync(IdObject idObject, CancellationToken cancellationToken = default)
    {
        Logger.LogTrace("Query Agent: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " " + idObject.Id);
        try
        {
            using (Channel)
            {
                var client = Channel.CreateGrpcService<IQueryAsync>();

                return await client.GetConnectionByIdAsync(idObject, ConnectionOptions(cancellationToken));
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
        }
        return await new ValueTask<Dto.Common.Connection>();
    }
}