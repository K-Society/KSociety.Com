using KSociety.Com.Domain.Repository.View.Joined;
using KSociety.Com.Srv.Contract.Query.View.Joined;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Srv.Behavior.Query.View.Joined
{
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

        //public Dto.View.Joined.AllTagGroupAllConnection AllTagGroupAllConnectionByName(string groupName)
        //{
        //    var allTagGroupAllConnection = _allTagGroupAllConnection
        //        .AllTagGroupAllConnections
        //        .SingleOrDefault(tags => tags.TagGroupName.Equals(groupName));

        //    return new Dto.View.Joined.AllTagGroupAllConnection
        //    (
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
        //    );
        //}

        //public async Task<Dto.View.Joined.AllTagGroupAllConnection> AllTagGroupAllConnectionByNameAsync(string groupName)
        //{
        //    return await Task<Dto.View.Joined.AllTagGroupAllConnection>.Factory.StartNew(() => AllTagGroupAllConnectionByName(groupName));
        //}
    }
}
