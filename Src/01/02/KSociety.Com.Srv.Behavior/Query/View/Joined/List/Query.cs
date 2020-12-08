using KSociety.Com.Domain.Repository.View.Joined;
using KSociety.Com.Srv.Contract.Query.View.Joined.List;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;

namespace KSociety.Com.Srv.Behavior.Query.View.Joined.List
{
    public class Query : IQuery
    {
        private readonly ILogger<Query> _logger;
        private readonly IAllTagGroupAllConnection _allTagGroupAllConnection;
        private readonly IAllConnection _allConnection;

        public Query(
            ILoggerFactory loggerFactory,
            IAllTagGroupAllConnection allTagGroupAllConnection,
            IAllConnection allConnection
        )
        {
            _logger = loggerFactory.CreateLogger<Query>();
            _allTagGroupAllConnection = allTagGroupAllConnection;
            _allConnection = allConnection;
        }

        public Srv.Dto.View.Joined.List.AllTagGroupAllConnection AllTagGroupAllConnection(CallContext context = default)
        {
            _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);
            //return new Dto.View.Joined.List.AllTagGroupAllConnection
            //(
            //    _allTagGroupAllConnection.AllTagGroupAllConnections.ToList().Select(allTagGroupAllConnection => new AllTagGroupAllConnection
            //    (
            //        //allTagGroupAllConnection.StdTagId,
            //        allTagGroupAllConnection.Id,
            //        allTagGroupAllConnection.TagName,
            //        //allTagGroupAllConnection.ConnectionId,
            //        allTagGroupAllConnection.ConnectionId,
            //        allTagGroupAllConnection.ConnectionName,
            //        allTagGroupAllConnection.AutomationTypeId,
            //        allTagGroupAllConnection.AutomationName,
            //        allTagGroupAllConnection.Ip,
            //        allTagGroupAllConnection.WriteEnable,
            //        allTagGroupAllConnection.InputOutput,
            //        allTagGroupAllConnection.AnalogDigitalSignal,
            //        allTagGroupAllConnection.Invoke,
            //        allTagGroupAllConnection.TagGroupId,
            //        allTagGroupAllConnection.TagGroupName,
            //        allTagGroupAllConnection.Clock,
            //        allTagGroupAllConnection.Update,
            //        allTagGroupAllConnection.DataBlock,
            //        allTagGroupAllConnection.Offset,
            //        allTagGroupAllConnection.BitOfByte,
            //        allTagGroupAllConnection.Address,
            //        allTagGroupAllConnection.WordLenId,
            //        allTagGroupAllConnection.WordLenName,
            //        allTagGroupAllConnection.AreaId,
            //        allTagGroupAllConnection.AreaName,
            //        //allTagGroupAllConnection.TagPath,
            //        allTagGroupAllConnection.ConnectionTypeId,
            //        allTagGroupAllConnection.ConnectionTypeName,
            //        allTagGroupAllConnection.CpuTypeId,
            //        allTagGroupAllConnection.CpuTypeName,
            //        allTagGroupAllConnection.Rack,
            //        allTagGroupAllConnection.Slot,
            //        allTagGroupAllConnection.Path
            //    )).ToList()
            //);

            return null;
        }

        public Srv.Dto.View.Joined.List.AllTagGroupAllConnection AllTagGroupAllConnectionByName(Srv.Dto.View.Joined.GroupName groupName, CallContext context = default)
        {
            throw new System.NotImplementedException();
        }

        //public async Task<Dto.View.Joined.List.AllTagGroupAllConnection> AllTagGroupAllConnectionAsync()
        //{
        //    return await Task<Dto.View.Joined.List.AllTagGroupAllConnection>.Factory.StartNew(AllTagGroupAllConnection);
        //}

