using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KSociety.Base.Domain.Shared.Class;
using KSociety.Base.InfraSub.Shared.Class;
using KSociety.Base.InfraSub.Shared.Interface;
using Microsoft.Extensions.Logging;
using Quartz; //using Std.Srv.Shared.Interface;

namespace KSociety.Com.Domain.Entity.Common
{
    public class TagGroup : EntityNotifier //<NotifyTagEvent>
    {
        private List<View.Joined.AllTagGroupAllConnection> _dataList;
        private List<string> _connectionNameList;
        //private List<Tag> _tagList;
        //public readonly Dictionary<string, Tag> _tagDictionary = new Dictionary<string, Tag>();
        public readonly Dictionary<string, Connection> Connection = new Dictionary<string, Connection>();
        private readonly Dictionary<string, List<View.Joined.AllTagGroupAllConnection>> _dataItemByConnection = new Dictionary<string, List<View.Joined.AllTagGroupAllConnection>>();
        private readonly Dictionary<string, List<Tag>> _tagByConnection = new Dictionary<string, List<Tag>>();
        public readonly Dictionary<string, List<Tag>> _tagReadByConnection = new Dictionary<string, List<Tag>>();
        public readonly Dictionary<string, List<Tag>> _tagWriteByConnection = new Dictionary<string, List<Tag>>();
        private Scheduler _scheduleRead;
        //public  IEventBus EventBus;
        //private IEventBus _eventWriteBus;
        //private readonly IConnectionFactory _connectionFactory;
        //private IConnection _connectionFactory;



        #region [Propery]
        //public Guid TagGroupId { get; private set; }
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public int Clock { get; private set; }

        public int Update { get; private set; }

        public bool Enable { get; private set; }

        public virtual ICollection<Tag> Tags { get; private set; } = new List<Tag>();
        #endregion

        #region [Constructor]
        //For Csv.
        public TagGroup(
            Guid id, string name, int clock, int update, bool enable)
            //: base(/*LogManager.GetCurrentClassLogger()*/)
        {
            //TagGroupId = tagGroupId;
            Id = id;
            Name = name;
            Clock = clock;
            Update = update;
            Enable = enable;

        }

        public TagGroup(
            string name, int clock, int update, bool enable)
            //:base(/*LogManager.GetCurrentClassLogger()*/)
        {
            Name = name;
            Clock = clock;
            Update = update;
            Enable = enable;

            //Logger.Info("Domain.Entity.TagGroup: " + Name + " ");
        }

        public TagGroup(
            INotifierMediatorService notifierMediatorService,
            //ILoggerFactory loggerFactory,
            ////IConnectionFactory connectionFactory,
            Guid id, string name, int clock, int update, bool enable)
            : base(/*LogManager.GetCurrentClassLogger(),*/ notifierMediatorService)
        {
            //Logger = loggerFactory.CreateLogger<TagGroup>();
            //_connectionFactory = connectionFactory;
            //TagGroupId = tagGroupId;
            Id = id;
            Name = name;
            Clock = clock;
            Update = update;
            Enable = enable;

        }

        #endregion

        public void Modify(string name, int clock, int update, bool enable)
        {
            Name = name;
            Clock = clock;
            Update = update;
            Enable = enable;
        }

        public void Initiate(List<View.Joined.AllTagGroupAllConnection> dataList)
        {
            try
            {
                if (!dataList.Any())
                {
                    //Logger?.LogWarning("Domain.Entity.Common.TagGroup Initiate: " + Name + " No Data!");
                    return;
                }

                //InitiateEventBus();
                _dataList = dataList;
                //_tagList = new List<Tag>();
                _connectionNameList = _dataList.Select(connection => connection.ConnectionName).Distinct().ToList();
                //Logger.Trace("Domain.Entity.Common.TagGroup Initiate: " + _connectionNameList.Count);
                foreach (var connectionName in _connectionNameList)
                {
                    //Logger?.LogTrace("Domain.Entity.Common.TagGroup Initiate: " + connectionName);

                    if (Connection.ContainsKey(connectionName)) continue;
                    var commonConnection = _dataList.FirstOrDefault(tag => tag.ConnectionName.Equals(connectionName))
                        ?.GetCommonConnection();

                    commonConnection?.AddLoggerFactory(LoggerFactory);

                    Connection.Add(connectionName, commonConnection);

                    if (_dataItemByConnection.ContainsKey(connectionName)) continue;
                    _dataItemByConnection.Add(connectionName,
                        _dataList.Where(dataItem => dataItem.ConnectionName.Equals(connectionName)).ToList());

                    foreach (var dataItem in _dataItemByConnection[connectionName])
                    {
                        var tag = dataItem.GetCommonTag(NotifierMediatorService,/*_eventBus,*/ Connection[connectionName], this);

                        tag.AddLoggerFactory(LoggerFactory);

                        //tag.NewValueReached += TagOnNewValueReached;
                        //_tagList.Add(tag);
                        Tags.Add(tag); //Important
                        //_tagDictionary.Add(tag.Name, tag);
                        if (tag.InputOutput.Equals("R") || tag.InputOutput.Equals("RW"))
                        {

                        }

                        if(_tagByConnection.ContainsKey(connectionName))
                        {
                            _tagByConnection[connectionName].Add(tag);
                        }
                        else
                        {
                            _tagByConnection.Add(connectionName, new List<Tag>());
                            _tagByConnection[connectionName].Add(tag);
                        }
                    }

                    Connection[connectionName].Tags = _tagByConnection[connectionName];
                    Connection[connectionName].Initiate();
                }

                //Tags = _tagList;
            }
            catch (Exception ex)
            {
                Logger?.LogError("Domain.Entity.Common.TagGroup Initiate: " + ex.Message + " - " + ex.StackTrace);
            }

            _scheduleRead = new Scheduler(Name + "Read", Clock, Scheduler.TimeType.ms);
            StartScheduleRead<TaskRead>();
        }

