using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.Domain.Entity.Common
{
    public class Connection : Base.Domain.Shared.Class.Entity
    {
        #region [Propery]
        //public Guid ConnectionId { get; protected set; }
        public Guid Id { get; protected set; }

        public int AutomationTypeId { get; protected set; }
        public virtual AutomationType AutomationType { get; protected set; }

        public string Name { get; protected set; }

        public string Ip { get; protected set; }

        public bool Enable { get; protected set; }

        public bool WriteEnable { get; protected set; }

        //public virtual S7.Connection S7Connection { get; private set; }
        //public virtual Logix.Connection LogixConnection { get; private set; }
        public virtual ICollection<Tag> Tags { get; set; }
        #endregion

        public static SemaphoreSlim ReadSemaphore { get; } = new(1, 1);
        public static SemaphoreSlim WriteSemaphore { get; } = new(1, 1);

        //public Connection()
        //    : base(LogManager.GetCurrentClassLogger())
        //{

        //}

        #region [Constructor]
        //public Connection()
        //:base()
        //{

        //}

        public Connection(/*ILogger<Connection> logger*/)
            //: base(logger)
        {

        }

        //public Connection(
        //    //ILogger<Connection> logger,
        //    int automationTypeId,
        //    string name,
        //    string ip,
        //    bool enable,
        //    bool writeEnable
        //)
        //    : base(/*LogManager.GetCurrentClassLogger()*/)
        //{
        //    AutomationTypeId = automationTypeId;
        //    Name = name;
        //    Ip = ip;
        //    Enable = enable;
        //    WriteEnable = writeEnable;
        //}

        public Connection(
            //ILogger<Connection> logger,
            int automationTypeId,
            string name,
            string ip,
            bool enable,
            bool writeEnable
        )
        //:base(logger)
        {
            AutomationTypeId = automationTypeId;
            Name = name;
            Ip = ip;
            Enable = enable;
            WriteEnable = writeEnable;
        }

        public Connection(
            //Guid connectionId,
            Guid id,
            int automationTypeId,
            string name,
            string ip,
            bool enable,
            bool writeEnable
        )
            //: base(new ILogger<Connection>())
        {
            Id = id;
            AutomationTypeId = automationTypeId;
            Name = name;
            Ip = ip;
            Enable = enable;
            WriteEnable = writeEnable;
        }

        //public Connection(
        //    //ILogger<Connection> logger,
        //    Guid id,
        //    int automationTypeId,
        //    string name,
        //    string ip,
        //    bool enable,
        //    bool writeEnable
        //)
        ////:base(logger)
        //{
        //    Id = id;
        //    AutomationTypeId = automationTypeId;
        //    Name = name;
        //    Ip = ip;
        //    Enable = enable;
        //    WriteEnable = writeEnable;
        //}

        public Connection(
            //ILogger logger,
            Guid connectionId,
            int automationTypeId,
            string name,
            string ip,
            bool enable,
            bool writeEnable,
            S7.S7Connection connection
        )
            //: base(LogManager.GetCurrentClassLogger())
        {
            Id = connectionId;
            AutomationTypeId = automationTypeId;
            Name = name;
            Ip = ip;
            Enable = enable;
            WriteEnable = writeEnable;
            //S7Connection = connection;
        }

        public Connection(
            //ILogger logger,
            Guid connectionId,
            int automationTypeId,
            string name,
            string ip,
            bool enable,
            bool writeEnable,
            Logix.LogixConnection connection
        )
        //: base(LogManager.GetCurrentClassLogger())
        {
            Id = connectionId;
            AutomationTypeId = automationTypeId;
            Name = name;
            Ip = ip;
            Enable = enable;
            WriteEnable = writeEnable;
            //LogixConnection = connection;
        }

        //public void SetS7Connection(S7.S7Connection connection)
        //{
        //    //S7Connection = connection;
        //}

        //public void SetLogixConnection(Logix.LogixConnection connection)
        //{
        //    //LogixConnection = connection;
        //}

        //public abstract void Initiate();

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

        //public async Task ReadTags()
        //{
        //    switch (AutomationTypeId)
        //    {
        //        case 0:
        //            //await S7Connection.ReadTags();
        //            break;

        //        case 1:
        //            break;
        //    }
        //}

        protected override void DisposeManagedResources()
        {
            ReadSemaphore.Dispose();
            WriteSemaphore.Dispose();
        }
    }
}
