using System;
using System.Collections.Generic;
using KSociety.Base.Domain.Shared.Class;
using KSociety.Base.InfraSub.Shared.Interface;
using KSociety.Com.Domain.Entity.View.Joined;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Domain.Entity.View.Common;

public class TagGroupReady : BaseEntity
{
    private List<Joined.AllTagGroupAllConnection> _dataList;
    private List<string> _connectionName;
    private readonly Dictionary<string, AllConnection> _systemConnections = new Dictionary<string, AllConnection>();
    private readonly Dictionary<string, AllConnection> _systemReadTags = new Dictionary<string, AllConnection>();
    private readonly Dictionary<string, AllConnection> _systemWriteTags = new Dictionary<string, AllConnection>();

    #region [Propery]

    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public int Clock { get; private set; }

    public int Update { get; private set; }

    #endregion

    public TagGroupReady
        (
            Guid id, 
            string name, 
            int clock, 
            int update)
        //:base(/*LogManager.GetCurrentClassLogger()*/)
    {
        Id = id;
        Name = name;
        Clock = clock;
        Update = update;
    }

    public Entity.Common.TagGroup GetTagGroup(/*IConnectionFactory connectionFactory,*/ INotifierMediatorService notifierMediatorService)
        //public Entity.Common.TagGroup GetTagGroup(IConnection connectionFactory)
    {
        Logger?.LogInformation("GetTagGroup: " + Name);

        var tagGroup = new Entity.Common.TagGroup(
            notifierMediatorService,
            ////connectionFactory,
            Id,
            Name,
            Clock,
            Update,
            true
        );

        if (LoggerFactory is null) return tagGroup;

        tagGroup.AddLoggerFactory(LoggerFactory);

        return tagGroup;
    }

    //public void Initiate(List<Joined.AllTagGroupAllConnection> dataList)
    //{
    //    Logger.Trace("Domain.Entity.View.Common.TagGroupReady Initiate: " + Name);
    //    if (!dataList.Any())
    //    {
    //        Logger.Warn("Domain.Entity.View.Common.TagGroupReady: " + Name + " No Data!");
    //        return;
    //    }
    //    _dataList = dataList;

    //    _connectionName = _dataList.Select(connection => connection.ConnectionName).Distinct().ToList();

    //    foreach (var connection in _connectionName)
    //    {
    //        //var temp = _dataList.Where(dataItem => dataItem.ConnectionName.Equals(connection) && dataItem.InputOutput.Equals("R") || dataItem.InputOutput.Equals("RW")).ToList();

    //        var connectionData = _dataList.Find(tag => tag.ConnectionName.Equals(connection)).GetAllConnection();

    //        if(_systemConnections.ContainsKey(connection)) continue;
    //        _systemConnections.Add(connection, connectionData);

    //        connectionData.Initiate(_dataList.Where(dataItem => dataItem.ConnectionName.Equals(connection)).ToList());
    //    }
    //}//Initiate
}