using KSociety.Base.Infra.Shared.Class;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace KSociety.Com.Infra.Transfer.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class View : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            try
            {
                migrationBuilder.CreateViewFromSql(DataAccess.Global.AssemblyName, "TagReadyView");

                migrationBuilder.CreateViewFromSql(DataAccess.Global.AssemblyName, "TagGroupReadyView");

                migrationBuilder.CreateViewFromSql(DataAccess.Global.AssemblyName, "ConnectionReadyView");

                migrationBuilder.CreateViewFromSql(DataAccess.Global.AssemblyName, "ConnectionAutomationView");

                migrationBuilder.CreateViewFromSql(DataAccess.Global.AssemblyName, "TagConnectionView");

                migrationBuilder.CreateViewFromSql(DataAccess.Global.AssemblyName, "TagGroupConnectionView");

                migrationBuilder.CreateViewFromSql(DataAccess.Global.AssemblyName, "AllConnectionView");

                migrationBuilder.CreateViewFromSql(DataAccess.Global.AssemblyName, "AllTagGroupConnectionView");

                migrationBuilder.CreateViewFromSql(DataAccess.Global.AssemblyName, "AllTagGroupAllConnectionView");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
