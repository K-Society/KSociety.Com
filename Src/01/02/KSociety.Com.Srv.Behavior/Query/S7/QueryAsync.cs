using System;
using System.Threading.Tasks;
using KSociety.Base.Srv.Dto;
using KSociety.Com.Srv.Contract.Query.S7;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;

namespace KSociety.Com.Srv.Behavior.Query.S7
{
    public class QueryAsync : IQueryAsync
    {
        private readonly ILogger<QueryAsync> _logger;
        private readonly Domain.Repository.S7.IConnection _s7ConnectionRepository;
        private readonly Domain.Repository.S7.ITag _s7TagRepository;

        public QueryAsync(
            ILoggerFactory loggerFactory,
            Domain.Repository.S7.IConnection s7ConnectionRepository,
            Domain.Repository.S7.ITag s7TagRepository
        )
        {
            _logger = loggerFactory.CreateLogger<QueryAsync>();
            _s7ConnectionRepository = s7ConnectionRepository;
            _s7TagRepository = s7TagRepository;
        }

        //public int S7Test(int value)
        //{
        //    _logger.Trace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name);
        //    return value;
        //}

        //public async Task<int> S7TestAsync(int value)
        //{
        //    return await Task<int>.Factory.StartNew(() => value);
        //}

        //#region List   

        //public Dto.S7.List.AnalogDigital ListS7AnalogDigital()
        //{
        //    return new Dtos.S7.List.AnalogDigital(
        //        _s7AnalogDigitalRepository.AnalogDigits.ToList().Select(ad => new Dtos.S7.AnalogDigital(ad.AnalogDigitalSignal)).ToList()
        //        );
        //}

        //public Dtos.S7.List.Area ListS7Area()
        //{
        //    return new Dtos.S7.List.Area(
        //        _s7AreaRepository.S7Areas.ToList().Select(
        //            sa => new Dtos.S7.Area(sa.AreaId, sa.AreaName, sa.Mean)).ToList()
        //    );
        //}

        //public Dtos.S7.List.BlockArea ListS7BlockArea()
        //{
        //    return new Dtos.S7.List.BlockArea(
        //        _s7BlockAreaRepository.S7BlockAreas.ToList().Select(
        //            sba => new Dtos.S7.BlockArea(
        //                sba.BlockAreaId, sba.DataBlock, sba.Start,
        //                sba.Amount, sba.Enable, sba.Name,
        //                sba.ConnectionId, sba.AreaId, sba.WordLenId)).ToList()
        //    );
        //}

        //public Dto.S7.List.ConnectionLst ListS7Connection()
        //{
        //    return new Dto.S7.List.ConnectionLst(
        //        _s7ConnectionRepository.S7Connections.ToList().Select(connection => new Dto.S7.Connection(
        //            connection.ConnectionId, connection.Name, connection.Ip,
        //            connection.Rack, connection.Slot, connection.ConnectionTypeId,
        //            connection.RequestedId,
        //            connection.Enable, connection.WriteEnable
        //        )).ToList()
        //    );
        //}

        //public ListS7ConnectionForComboBox ListS7ConnectionForComboBox()
        //{
        //    return new ListS7ConnectionForComboBox(
        //        _s7ConnectionRepository.S7Connections.ToList().Select(connection => new S7ConnectionForComboBox(
        //            connection.ConnectionId, connection.Name
        //        )).ToList()
        //    );
        //}

        //public S7Connection ListS7ConnectionGridView()
        //{
        //    return new S7Connection(
        //        _s7ConnectionRepository.S7Connections.ToList().Select(connection => new Dtos.S7Connection(
        //            connection.ConnectionId, connection.Name, connection.Ip,
        //            connection.Rack, connection.Slot, connection.ConnectionTypeId,
        //            connection.RequestedId,
        //            connection.Enable, connection.WriteEnable
        //        )).ToList(), 
        //            _s7ConnectionTypeRepository.S7ConnectionTypes.ToList().Select(connectionType => new StandardKeyValuePair<int, string>(
        //                connectionType.ConnectionTypeId, connectionType.Name
        //            )).ToList(),
        //        _s7RequestedRepository.S7Requests.ToList().Select(r => new StandardKeyValuePair<int, int>(r.RequestedId, r.RequestedId)).ToList()
        //    );
        //}

        //public Dtos.S7.List.ConnectionType ListS7ConnectionType()
        //{
        //    return new Dtos.S7.List.ConnectionType(
        //        _s7ConnectionTypeRepository.S7ConnectionTypes.ToList().Select(connectionType => new Dtos.S7.ConnectionType(
        //            connectionType.ConnectionTypeId, connectionType.Name
        //        )).ToList()
        //    );
        //}

