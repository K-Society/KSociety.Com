using KSociety.Base.Srv.Agent;
using KSociety.Com.Srv.Contract.Query.View.Common.List.GridView;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.Srv.Agent.Query.View.Common.List.GridView
{
    public class TagGroupReady : KSociety.Base.Srv.Agent.Connection, KSociety.Com.Srv.Agent.Interface.Query.View.Common.List.GridView.ITagGroupReady
    {
        public TagGroupReady(IAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
            : base(agentConfiguration, loggerFactory)
        {

        }

        public Srv.Dto.View.Common.List.GridView.TagGroupReady LoadAllRecords(CancellationToken cancellationToken = default)
        {
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<IQuery>();

                    return client.TagGroupReady(ConnectionOptions(cancellationToken));
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return null;
        }

        public async ValueTask<Srv.Dto.View.Common.List.GridView.TagGroupReady> LoadAllRecordsAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<IQueryAsync>();

                    return await client.TagGroupReadyAsync(ConnectionOptions(cancellationToken));
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