        public Srv.Dto.View.Joined.List.AllTagGroupAllConnection AllTagGroupAllConnectionByName(string groupName, CallContext context = default)
        {
            _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);
            //return new Dto.View.Joined.List.AllTagGroupAllConnection
            //(
            //    _allTagGroupAllConnection.AllTagGroupAllConnections.Where(tags => tags.TagGroupName.Equals(groupName)).ToList().Select(allTagGroupAllConnection => new AllTagGroupAllConnection
            //    (
            //        //allTagGroupAllConnection.StdTagId,
            //        allTagGroupAllConnection.Id,
            //        allTagGroupAllConnection.TagName,
            //        //allTagGroupAllConnection.StdConnectionId,
            //        allTagGroupAllConnection.ConnectionId,
            //        allTagGroupAllConnection.ConnectionName,
            //        allTagGroupAllConnection.AutomationTypeId,
            //        allTagGroupAllConnection.AutomationName,
            //        allTagGroupAllConnection.Ip,
            //        allTagGroupAllConnection.WriteEnable,
            //        allTagGroupAllConnection.InputOutput,
            //        allTagGroupAllConnection.AnalogDigitalSignal,
            //        allTagGroupAllConnection.Invoke,
            //        allTagGroupAllConnection.TagGroupId,
            //        allTagGroupAllConnection.TagGroupName,
            //        allTagGroupAllConnection.Clock,
            //        allTagGroupAllConnection.Update,
            //        allTagGroupAllConnection.DataBlock,
            //        allTagGroupAllConnection.Offset,
            //        allTagGroupAllConnection.BitOfByte,
            //        allTagGroupAllConnection.Address,
            //        allTagGroupAllConnection.WordLenId,
            //        allTagGroupAllConnection.WordLenName,
            //        allTagGroupAllConnection.AreaId,
            //        allTagGroupAllConnection.AreaName,
            //        //allTagGroupAllConnection.TagPath,
            //        allTagGroupAllConnection.ConnectionTypeId,
            //        allTagGroupAllConnection.ConnectionTypeName,
            //        allTagGroupAllConnection.CpuTypeId,
            //        allTagGroupAllConnection.CpuTypeName,
            //        allTagGroupAllConnection.Rack,
            //        allTagGroupAllConnection.Slot,
            //        allTagGroupAllConnection.Path
            //    )).ToList()
            //);

            return null;
        }

        //public async Task<Dto.View.Joined.List.AllTagGroupAllConnection> AllTagGroupAllConnectionByNameAsync(string groupName)
        //{
        //    return await Task<Dto.View.Joined.List.AllTagGroupAllConnection>.Factory.StartNew(() => AllTagGroupAllConnectionByName(groupName));
        //}

        //public Dto.View.Joined.List.AllTagGroupAllConnection AllTagGroupAllConnectionByNameByInputOutput(string groupName, string inputOutput)
        //{
        //    return new Dto.View.Joined.List.AllTagGroupAllConnection
        //    (
        //        _allTagGroupAllConnection.AllTagGroupAllConnections.Where(
        //            tags => tags.TagGroupName.Equals(groupName) && tags.InputOutput.Equals(inputOutput))
        //            .ToList().Select(allTagGroupAllConnection => new AllTagGroupAllConnection
        //        (
        //            allTagGroupAllConnection.StdTagId,
        //            allTagGroupAllConnection.TagId,
        //            allTagGroupAllConnection.TagName,
        //            allTagGroupAllConnection.StdConnectionId,
        //            allTagGroupAllConnection.ConnectionId,
        //            allTagGroupAllConnection.ConnectionName,
        //            allTagGroupAllConnection.AutomationTypeId,
        //            allTagGroupAllConnection.AutomationName,
        //            allTagGroupAllConnection.Ip,
        //            allTagGroupAllConnection.WriteEnable,
        //            allTagGroupAllConnection.InputOutput,
        //            allTagGroupAllConnection.AnalogDigitalSignal,
        //            allTagGroupAllConnection.Invoke,
        //            allTagGroupAllConnection.TagGroupId,
        //            allTagGroupAllConnection.TagGroupName,
        //            allTagGroupAllConnection.Clock,
        //            allTagGroupAllConnection.Update,
        //            allTagGroupAllConnection.DataBlock,
        //            allTagGroupAllConnection.Offset,
        //            allTagGroupAllConnection.BitOfByte,
        //            allTagGroupAllConnection.Address,
        //            allTagGroupAllConnection.WordLenId,
        //            allTagGroupAllConnection.WordLenName,
        //            allTagGroupAllConnection.AreaId,
        //            allTagGroupAllConnection.AreaName,
        //            allTagGroupAllConnection.TagPath,
        //            allTagGroupAllConnection.ConnectionTypeId,
        //            allTagGroupAllConnection.ConnectionTypeName,
        //            allTagGroupAllConnection.CpuTypeId,
        //            allTagGroupAllConnection.CpuTypeName,
        //            allTagGroupAllConnection.Rack,
        //            allTagGroupAllConnection.Slot,
        //            allTagGroupAllConnection.Path
        //        )).ToList()
        //    );
        //}

        public Srv.Dto.View.Joined.List.AllConnection AllConnection(CallContext context = default)
        {
            _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);
            //return new Dto.View.Joined.List.AllConnection
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

            return null;
        }

        //public async Task<Dto.View.Joined.List.AllConnection> AllConnectionAsync()
        //{
        //    return await Task<Dto.View.Joined.List.AllConnection>.Factory.StartNew(AllConnection);
        //}
    }
}
