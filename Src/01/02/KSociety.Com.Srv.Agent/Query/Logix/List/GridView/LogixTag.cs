using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using KSociety.Com.Srv.Contract.Query.Logix.List.GridView;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Client;

namespace KSociety.Com.Srv.Agent.Query.Logix.List.GridView
{
    public class LogixTag : KSociety.Base.Srv.Agent.Connection, KSociety.Com.Srv.Agent.Interface.Query.Logix.List.GridView.ILogixTag
    {
        public LogixTag(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
            : base(agentConfiguration, loggerFactory)
        {

        }

        public Srv.Dto.Logix.List.GridView.LogixTag LoadAllRecords(CancellationToken cancellationToken = default)
        {
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<IQuery>();

                    return client.LogixTag(callContext);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return null;
        }

        public async ValueTask<Srv.Dto.Logix.List.GridView.LogixTag> LoadAllRecordsAsync(CancellationToken cancellationToken = default)
        {
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<IQueryAsync>();

                    return await client.LogixTagAsync(callContext);
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
