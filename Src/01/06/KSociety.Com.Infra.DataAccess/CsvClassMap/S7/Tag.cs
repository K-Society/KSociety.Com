using CsvHelper.Configuration;
using KSociety.Com.Domain.Entity.S7;

namespace KSociety.Com.Infra.DataAccess.CsvClassMap.S7
{
    public sealed class Tag : ClassMap<S7Tag>
    {
        public Tag()
        {
            Map(map => map.Id);
            Map(map => map.AutomationTypeId);
            Map(map => map.Name);
            Map(map => map.ConnectionId);
            Map(map => map.Enable);
            Map(map => map.InputOutput);
            Map(map => map.AnalogDigitalSignal);
            Map(map => map.MemoryAddress);
            Map(map => map.Invoke);
            Map(map => map.TagGroupId);
            Map(map => map.DataBlock);
            Map(map => map.Offset);
            Map(map => map.BitOfByte);
            Map(map => map.WordLenId);
            Map(map => map.AreaId);
            Map(map => map.StringLength);
        }
    }
}