        //public ListS7ExportDestination ListS7ExportDestination()
        //{
        //    return new ListS7ExportDestination(
        //        _s7ExportDestinationRepository.S7ExportDestinations.ToList().Select(ed => new S7ExportDestination(
        //            ed.ExportDestinationId, ed.DestinationDataBase, ed.DestinationTable, ed.DestinationColumn, ed.Enable
        //            )).ToList()
        //        );
        //}

        //public S7Group ListS7Group()
        //{
        //    return new S7Group(
        //        _s7GroupRepository.S7Groups.ToList().Select(g => new S7Group(g.GroupId, g.Name, g.Clock, g.Enable)).ToList()
        //    );
        //}

        //public ListS7GroupForComboBox ListS7GroupForComboBox()
        //{
        //    return new ListS7GroupForComboBox(
        //        _s7GroupRepository.S7Groups.ToList().Select(g => new S7GroupForComboBox(g.GroupId, g.Name)).ToList()
        //    );
        //}

        //public Dtos.S7.List.InOut ListS7InOut()
        //{
        //    return new Dtos.S7.List.InOut(
        //        _s7InOutRepository.InOuts.ToList().Select(io => new Dtos.S7.InOut(io.InputOutput)).ToList()
        //        );
        //}

        //public Dtos.S7.List.Requested ListS7Requested()
        //{
        //    return new Dtos.S7.List.Requested(
        //        _s7RequestedRepository.S7Requests.ToList().Select(r => new Dtos.S7.Requested(r.RequestedId)).ToList()
        //    );
        //}

        //public S7Tag ListS7Tag()
        //{
        //    return new Dtos.List.S7Tag(
        //        _s7TagRepository.S7Tags.ToList().Select(tag => new S7Tag(
        //            tag.TagId, tag.DataBlock, tag.Offset, tag.AnalogDigitalSignal,
        //            tag.Bit, tag.Name, tag.ConnectionId, /*tag.ExportDestinationId,*/
        //            tag.Enable, tag.GroupId, tag.InputOutput, tag.Invoke,
        //            tag.WordLen, tag.Area
        //        )).ToList()
        //    );
        //}

        //public Dtos.S7.List.WordLen ListS7WordLen()
        //{
        //    return new Dtos.S7.List.WordLen(
        //        _s7WordLenRepository.S7WordLens.ToList().Select(
        //            wl => new Dtos.S7.WordLen(wl.WordLenId, wl.WordLenName, wl.Mean)).ToList()
        //    );
        //}

        //#endregion


        //public S7Tag ListS7TagByGroup(Dtos.S7Group s7Group)
        //{
        //    return new Dtos.List.S7Tag(
        //        _s7TagRepository.S7Tags.ToList().Select(tag => new S7Tag(
        //            tag.TagId, tag.DataBlock, tag.Offset, tag.AnalogDigitalSignal, tag.Bit, tag.Name, tag.ConnectionId,
        //            /*tag.ExportDestinationId,*/ tag.Enable, tag.GroupId, tag.InputOutput, tag.Invoke, tag.WordLen,
        //            tag.Area
        //        )).ToList()
        //    );
        //}

        public async ValueTask<Srv.Dto.S7.S7Connection> GetS7ConnectionByIdAsync(KbIdObject idObject, CallContext context = default)
        {
            Domain.Entity.S7.S7Connection s7Connection = null;
            _logger.LogTrace("Query Behavior: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);
            try
            {
                s7Connection = await _s7ConnectionRepository.FindAsync(context.CancellationToken, idObject.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError("Query Behavior: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " " + ex.Message + " - " + ex.StackTrace);
            }

            return new Srv.Dto.S7.S7Connection(s7Connection.Id, s7Connection.AutomationTypeId, s7Connection.Name, s7Connection.Ip, s7Connection.Enable, s7Connection.WriteEnable, s7Connection.CpuTypeId, s7Connection.Rack, s7Connection.Slot, s7Connection.ConnectionTypeId);
        }

        public async ValueTask<Srv.Dto.S7.S7Tag> GetS7TagByIdAsync(KbIdObject idObject, CallContext context = default)
        {
            Domain.Entity.S7.S7Tag s7Tag = null;
            _logger.LogTrace("Query Behavior: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);
            try
            {
                s7Tag = await _s7TagRepository.FindAsync(context.CancellationToken, idObject.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError("Query Behavior: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " " + ex.Message + " - " + ex.StackTrace);
            }

            return new Srv.Dto.S7.S7Tag(s7Tag.Id, s7Tag.AutomationTypeId, s7Tag.Name, s7Tag.ConnectionId, s7Tag.Enable, s7Tag.InputOutput, s7Tag.AnalogDigitalSignal,
                s7Tag.MemoryAddress, s7Tag.Invoke, s7Tag.TagGroupId, s7Tag.DataBlock, s7Tag.Offset, s7Tag.BitOfByte, s7Tag.WordLenId, s7Tag.AreaId, s7Tag.StringLength);
        }
    }
}
