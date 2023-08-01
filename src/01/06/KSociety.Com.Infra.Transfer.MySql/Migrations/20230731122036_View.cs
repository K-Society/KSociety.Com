using KSociety.Base.Infra.Shared.Class;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KSociety.Com.Infra.Transfer.MySql.Migrations
{
    /// <inheritdoc />
    public partial class View : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateViewFromSql(DataAccess.Global.MySqlAssemblyName, "TagReadyView");

            migrationBuilder.CreateViewFromSql(DataAccess.Global.MySqlAssemblyName, "TagGroupReadyView");

            migrationBuilder.CreateViewFromSql(DataAccess.Global.MySqlAssemblyName, "ConnectionReadyView");

            migrationBuilder.CreateViewFromSql(DataAccess.Global.MySqlAssemblyName, "ConnectionAutomationView");

            migrationBuilder.CreateViewFromSql(DataAccess.Global.MySqlAssemblyName, "TagConnectionView");

            migrationBuilder.CreateViewFromSql(DataAccess.Global.MySqlAssemblyName, "TagGroupConnectionView");

            migrationBuilder.CreateViewFromSql(DataAccess.Global.MySqlAssemblyName, "AllConnectionView");

            migrationBuilder.CreateViewFromSql(DataAccess.Global.MySqlAssemblyName, "AllTagGroupConnectionView");

            migrationBuilder.CreateViewFromSql(DataAccess.Global.MySqlAssemblyName, "AllTagGroupAllConnectionView");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
