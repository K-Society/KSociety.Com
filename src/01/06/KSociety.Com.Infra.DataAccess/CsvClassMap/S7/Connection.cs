using CsvHelper.Configuration;

namespace KSociety.Com.Infra.DataAccess.CsvClassMap.S7;

public sealed class Connection : ClassMap<Domain.Entity.S7.S7Connection>
{
    public Connection()
    {
        Map(map => map.Id);
        Map(map => map.AutomationTypeId);
        Map(map => map.Name);
        Map(map => map.Ip);
        Map(map => map.Enable);
        Map(map => map.WriteEnable);
        Map(map => map.CpuTypeId);
        Map(map => map.Rack);
        Map(map => map.Slot);
        Map(map => map.ConnectionTypeId);
    }
}