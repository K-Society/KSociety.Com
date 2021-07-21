using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using KSociety.Base.Srv.Dto;
using KSociety.Com.Srv.Contract.Query.Common.Model;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Client;

namespace KSociety.Com.Srv.Agent.Query.Common.Model
{
    public class Tag : KSociety.Base.Srv.Agent.Connection, KSociety.Com.Srv.Agent.Interface.Query.Common.Model.ITag
    {
        public Tag(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
            : base(agentConfiguration, loggerFactory)
        {
            
        }

        public Srv.Dto.Common.Model.Tag Find(IdObject idObject, CancellationToken cancellationToken = default)
        {
            Logger.LogTrace("Query Agent: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " " + idObject.Id);
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<IQuery>();

                    return client.GetTagModelById(idObject, callContext);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return new Dto.Common.Model.Tag();
        }

        public async ValueTask<Srv.Dto.Common.Model.Tag> FindAsync(IdObject idObject, CancellationToken cancellationToken = default)
        {
            Logger.LogTrace("Query Agent: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " " + idObject.Id);
            var callOptions = new CallOptions().WithCancellationToken(cancellationToken);
            var callContext = new CallContext(callOptions, CallContextFlags.IgnoreStreamTermination);
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<IQueryAsync>();

                    return await client.GetTagModelByIdAsync(idObject, callContext);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return await new ValueTask<Dto.Common.Model.Tag>();
        }
    }
}
