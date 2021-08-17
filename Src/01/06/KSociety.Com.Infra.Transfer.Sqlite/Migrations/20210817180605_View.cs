using KSociety.Base.Infra.Shared.Class;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Reflection;

namespace KSociety.Com.Infra.Transfer.Sqlite.Migrations
{
    public partial class View : Migration
    {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
