using System;
using KSociety.Base.Domain.Shared.Class;
using KSociety.Base.InfraSub.Shared.Interface;
using KSociety.Com.Domain.Entity.Common;

namespace KSociety.Com.Domain.Entity.View.Joined
{
    public class AllTagGroupAllConnection : BaseEntityNotifier
    {
        #region [Propery]

        public Guid Id { get; private set; }

        public string TagName { get; private set; }

        public Guid ConnectionId { get; private set; }

        public string ConnectionName { get; private set; }

        public int AutomationTypeId { get; private set; }

        public string AutomationName { get; private set; }

        public string Ip { get; private set; }

        public bool WriteEnable { get; private set; }

        public string InputOutput { get; private set; }

        public string AnalogDigitalSignal { get; private set; }

        public string MemoryAddress { get; private set; }

        public bool Invoke { get; private set; }

        public Guid TagGroupId { get; private set; }

        public string TagGroupName { get; private set; }

        public int Clock { get; private set; }

        public int Update { get; private set; }

        public int DataBlock { get; private set; }

        public int Offset { get; private set; }

        public byte BitOfByte { get; private set; }

        public int WordLenId { get; private set; }

        public string WordLenName { get; private set; }

        public int AreaId { get; private set; }

        public string AreaName { get; private set; }

        public int StringLength { get; private set; }

        public int ConnectionTypeId { get; private set; }

        public string ConnectionTypeName { get; private set; }

        public int CpuTypeId { get; private set; }

        public string CpuTypeName { get; private set; }

        public short Rack { get; private set; }

        public short Slot { get; private set; }

        public byte[] Path { get; private set; }

        #endregion

        public AllTagGroupAllConnection(
            Guid id,
            string tagName,
            Guid connectionId,
            string connectionName,
            int automationTypeId,
            string automationName,
            string ip,
            bool writeEnable,
            string inputOutput,
            string analogDigitalSignal,
            string memoryAddress,
            bool invoke,
            Guid tagGroupId,
            string tagGroupName,
            int clock,
            int update,
            int dataBlock,
            int offset,
            byte bitOfByte,
            int wordLenId,
            string wordLenName,
            int areaId,
            string areaName,
            int stringLength,
            int connectionTypeId,
            string connectionTypeName,
            int cpuTypeId,
            string cpuTypeName,
            short rack,
            short slot,
            byte[] path
        ) 
        {
            Id = id;
            TagName = tagName;
            ConnectionId = connectionId;
            ConnectionName = connectionName;
            AutomationTypeId = automationTypeId;
            AutomationName = automationName;
            Ip = ip;
            WriteEnable = writeEnable;
            InputOutput = inputOutput;
            AnalogDigitalSignal = analogDigitalSignal;
            MemoryAddress = memoryAddress;
            Invoke = invoke;
            TagGroupId = tagGroupId;
            TagGroupName = tagGroupName;
            Clock = clock;
            Update = update;
            DataBlock = dataBlock;
            Offset = offset;
            BitOfByte = bitOfByte;
            MemoryAddress = memoryAddress;
            WordLenId = wordLenId;
            WordLenName = wordLenName;
            AreaId = areaId;
            AreaName = areaName;
            StringLength = stringLength;
            ConnectionTypeId = connectionTypeId;
            ConnectionTypeName = connectionTypeName;
            CpuTypeId = cpuTypeId;
            CpuTypeName = cpuTypeName;
            Rack = rack;
            Slot = slot;
            Path = path;
        }

        public void Initiate()
        {

        }

        public AllConnection GetAllConnection()
        {
            return new AllConnection(
                ConnectionId,
                AutomationTypeId,
                AutomationName,
                ConnectionName,
                Ip,
                WriteEnable,
                Path,
                CpuTypeId,
                CpuTypeName,
                Rack,
                Slot,
                ConnectionTypeId,
                ConnectionTypeName

            );
        }

        public AllTagGroupConnection GetAllTagGroupConnection()
        {
            return new AllTagGroupConnection(
                Id,
                TagName,
                ConnectionId,
                ConnectionName,
                AutomationTypeId,
                AutomationName,
                Ip,
                WriteEnable,
                InputOutput,
                AnalogDigitalSignal,
                Invoke,
                TagGroupId,
                TagGroupName,
                Clock,
                Update,
                DataBlock,
                Offset,
                BitOfByte,
                MemoryAddress,
                WordLenId,
                WordLenName,
                AreaId,
                AreaName,
                StringLength
            );
        }

        public Entity.Common.TagGroup GetTagGroup()
        {
            return new Entity.Common.TagGroup(
                TagGroupId,
                TagGroupName,
                Clock,
                Update,
                true
            );
        }

        public Entity.Common.Connection GetCommonConnection()
        {

            try
            {
                switch (AutomationTypeId)
                {

                    case 1:
                        return GetS7Connection();

                    case 2:
                        return GetLogixConnection();

                    default:
                        return null;
                }
            }
            catch (Exception ex)
            {
                //Logger.LogError("Domain.Entity.View.Joined.AllTagGroupAllConnection GetCommonConnection: " + ex.Message + " - " + ex.StackTrace);
                return null;
            }
        }

        public Entity.S7.S7Connection GetS7Connection()
        {
            return new S7.S7Connection(
                ConnectionId,
                AutomationTypeId,
                ConnectionName,
                Ip,
                true,
                WriteEnable,
                CpuTypeId,
                Rack,
                Slot,
                ConnectionTypeId
            );
        }

        public Entity.Logix.LogixConnection GetLogixConnection()
        {
            return null;
        }

        public Entity.Common.Tag GetCommonTag(INotifierMediatorService notifierMediatorService,
            Connection connection, TagGroup tagGroup)
        {
            try
            {
                switch (AutomationTypeId)
                {
                    case 0:
                        return new Tag(
                            notifierMediatorService,
                            Id,
                            AutomationTypeId,
                            TagName,
                            ConnectionId,
                            connection,
                            true,
                            InputOutput,
                            AnalogDigitalSignal,
                            MemoryAddress,
                            Invoke,
                            TagGroupId,
                            tagGroup
                        );

                    case 1:
                        return new Entity.S7.S7Tag(
                            notifierMediatorService,
                            Id,
                            AutomationTypeId,
                            TagName,
                            ConnectionId,
                            connection,
                            true,
                            InputOutput,
                            AnalogDigitalSignal,
                            MemoryAddress,
                            Invoke,
                            TagGroupId,
                            tagGroup,
                            DataBlock,
                            Offset,
                            BitOfByte,
                            WordLenId,
                            AreaId,
                            StringLength
                        );

                    //case 2:
                    //    break;


                    default:
                        return new Entity.Common.Tag(
                            notifierMediatorService,
                            Id,
                            AutomationTypeId,
                            TagName,
                            ConnectionId,
                            connection,
                            true,
                            InputOutput,
                            AnalogDigitalSignal,
                            MemoryAddress,
                            Invoke,
                            TagGroupId,
                            tagGroup
                        );
                }
            }
            catch (Exception ex)
            {
                //Logger.LogError("Domain.Entity.View.Joined.AllTagGroupAllConnection GetCommonTag: " + ex.Message + " - " + ex.StackTrace);
                return null;
            }
        }
    }
}