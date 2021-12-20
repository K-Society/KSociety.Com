using CsvHelper.Configuration;

namespace KSociety.Com.Infra.DataAccess.CsvClassMap.Common;

public sealed class Connection : ClassMap<Domain.Entity.Common.Connection>
{
    public Connection()
    {
        Map(map => map.Id);
        Map(map => map.AutomationTypeId);
        Map(map => map.Name);
        Map(map => map.Ip);
        Map(map => map.Enable);
        Map(map => map.WriteEnable);
    }
}