using System;
using System.Threading;
using System.Threading.Tasks;
using KSociety.Com.Srv.Contract.Query.View.Joined.List.GridView;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Client;

namespace KSociety.Com.Srv.Agent.Query.View.Joined.List.GridView
{
    public class AllTagGroupAllConnection : KSociety.Base.Srv.Agent.Connection
    {
        public AllTagGroupAllConnection(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
            : base(agentConfiguration, loggerFactory)
        {

        }

        public Srv.Dto.View.Joined.List.GridView.AllTagGroupAllConnection LoadAllRecords(CancellationToken cancellationToken = default)
        {
            CallOptions = CallOptions.WithCancellationToken(cancellationToken);
            CallContext = new CallContext(CallOptions, CallContextFlags.IgnoreStreamTermination);
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<IQuery>();

                    return client.AllTagGroupAllConnection(CallContext);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return null;
        }

        public async ValueTask<Srv.Dto.View.Joined.List.GridView.AllTagGroupAllConnection> LoadAllRecordsAsync(CancellationToken cancellationToken = default)
        {
            CallOptions = CallOptions.WithCancellationToken(cancellationToken);
            CallContext = new CallContext(CallOptions, CallContextFlags.IgnoreStreamTermination);
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<IQueryAsync>();

                    return await client.AllTagGroupAllConnectionAsync(CallContext);
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
