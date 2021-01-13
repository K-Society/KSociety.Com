using CsvHelper.Configuration;
using System.Globalization;

namespace KSociety.Com.Infra.DataAccess.CsvClassMap.Logix
{
    public sealed class Tag : ClassMap<Domain.Entity.Logix.LogixTag>
    {
        public Tag()
        {
            AutoMap(CultureInfo.InvariantCulture);
        }
    }
}
