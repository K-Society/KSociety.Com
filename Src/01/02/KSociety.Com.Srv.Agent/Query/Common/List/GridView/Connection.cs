using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using KSociety.Com.Srv.Contract.Query.Common.List.GridView;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Client;

namespace KSociety.Com.Srv.Agent.Query.Common.List.GridView
{
    public class Connection : KSociety.Base.Srv.Agent.Connection, KSociety.Com.Srv.Agent.Interface.Query.Common.List.GridView.IConnection
    {
        public Connection(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
            : base(agentConfiguration, loggerFactory)
        {

        }

        public Srv.Dto.Common.List.GridView.Connection LoadAllRecords(CancellationToken cancellationToken = default)
        {
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<IQuery>();

                    return client.Connection(callContext);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return null;
        }

        public async ValueTask<Srv.Dto.Common.List.GridView.Connection> LoadAllRecordsAsync(CancellationToken cancellationToken = default)
        {
            Logger.LogTrace("Query Agent: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<IQueryAsync>();

                    return await client.ConnectionAsync(callContext);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return await new ValueTask<Dto.Common.List.GridView.Connection>();
        }
    }
}
