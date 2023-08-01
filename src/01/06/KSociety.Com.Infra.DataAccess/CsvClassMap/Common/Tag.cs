using CsvHelper.Configuration;

namespace KSociety.Com.Infra.DataAccess.CsvClassMap.Common;

public sealed class Tag : ClassMap<Domain.Entity.Common.Tag>
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
    }
}