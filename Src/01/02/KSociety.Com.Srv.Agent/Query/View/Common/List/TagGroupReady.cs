using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using KSociety.Com.Srv.Contract.Query.View.Common.List;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Client;

namespace KSociety.Com.Srv.Agent.Query.View.Common.List
{
    public class TagGroupReady : KSociety.Base.Srv.Agent.Connection
    {
        public TagGroupReady(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
            : base(agentConfiguration, loggerFactory)
        {

        }

        public Srv.Dto.View.Common.List.TagGroupReady LoadAllRecords(CancellationToken cancellationToken = default)
        {
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<IQuery>();

                    return client.TagGroupReady(callContext);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return null;
        }

        public async ValueTask<Srv.Dto.View.Common.List.TagGroupReady> LoadAllRecordsAsync(CancellationToken cancellationToken = default)
        {
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<IQueryAsync>();

                    return await client.TagGroupReadyAsync(callContext);
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
