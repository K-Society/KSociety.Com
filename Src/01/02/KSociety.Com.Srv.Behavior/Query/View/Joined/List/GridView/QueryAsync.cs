using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KSociety.Com.Domain.Repository.View.Joined;
using KSociety.Com.Srv.Contract.Query.View.Joined.List.GridView;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;

namespace KSociety.Com.Srv.Behavior.Query.View.Joined.List.GridView
{
    public class QueryAsync : IQueryAsync
    {
        private readonly ILogger<QueryAsync> _logger;
        private readonly IMapper _mapper;
        private readonly IAllTagGroupAllConnection _allTagGroupAllConnection;
        private readonly IAllConnection _allConnection;

        public QueryAsync(
            ILoggerFactory loggerFactory,
            IMapper mapper,
            IAllTagGroupAllConnection allTagGroupAllConnection,
            IAllConnection allConnection
        )
        {
            _logger = loggerFactory.CreateLogger<QueryAsync>();
            _mapper = mapper;
            _allTagGroupAllConnection = allTagGroupAllConnection;
            _allConnection = allConnection;
        }

        public async ValueTask<Srv.Dto.View.Joined.List.GridView.AllTagGroupAllConnection> AllTagGroupAllConnectionAsync(CallContext context = default)
        {
            _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);
            var repository = await _allTagGroupAllConnection.GetAllTagGroupAllConnectionAsync();
            var tagGroupItems = repository.ToList().Select(
                tagGroup => _mapper.Map<Srv.Dto.View.Joined.AllTagGroupAllConnection>(tagGroup)
            ).ToList();

            var output = new Srv.Dto.View.Joined.List.GridView.AllTagGroupAllConnection(tagGroupItems);
            return output;
        }

        //public async Task<Dto.View.Joined.List.GridView.AllTagGroupAllConnection> AllTagGroupAllConnectionAsync()
        //{
        //    return await Task<Dto.View.Joined.List.GridView.AllTagGroupAllConnection>.Factory.StartNew(AllTagGroupAllConnection);
        //}

        public async ValueTask<Srv.Dto.View.Joined.List.GridView.AllConnection> AllConnectionAsync(CallContext context = default)
        {
            _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);

            var repository = await _allConnection.GetAllConnectionAsync();
            var allConnectionItems = repository.ToList().Select(
                allConnection => _mapper.Map<Srv.Dto.View.Joined.AllConnection>(allConnection)
            ).ToList();

            var output = new Srv.Dto.View.Joined.List.GridView.AllConnection(allConnectionItems);
            return output;

            //return new Dto.View.Joined.List.GridView.AllConnection
            //(
            //    _allConnection.AllConnections.ToList().Select(allConnection => new AllConnection
            //    (
            //        //allConnection.StdConnectionId,
            //        allConnection.Id,
            //        allConnection.AutomationTypeId,
            //        allConnection.AutomationName,
            //        allConnection.ConnectionName,
            //        allConnection.Ip,
            //        allConnection.WriteEnable,
            //        allConnection.Path,
            //        allConnection.CpuTypeId,
            //        allConnection.CpuTypeName,
            //        allConnection.Rack,
            //        allConnection.Slot,
            //        allConnection.ConnectionTypeId,
            //        allConnection.ConnectionTypeName

            //    )).ToList()
            //);
        }

        //public async Task<Dto.View.Joined.List.GridView.AllConnection> AllConnectionAsync()
        //{
        //    return await Task<Dto.View.Joined.List.GridView.AllConnection>.Factory.StartNew(AllConnection);
        //}
    }
}
