using KSociety.Com.Domain.Repository.S7;
using KSociety.Com.Srv.Contract.Query.S7.List;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;

namespace KSociety.Com.Srv.Behavior.Query.S7.List
{
    public class Query : IQuery
    {
        private readonly ILogger<Query> _logger;
        private readonly IArea _s7AreaRepository;
        private readonly IConnection _s7ConnectionRepository;

        public Query(
            ILogger<Query> logger,
            IArea s7AreaRepository,
            IConnection s7ConnectionRepository
        )
        {
            _logger = logger;
            _s7AreaRepository = s7AreaRepository;
            _s7ConnectionRepository = s7ConnectionRepository;

        }

        public Srv.Dto.S7.List.Area Area(CallContext context = default)
        {
            _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);
            //return new Dto.S7.List.Area(
            //    _s7AreaRepository.S7Areas.ToList().Select(
            //        sa => new Dto.S7.Area(sa.Id, sa.AreaName, sa.Mean)).ToList()
            //);

            return null;
        }

        //public async Task<Dto.S7.List.Area> AreaAsync()
        //{
        //    return await Task<Dto.S7.List.Area>.Factory.StartNew(Area);
        //}

        //public Dto.S7.List.Connection Connection()
        //{
        //    _logger.Trace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name);
        //    return new Dto.S7.List.Connection(
        //        _s7ConnectionRepository.S7Connections.ToList().Select(connection => new Dto.S7.Connection(
        //            connection.ConnectionId, connection.Name, /*connection.Ip,*/ /*connection.ConnectionId,*/
        //            connection.CpuTypeId,
        //            connection.Rack, connection.Slot, connection.ConnectionTypeId
        //            //connection.RequestedId,
        //            //connection.Enable, connection.WriteEnable
        //        )).ToList()
        //    );
        //}

        //public async Task<Dto.S7.List.Connection> ConnectionAsync()
        //{
        //    return await Task<Dto.S7.List.Connection>.Factory.StartNew(Connection);
        //}
    }
}
