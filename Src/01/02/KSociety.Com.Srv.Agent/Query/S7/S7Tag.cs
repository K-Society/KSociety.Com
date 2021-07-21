using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using KSociety.Base.Srv.Dto;
using KSociety.Com.Srv.Contract.Query.S7;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Client;

namespace KSociety.Com.Srv.Agent.Query.S7
{
    public class S7Tag : KSociety.Base.Srv.Agent.Connection, KSociety.Com.Srv.Agent.Interface.Query.S7.IS7Tag
    {
        public S7Tag(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
            : base(agentConfiguration, loggerFactory)
        {

        }

        public Srv.Dto.S7.S7Tag Find(IdObject idObject, CancellationToken cancellationToken = default)
        {
            Logger.LogTrace("Query Agent: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " " + idObject.Id);
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<IQuery>();

                    return client.GetS7TagById(idObject, callContext);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return new Dto.S7.S7Tag();
        }

        public async ValueTask<Srv.Dto.S7.S7Tag> FindAsync(IdObject idObject, CancellationToken cancellationToken = default)
        {
            Logger.LogTrace("Query Agent: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " " + idObject.Id);
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<IQueryAsync>();

                    return await client.GetS7TagByIdAsync(idObject, callContext);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return await new ValueTask<Dto.S7.S7Tag>();
        }
    }
}
