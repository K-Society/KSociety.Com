using System;
using System.Collections.Generic;
using System.Linq;
using KSociety.Base.Domain.Shared.Class;
using KSociety.Com.Domain.Entity.S7;

namespace KSociety.Com.Domain.Entity.View.Joined
{
    public class AllConnection : BaseEntity
    {
        private List<Joined.AllTagGroupAllConnection> _dataList;

        #region [Propery]

        //public Guid StdConnectionId { get; private set; }

        public Guid Id { get; private set; }

        public int AutomationTypeId { get; private set; }

        public string AutomationName { get; private set; }

        public string ConnectionName { get; private set; }

        public string Ip { get; private set; }

        public bool WriteEnable { get; private set; }

        public byte[] Path { get; private set; }

        public int CpuTypeId { get; private set; }

        public string CpuTypeName { get; private set; }

        public short Rack { get; private set; }

        public short Slot { get; private set; }

        public int ConnectionTypeId { get; private set; }

        public string ConnectionTypeName { get; private set; }

        

        #endregion

        public AllConnection(
            //Guid stdConnectionId,
            Guid id,
            int automationTypeId,
            string automationName,
            string connectionName,
            string ip,
            bool writeEnable,
            byte[] path,
            int cpuTypeId,
            string cpuTypeName, 
            short rack,
            short slot,
            int connectionTypeId,
            string connectionTypeName
            
        )
            :base(/*LogManager.GetCurrentClassLogger()*/)
        {
            //StdConnectionId = stdConnectionId;
            Id = id;
            AutomationTypeId = automationTypeId;
            AutomationName = automationName;
            ConnectionName = connectionName;
            Ip = ip;
            WriteEnable = writeEnable;
            Path = path;
            CpuTypeId = cpuTypeId;
            CpuTypeName = cpuTypeName;
            Rack = rack;
            Slot = slot;
            ConnectionTypeId = connectionTypeId;
            ConnectionTypeName = connectionTypeName;
            
        }

        public void Initiate(List<Joined.AllTagGroupAllConnection> dataList)
        {
            //Logger.LogTrace("Domain.Entity.View.Joined.AllConnection Initiate: " + ConnectionName);

            if (!dataList.Any())
            {
                //Logger.LogWarning("Domain.Entity.View.Joined.AllConnection: " + ConnectionName + " No Data!");
                return;
            }
            _dataList = dataList;

            switch (AutomationTypeId)
            {
                case 0: //Siemens
                    var s7Conn = GetS7Connection();
                    //s7Conn.Initiate();
                    break;

                case 1: //Logix
                    break;

                default:
                    break;
            }
        }

        //public Domain.Com.Entity.Common.Connection GetCommonConnection()
        //{
        //    return new Connection(
        //        //StdConnectionId,
        //        AutomationTypeId,
        //        ConnectionName,
        //        Ip,
        //        true,
        //        WriteEnable
        //        );
        //}

        public S7Connection GetS7Connection()
        {
            return new S7.S7Connection(
                AutomationTypeId,
                ConnectionName,
                Ip,
                true,
                WriteEnable,
                //ConnectionId, 
                //StdConnectionId,
                CpuTypeId,
                Rack,
                Slot,
                ConnectionTypeId 
                //GetCommonConnection()
                );
        }
    }
}
