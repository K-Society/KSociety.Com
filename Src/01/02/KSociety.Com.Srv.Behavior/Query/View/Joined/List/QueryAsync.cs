using System.Threading.Tasks;
using KSociety.Com.Domain.Repository.View.Joined;
using KSociety.Com.Srv.Contract.Query.View.Joined.List;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;

namespace KSociety.Com.Srv.Behavior.Query.View.Joined.List;

public class QueryAsync : IQueryAsync
{
    private readonly ILogger<QueryAsync> _logger;
    private readonly IAllTagGroupAllConnection _allTagGroupAllConnection;
    private readonly IAllConnection _allConnection;

    public QueryAsync(
        ILoggerFactory loggerFactory,
        IAllTagGroupAllConnection allTagGroupAllConnection,
        IAllConnection allConnection
    )
    {
        _logger = loggerFactory.CreateLogger<QueryAsync>();
        _allTagGroupAllConnection = allTagGroupAllConnection;
        _allConnection = allConnection;
    }

    public async ValueTask<Srv.Dto.View.Joined.List.AllTagGroupAllConnection> AllTagGroupAllConnectionAsync(CallContext context = default)
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

    public async ValueTask<Srv.Dto.View.Joined.List.AllTagGroupAllConnection> AllTagGroupAllConnectionByNameAsync(Srv.Dto.View.Joined.GroupName groupName, CallContext context = default)
    {
        throw new System.NotImplementedException();
    }

    //public async Task<Dto.View.Joined.List.AllTagGroupAllConnection> AllTagGroupAllConnectionAsync()
    //{
    //    return await Task<Dto.View.Joined.List.AllTagGroupAllConnection>.Factory.StartNew(AllTagGroupAllConnection);
    //}

    public async ValueTask<Srv.Dto.View.Joined.List.AllTagGroupAllConnection> AllTagGroupAllConnectionByNameAsync(string groupName, CallContext context = default)
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

    public async ValueTask<Srv.Dto.View.Joined.List.AllConnection> AllConnectionAsync(CallContext context = default)
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