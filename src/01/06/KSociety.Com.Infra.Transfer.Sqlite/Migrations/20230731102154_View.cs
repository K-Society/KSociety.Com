using KSociety.Base.Infra.Shared.Class;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KSociety.Com.Infra.Transfer.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class View : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateViewFromSql(DataAccess.Global.SqliteAssemblyName, "TagReadyView");

            migrationBuilder.CreateViewFromSql(DataAccess.Global.SqliteAssemblyName, "TagGroupReadyView");

            migrationBuilder.CreateViewFromSql(DataAccess.Global.SqliteAssemblyName, "ConnectionReadyView");

            migrationBuilder.CreateViewFromSql(DataAccess.Global.SqliteAssemblyName, "ConnectionAutomationView");

            migrationBuilder.CreateViewFromSql(DataAccess.Global.SqliteAssemblyName, "TagConnectionView");

            migrationBuilder.CreateViewFromSql(DataAccess.Global.SqliteAssemblyName, "TagGroupConnectionView");

            migrationBuilder.CreateViewFromSql(DataAccess.Global.SqliteAssemblyName, "AllConnectionView");

            migrationBuilder.CreateViewFromSql(DataAccess.Global.SqliteAssemblyName, "AllTagGroupConnectionView");

            migrationBuilder.CreateViewFromSql(DataAccess.Global.SqliteAssemblyName, "AllTagGroupAllConnectionView");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
