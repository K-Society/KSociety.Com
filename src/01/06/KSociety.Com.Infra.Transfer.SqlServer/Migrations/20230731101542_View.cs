using KSociety.Base.Infra.Shared.Class;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KSociety.Com.Infra.Transfer.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class View : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateViewFromSql(DataAccess.Global.SqlServerAssemblyName, "TagReadyView");

            migrationBuilder.CreateViewFromSql(DataAccess.Global.SqlServerAssemblyName, "TagGroupReadyView");

            migrationBuilder.CreateViewFromSql(DataAccess.Global.SqlServerAssemblyName, "ConnectionReadyView");

            migrationBuilder.CreateViewFromSql(DataAccess.Global.SqlServerAssemblyName, "ConnectionAutomationView");

            migrationBuilder.CreateViewFromSql(DataAccess.Global.SqlServerAssemblyName, "TagConnectionView");

            migrationBuilder.CreateViewFromSql(DataAccess.Global.SqlServerAssemblyName, "TagGroupConnectionView");

            migrationBuilder.CreateViewFromSql(DataAccess.Global.SqlServerAssemblyName, "AllConnectionView");

            migrationBuilder.CreateViewFromSql(DataAccess.Global.SqlServerAssemblyName, "AllTagGroupConnectionView");

            migrationBuilder.CreateViewFromSql(DataAccess.Global.SqlServerAssemblyName, "AllTagGroupAllConnectionView");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
