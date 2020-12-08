using System;
using System.Threading;
using System.Threading.Tasks;
using KSociety.Base.Srv.Dto;
using KSociety.Com.Srv.Contract.Query.S7;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Client;

namespace KSociety.Com.Srv.Agent.Query.S7
{
    public class S7Connection : KSociety.Base.Srv.Agent.Connection
    {
        public S7Connection(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
            : base(agentConfiguration, loggerFactory)
        {

        }

        public Srv.Dto.S7.S7Connection GetS7ConnectionById(KbIdObject idObject, CancellationToken cancellationToken = default)
        {
            Logger.LogTrace("Query Agent: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " " + idObject.Id);
            CallOptions = CallOptions.WithCancellationToken(cancellationToken);
            CallContext = new CallContext(CallOptions, CallContextFlags.IgnoreStreamTermination);
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<IQuery>();

                    return client.GetS7ConnectionById(idObject, CallContext);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return new Dto.S7.S7Connection();
        }

        public async ValueTask<Srv.Dto.S7.S7Connection> GetS7ConnectionByIdAsync(KbIdObject idObject, CancellationToken cancellationToken = default)
        {
            Logger.LogTrace("Query Agent: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " " + idObject.Id);
            CallOptions = CallOptions.WithCancellationToken(cancellationToken);
            CallContext = new CallContext(CallOptions, CallContextFlags.IgnoreStreamTermination);
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<IQueryAsync>();

                    return await client.GetS7ConnectionByIdAsync(idObject, CallContext);
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
