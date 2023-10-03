using System;
using System.Collections.Generic;
using KSociety.Base.Domain.Shared.Class;
using KSociety.Base.InfraSub.Shared.Interface;
using KSociety.Com.Domain.Entity.View.Joined;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Domain.Entity.View.Common
{
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
        {
            Id = id;
            Name = name;
            Clock = clock;
            Update = update;
        }

        public Entity.Common.TagGroup GetTagGroup( 
                INotifierMediatorService notifierMediatorService)
        {
            Logger?.LogInformation("GetTagGroup: " + Name);

            var tagGroup = new Entity.Common.TagGroup(
                notifierMediatorService,
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
    }
}