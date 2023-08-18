using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.Domain.Entity.Common
{
    public class Connection : Base.Domain.Shared.Class.Entity
    {
        #region [Propery]

        public Guid Id { get; protected set; }

        public int AutomationTypeId { get; protected set; }
        public virtual AutomationType AutomationType { get; protected set; }

        public string Name { get; protected set; }

        public string Ip { get; protected set; }

        public bool Enable { get; protected set; }

        public bool WriteEnable { get; protected set; }

        public virtual ICollection<Tag> Tags { get; set; }

        #endregion

        public static SemaphoreSlim ReadSemaphore { get; } = new SemaphoreSlim(1, 1);
        public static SemaphoreSlim WriteSemaphore { get; } = new SemaphoreSlim(1, 1);


        #region [Constructor]


        public Connection()
        {

        }

        public Connection(
                int automationTypeId,
                string name,
                string ip,
                bool enable,
                bool writeEnable
            )
        {
            AutomationTypeId = automationTypeId;
            Name = name;
            Ip = ip;
            Enable = enable;
            WriteEnable = writeEnable;
        }

        public Connection(
                Guid id,
                int automationTypeId,
                string name,
                string ip,
                bool enable,
                bool writeEnable
            )
        {
            Id = id;
            AutomationTypeId = automationTypeId;
            Name = name;
            Ip = ip;
            Enable = enable;
            WriteEnable = writeEnable;
        }

        public Connection(
                Guid connectionId,
                int automationTypeId,
                string name,
                string ip,
                bool enable,
                bool writeEnable,
                S7.S7Connection connection
            )
        {
            Id = connectionId;
            AutomationTypeId = automationTypeId;
            Name = name;
            Ip = ip;
            Enable = enable;
            WriteEnable = writeEnable;
        }

        public Connection(
                Guid connectionId,
                int automationTypeId,
                string name,
                string ip,
                bool enable,
                bool writeEnable,
                Logix.LogixConnection connection
            )
        {
            Id = connectionId;
            AutomationTypeId = automationTypeId;
            Name = name;
            Ip = ip;
            Enable = enable;
            WriteEnable = writeEnable;
        }

        #endregion

        public virtual void Initiate()
        {
            //switch (AutomationTypeId)
            //{
            //    case 0:
            //        //S7Connection?.Initiate(this);
            //        break;

            //    case 1:
            //        break;
            //}
        }

        public virtual ValueTask ReadTags()
        {
            return default;
        }

        public virtual bool ConnectionStatusRead()
        {
            return false;
        }

        public virtual bool ConnectionStatusWrite()
        {
            return false;
        }

        protected override void DisposeManagedResources()
        {
            ReadSemaphore.Dispose();
            WriteSemaphore.Dispose();
        }
    }
}