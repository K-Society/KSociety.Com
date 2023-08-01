using CsvHelper.Configuration;

namespace KSociety.Com.Infra.DataAccess.CsvClassMap.Common;

public sealed class TagGroup : ClassMap<Domain.Entity.Common.TagGroup>
{
    public TagGroup()
    {
        Map(map => map.Id);
        Map(map => map.Name);
        Map(map => map.Clock);
        Map(map => map.Update);
        Map(map => map.Enable);
    }
}