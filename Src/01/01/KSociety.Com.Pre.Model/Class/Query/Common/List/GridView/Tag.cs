using System;
using System.Threading;
using System.Threading.Tasks;
using KSociety.Com.Pre.Model.Interface.Query.Common.List.GridView;
using KSociety.Com.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Pre.Model.Class.Query.Common.List.GridView
{
    public class Tag : ITag
    {
        private readonly ILogger<Tag> _logger;
        private readonly Srv.Agent.Query.Common.List.GridView.Tag _tag;

        public Tag(IComAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Tag>();
            _tag = new Srv.Agent.Query.Common.List.GridView.Tag(agentConfiguration, loggerFactory);
            
        }

        public Srv.Dto.Common.List.GridView.Tag LoadAllRecords(CancellationToken cancellationToken = default)
        {
            return _tag.LoadAllRecords();
        }

        public async ValueTask<Srv.Dto.Common.List.GridView.Tag> LoadAllRecordsAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _tag.LoadAllRecordsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
                return await new ValueTask<Srv.Dto.Common.List.GridView.Tag>();
            }
        }
    }
}
