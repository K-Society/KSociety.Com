using KSociety.Base.Srv.Agent;
using KSociety.Com.Srv.Contract.Query.S7.List.GridView;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc.Client;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace KSociety.Com.Srv.Agent.Query.S7.List.GridView
{
    public class S7Connection : KSociety.Base.Srv.Agent.Connection, KSociety.Com.Srv.Agent.Interface.Query.S7.List.GridView.IS7Connection
    {
        public S7Connection(IAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
            : base(agentConfiguration, loggerFactory)
        {

        }

        public Srv.Dto.S7.List.GridView.S7Connection LoadAllRecords(CancellationToken cancellationToken = default)
        {
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<IQuery>();

                    return client.S7Connection(ConnectionOptions(cancellationToken));
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return null;
        }

        public async ValueTask<Srv.Dto.S7.List.GridView.S7Connection> LoadAllRecordsAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<IQueryAsync>();

                    return await client.S7ConnectionAsync(ConnectionOptions(cancellationToken));
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
