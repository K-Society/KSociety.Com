using KSociety.Base.Srv.Agent;
using KSociety.Com.Srv.Contract.Query.Logix.List.GridView;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.Srv.Agent.Query.Logix.List.GridView
{
    public class LogixConnection : KSociety.Base.Srv.Agent.Connection, KSociety.Com.Srv.Agent.Interface.Query.Logix.List.GridView.ILogixConnection
    {
        public LogixConnection(IAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
            : base(agentConfiguration, loggerFactory)
        {

        }

        public Srv.Dto.Logix.List.GridView.LogixConnection LoadAllRecords(CancellationToken cancellationToken = default)
        {
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<IQuery>();

                    return client.LogixConnection(ConnectionOptions(cancellationToken));
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return null;
        }

        public async ValueTask<Srv.Dto.Logix.List.GridView.LogixConnection> LoadAllRecordsAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<IQueryAsync>();

                    return await client.LogixConnectionAsync(ConnectionOptions(cancellationToken));
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
