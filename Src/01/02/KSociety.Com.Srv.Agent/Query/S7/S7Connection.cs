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
    public class S7Connection : KSociety.Base.Srv.Agent.Connection, KSociety.Com.Srv.Agent.Interface.Query.S7.IS7Connection
    {
        public S7Connection(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
            : base(agentConfiguration, loggerFactory)
        {

        }

        public Srv.Dto.S7.S7Connection Find(IdObject idObject, CancellationToken cancellationToken = default)
        {
            Logger.LogTrace("Query Agent: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " " + idObject.Id);
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<IQuery>();

                    return client.GetS7ConnectionById(idObject, callContext);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return new Dto.S7.S7Connection();
        }

        public async ValueTask<Srv.Dto.S7.S7Connection> FindAsync(IdObject idObject, CancellationToken cancellationToken = default)
        {
            Logger.LogTrace("Query Agent: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " " + idObject.Id);
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<IQueryAsync>();

                    return await client.GetS7ConnectionByIdAsync(idObject, callContext);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return await new ValueTask<Dto.S7.S7Connection>();
        }
    }
}