        //private void TagOnNewValueReached(object sender, EventArgs e)
        //{
        //    //throw new NotImplementedException();
        //    Logger.Trace("Tag Group: TagOnNewValueReached");
        //}

        //private void InitiateEventBus()
        //{
        //    DefaultRabbitMqPersistentConnection persistentConnection = new DefaultRabbitMqPersistentConnection(_connectionFactory, Logger);
        //    var eventReadHandler = new TagEventHandler(Logger, _tagDictionary);

        //    EventBus = new EventBusRabbitMq(persistentConnection, Logger, eventReadHandler, null, "direct", "AutomationQueue_" + Name);
        //    //_eventBus = new EventBusRabbitMq(persistentConnection, Logger, eventReadHandler, null, "topic", "AutomationQueue_" + Name);

        //    EventBus.Subscribe<TagIntegrationEvent, TagEventHandler>(Name + ".automation.read");
        //    EventBus.Subscribe<TagIntegrationEvent, TagEventHandler>(Name + ".automation.write");
        //}

        private void StartScheduleRead<T>() where T : IJob
        {
            _scheduleRead.Start<T>("myJob_" + Name + "Read", this);
        }

        private void StopSchedulerRead()
        {
            _scheduleRead?.Stop();
        }

        public async Task OnSchedulerTriggerRead()
        {
            ;
            foreach (var connection in Connection)
            {
                await connection.Value.ReadTags().ConfigureAwait(false);
            }
        }

        public bool GetConnectionStatusRead(string connectionName)
        {
            var connection = GetConnection(connectionName);

            return !(connection is null) && connection.ConnectionStatusRead();
        }

        public bool GetConnectionStatusWrite(string connectionName)
        {
            var connection = GetConnection(connectionName);

            return !(connection is null) && connection.ConnectionStatusWrite();
        }

        public string GetTagValue(string tagName)
        {
            var tag = GetTag(tagName);
            if (tag is null)
            {
                Logger.LogWarning("SetTagValueAsync: " + tagName + " is null!");
                return string.Empty;
            }

            return tag.Invoke ? tag.Value : tag.ReadTagFromPlc();
        }

        public async ValueTask<string> GetTagValueAsync(string tagName)
        {
            var tag = GetTag(tagName);
            if (tag is null)
            {
                Logger.LogWarning("SetTagValueAsync: " + tagName + " is null!");
                return string.Empty;
            }

            if (tag.Invoke)
            {
                return tag.Value;
            }

            return await tag.ReadTagFromPlcAsync().ConfigureAwait(false); //ToDo

        }

        public bool SetTagValue(string tagName, string value)
        {
            var tag = GetTag(tagName);

            if (tag is null)
            {
                Logger.LogWarning("SetTagValueAsync: " + tagName + " is null!");
                return false;
            }

            return tag.WriteTagToPlc(value);
        }

        public async ValueTask<bool> SetTagValueAsync(string tagName, string value)
        {
            var tag = GetTag(tagName);
            //tag.SetWriteValue(value);
            if (tag is null)
            {
                Logger.LogWarning("SetTagValueAsync: " + tagName + " is null!");
                return false;
            }

            return await tag.WriteTagToPlcAsync(value).ConfigureAwait(false);
        }

        public Tag GetTag(string tagName)
        {
            try
            {
                return Tags.SingleOrDefault(tagItem => tagItem.Name.Equals(tagName));
            }
            catch (Exception ex)
            {
                Logger.LogError("GetTag: " + ex.Message + " " + ex.StackTrace);
                return null;
            }
        }

        public Connection GetConnection(string connectionName)
        {
            return Connection.ContainsKey(connectionName) ? Connection[connectionName] : null;
        }

        //[DisallowConcurrentExecution]
        //private class TaskRead : IJob
        //{
        //    #region [Private]
        //    private SchedulerContext _sc;
        //    private TagGroup _tagGroup;
        //    private string _name = string.Empty;
        //    #endregion

        //    public Task Execute(IJobExecutionContext context)
        //    {
        //        //var key = context.JobDetail.Key;
        //        //var dataMap = context.JobDetail.JobDataMap;

        //        _sc = context.Scheduler.Context;
        //        _name = context.JobDetail.Key.Name;

        //        _tagGroup = (TagGroup)_sc.Get(_name); //(S7GROUP)_sc.Get(_name);

        //        //_s7Group.Logger.Trace("S7TaskRead");
        //        //s7group.OnTrigger();
        //        return _tagGroup.OnSchedulerTriggerRead();

        //        //return Task.CompletedTask;
        //    }
        //}//Task
    }
}
