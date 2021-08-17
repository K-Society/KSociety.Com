using KSociety.Com.Infra.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace KSociety.Com.Infra.Transfer.Sqlite
{
    public class SqliteComContext : ComContext
    {
        public SqliteComContext(DbContextOptions<SqliteComContext> options)
            : base(options)
        {

        }
    }
}
