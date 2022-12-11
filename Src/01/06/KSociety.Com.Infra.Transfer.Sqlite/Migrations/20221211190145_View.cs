using KSociety.Base.Infra.Shared.Class;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Reflection;

#nullable disable

namespace KSociety.Com.Infra.Transfer.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class View : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateViewFromSql(Assembly.GetExecutingAssembly().GetName().Name, "TagReadyView");

            migrationBuilder.CreateViewFromSql(Assembly.GetExecutingAssembly().GetName().Name, "TagGroupReadyView");

            migrationBuilder.CreateViewFromSql(Assembly.GetExecutingAssembly().GetName().Name, "ConnectionReadyView");

            migrationBuilder.CreateViewFromSql(Assembly.GetExecutingAssembly().GetName().Name, "ConnectionAutomationView");

            migrationBuilder.CreateViewFromSql(Assembly.GetExecutingAssembly().GetName().Name, "TagConnectionView");

            migrationBuilder.CreateViewFromSql(Assembly.GetExecutingAssembly().GetName().Name, "TagGroupConnectionView");

            migrationBuilder.CreateViewFromSql(Assembly.GetExecutingAssembly().GetName().Name, "AllConnectionView");

            migrationBuilder.CreateViewFromSql(Assembly.GetExecutingAssembly().GetName().Name, "AllTagGroupConnectionView");

            migrationBuilder.CreateViewFromSql(Assembly.GetExecutingAssembly().GetName().Name, "AllTagGroupAllConnectionView");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
