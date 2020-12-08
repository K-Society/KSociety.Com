using System;

namespace KSociety.Com.Domain.Entity.Modbus
{
    public class ModbusTag : Common.Tag
    {
        public ModbusTag(
            Guid id,
            int automationTypeId,
            string name,
            Guid connectionId,
            bool enable,
            string inputOutput,
            string analogDigitalSignal,
            string memoryAddress,
            bool invoke,
            Guid tagGroupId
            )
        :base(
            id,
            automationTypeId,
            name,
            connectionId,
            enable,
            inputOutput,
            analogDigitalSignal,
            memoryAddress,
            invoke,
            tagGroupId
            )
        {

        }
    }
}
