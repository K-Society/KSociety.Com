using KSociety.Com.Infra.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace KSociety.Com.Infra.Transfer.SqlServer
{
    public class SqlServerComContext : ComContext
    {
        public SqlServerComContext(DbContextOptions<SqlServerComContext> options)
            : base(options)
        {

        }
    }
}
