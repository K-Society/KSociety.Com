using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KSociety.Com.Infra.Transfer.MySql.Migrations
{
    /// <inheritdoc />
    public partial class ComDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AnalogDigital",
                columns: table => new
                {
                    AnalogDigitalSignal = table.Column<string>(type: "varchar(7)", maxLength: 7, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalogDigital", x => x.AnalogDigitalSignal);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AutomationType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mean = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutomationType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Bit",
                columns: table => new
                {
                    BitOfByte = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    BitName = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bit", x => x.BitOfByte);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "InOut",
                columns: table => new
                {
                    InputOutput = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InputOutputName = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InOut", x => x.InputOutput);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "S7Area",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AreaName = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mean = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_S7Area", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "S7ConnectionType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_S7ConnectionType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "S7CpuType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CpuTypeName = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mean = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_S7CpuType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "S7WordLen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    WordLenName = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mean = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_S7WordLen", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TagGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Clock = table.Column<int>(type: "int", nullable: false),
                    Update = table.Column<int>(type: "int", nullable: false),
                    Enable = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagGroup", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Connection",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AutomationTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ip = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Enable = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    WriteEnable = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Path = table.Column<byte[]>(type: "varbinary(3)", maxLength: 3, nullable: true, defaultValue: new byte[] { 0, 0, 0 }),
                    CpuTypeId = table.Column<int>(type: "int", nullable: true),
                    Rack = table.Column<short>(type: "smallint", nullable: true, defaultValue: (short)0),
                    Slot = table.Column<short>(type: "smallint", nullable: true, defaultValue: (short)0),
                    ConnectionTypeId = table.Column<int>(type: "int", nullable: true),
                    Port = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connection", x => x.Id);
                    table.ForeignKey(
                        name: "ForeignKey_Connection_AutomationType",
                        column: x => x.AutomationTypeId,
                        principalTable: "AutomationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ForeignKey_S7Connection_S7ConnectionType",
                        column: x => x.ConnectionTypeId,
                        principalTable: "S7ConnectionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "ForeignKey_S7Connection_S7CpuType",
                        column: x => x.CpuTypeId,
                        principalTable: "S7CpuType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "S7BlockArea",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DataBlock = table.Column<int>(type: "int", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    WordLenId = table.Column<int>(type: "int", nullable: false),
                    Start = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Enable = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConnectionId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_S7BlockArea", x => x.Id);
                    table.ForeignKey(
                        name: "FK_S7BlockArea_Connection_ConnectionId",
                        column: x => x.ConnectionId,
                        principalTable: "Connection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "ForeignKey_S7BlockArea_Area",
                        column: x => x.AreaId,
                        principalTable: "S7Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "ForeignKey_S7BlockArea_WordLen",
                        column: x => x.WordLenId,
                        principalTable: "S7WordLen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AutomationTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConnectionId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Enable = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    InputOutput = table.Column<string>(type: "varchar(2)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AnalogDigitalSignal = table.Column<string>(type: "varchar(7)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MemoryAddress = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Invoke = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TagGroupId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DataBlock = table.Column<int>(type: "int", nullable: true),
                    Offset = table.Column<int>(type: "int", nullable: true),
                    BitOfByte = table.Column<byte>(type: "tinyint unsigned", nullable: true),
                    WordLenId = table.Column<int>(type: "int", nullable: true),
                    AreaId = table.Column<int>(type: "int", nullable: true),
                    StringLength = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                    table.ForeignKey(
                        name: "ForeignKey_S7Tag_Area",
                        column: x => x.AreaId,
                        principalTable: "S7Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "ForeignKey_S7Tag_Bit",
                        column: x => x.BitOfByte,
                        principalTable: "Bit",
                        principalColumn: "BitOfByte");
                    table.ForeignKey(
                        name: "ForeignKey_S7Tag_WordLen",
                        column: x => x.WordLenId,
                        principalTable: "S7WordLen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "ForeignKey_Tag_AnalogDigital",
                        column: x => x.AnalogDigitalSignal,
                        principalTable: "AnalogDigital",
                        principalColumn: "AnalogDigitalSignal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "ForeignKey_Tag_AutomationType",
                        column: x => x.AutomationTypeId,
                        principalTable: "AutomationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ForeignKey_Tag_ConnectionId",
                        column: x => x.ConnectionId,
                        principalTable: "Connection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "ForeignKey_Tag_InOut",
                        column: x => x.InputOutput,
                        principalTable: "InOut",
                        principalColumn: "InputOutput",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "ForeignKey_Tag_TagGroup",
                        column: x => x.TagGroupId,
                        principalTable: "TagGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AnalogDigital",
                column: "AnalogDigitalSignal",
                values: new object[]
                {
                    "Analog",
                    "Digital"
                });

            migrationBuilder.InsertData(
                table: "AutomationType",
                columns: new[] { "Id", "Mean", "Name" },
                values: new object[,]
                {
                    { 0, "Base", "Base" },
                    { 1, "Siemens", "Siemens" },
                    { 2, "Logix", "Logix" },
                    { 3, "Modbus", "Modbus" },
                    { 4, "Generic TCP", "Tcp" }
                });

            migrationBuilder.InsertData(
                table: "Bit",
                columns: new[] { "BitOfByte", "BitName" },
                values: new object[,]
                {
                    { (byte)0, "Bit 0" },
                    { (byte)1, "Bit 1" },
                    { (byte)2, "Bit 2" },
                    { (byte)3, "Bit 3" },
                    { (byte)4, "Bit 4" },
                    { (byte)5, "Bit 5" },
                    { (byte)6, "Bit 6" },
                    { (byte)7, "Bit 7" }
                });

            migrationBuilder.InsertData(
                table: "InOut",
                columns: new[] { "InputOutput", "InputOutputName" },
                values: new object[,]
                {
                    { "R", "Read" },
                    { "RW", "Read/Write" },
                    { "U", "Unknown" },
                    { "W", "Write" }
                });

            migrationBuilder.InsertData(
                table: "S7Area",
                columns: new[] { "Id", "AreaName", "Mean" },
                values: new object[,]
                {
                    { 28, "S7AreaCT", "Counter area memory (C1, C2, ...)" },
                    { 29, "S7AreaTM", "Timer area memory(T1, T2, ...)" },
                    { 129, "S7AreaPE", "Input area memory" },
                    { 130, "S7AreaPA", "Output area memory" },
                    { 131, "S7AreaMK", "Merkers area memory (M0, M0.0, ...)" },
                    { 132, "S7AreaDB", "DB area memory (DB1, DB2, ...)" }
                });

            migrationBuilder.InsertData(
                table: "S7ConnectionType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "PG" },
                    { 2, "OP" },
                    { 3, "S7Basic 1" },
                    { 4, "S7Basic 2" },
                    { 5, "S7Basic 3" },
                    { 6, "S7Basic 4" },
                    { 7, "S7Basic 5" },
                    { 8, "S7Basic 6" },
                    { 9, "S7Basic 7" },
                    { 10, "S7Basic 8" }
                });

            migrationBuilder.InsertData(
                table: "S7CpuType",
                columns: new[] { "Id", "CpuTypeName", "Mean" },
                values: new object[,]
                {
                    { 0, "S7-200", "S7 200 cpu type" },
                    { 1, "Logo0BA8", "Siemens Logo 0BA8 cpu type" },
                    { 10, "S7-300", "S7 300 cpu type" },
                    { 20, "S7-400", "S7 400 cpu type" },
                    { 30, "S7-1200", "S7 1200 cpu type" },
                    { 40, "S7-1500", "S7 1500 cpu type" }
                });

            migrationBuilder.InsertData(
                table: "S7WordLen",
                columns: new[] { "Id", "Mean", "WordLenName" },
                values: new object[,]
                {
                    { 0, "S7 Bit variable type (bool)", "Bit" },
                    { 1, "S7 Byte variable type (8 bits)", "Byte" },
                    { 2, "S7 Word variable type (16 bits, 2 bytes)", "Word" },
                    { 3, "S7 DWord variable type (32 bits, 4 bytes)", "Dword" },
                    { 4, "S7 Int variable type (16 bits, 2 bytes)", "Int" },
                    { 5, "DInt variable type (32 bits, 4 bytes)", "DInt" },
                    { 6, "Real variable type (32 bits, 4 bytes)", "Real" },
                    { 7, "LReal variable type (64 bits, 8 bytes)", "LReal" },
                    { 8, "Char Array / C-String variable type (variable)", "String" },
                    { 9, "S7 String variable type (variable)", "S7String" },
                    { 10, "S7 WString variable type (variable)", "S7WString" },
                    { 11, "Timer variable type", "Timer" },
                    { 12, "Counter variable type", "Counter" },
                    { 13, "DateTime variable type", "DataTime" },
                    { 14, "DateTimeLong variable type", "DataTimeLong" }
                });

            migrationBuilder.InsertData(
                table: "TagGroup",
                columns: new[] { "Id", "Clock", "Enable", "Name", "Update" },
                values: new object[,]
                {
                    { new Guid("0f62b113-dd0d-4fcf-9ed9-9ae0acd1b092"), 47, true, "CbGroup", 47 },
                    { new Guid("a87832e1-f49b-4a3f-bfbe-7df80d9a7cb2"), 10, false, "Group 01", 10 }
                });

            migrationBuilder.InsertData(
                table: "Connection",
                columns: new[] { "Id", "AutomationTypeId", "ConnectionTypeId", "CpuTypeId", "Enable", "Ip", "Name", "Rack", "Slot", "WriteEnable" },
                values: new object[,]
                {
                    { new Guid("fb6f381e-7bf4-4814-df23-08d6a214e1de"), 1, 3, 40, true, "192.168.0.201", "Plc1", (short)0, (short)1, true },
                    { new Guid("fc9967e6-32b9-4077-a018-dce37c857eff"), 1, 3, 40, true, "172.16.8.205", "CbPlc", (short)0, (short)1, true }
                });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "AnalogDigitalSignal", "AreaId", "AutomationTypeId", "BitOfByte", "ConnectionId", "DataBlock", "Enable", "InputOutput", "Invoke", "MemoryAddress", "Name", "Offset", "StringLength", "TagGroupId", "WordLenId" },
                values: new object[,]
                {
                    { new Guid("0d754a9d-1389-4f04-0bd4-08d6ad638d40"), "Analog", 132, 1, (byte)0, new Guid("fb6f381e-7bf4-4814-df23-08d6a214e1de"), 10, true, "R", true, "DB10.DBW4", "Tag03", 4, 1, new Guid("a87832e1-f49b-4a3f-bfbe-7df80d9a7cb2"), 2 },
                    { new Guid("49d37f56-c1b7-40d7-35aa-08d6b1da6471"), "Analog", 132, 1, (byte)0, new Guid("fb6f381e-7bf4-4814-df23-08d6a214e1de"), 10, true, "R", true, "DB10.DBW10", "Tag06", 10, 1, new Guid("a87832e1-f49b-4a3f-bfbe-7df80d9a7cb2"), 2 },
                    { new Guid("58315735-142d-4a20-3b5e-08d6b0418047"), "Analog", 132, 1, (byte)0, new Guid("fb6f381e-7bf4-4814-df23-08d6a214e1de"), 10, true, "R", true, "DB10.DBW6", "Tag04", 6, 1, new Guid("a87832e1-f49b-4a3f-bfbe-7df80d9a7cb2"), 2 },
                    { new Guid("a0412d18-59df-40e3-35a9-08d6b1da6471"), "Analog", 132, 1, (byte)0, new Guid("fb6f381e-7bf4-4814-df23-08d6a214e1de"), 10, true, "R", true, "DB10.DBW8", "Tag05", 8, 1, new Guid("a87832e1-f49b-4a3f-bfbe-7df80d9a7cb2"), 2 },
                    { new Guid("b12ab89c-9d46-409c-0bd3-08d6ad638d40"), "Analog", 132, 1, (byte)0, new Guid("fb6f381e-7bf4-4814-df23-08d6a214e1de"), 10, true, "R", true, "DB10.DBW0", "Tag01", 0, 1, new Guid("a87832e1-f49b-4a3f-bfbe-7df80d9a7cb2"), 2 },
                    { new Guid("d12d5401-a90f-40a4-3b5d-08d6b0418047"), "Analog", 132, 1, (byte)0, new Guid("fb6f381e-7bf4-4814-df23-08d6a214e1de"), 10, true, "R", true, "DB10.DBW2", "Tag02", 2, 1, new Guid("a87832e1-f49b-4a3f-bfbe-7df80d9a7cb2"), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutomationType_Name",
                table: "AutomationType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bit_BitName",
                table: "Bit",
                column: "BitName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Connection_AutomationTypeId",
                table: "Connection",
                column: "AutomationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Connection_ConnectionTypeId",
                table: "Connection",
                column: "ConnectionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Connection_CpuTypeId",
                table: "Connection",
                column: "CpuTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Connection_Name_AutomationTypeId",
                table: "Connection",
                columns: new[] { "Name", "AutomationTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InOut_InputOutputName",
                table: "InOut",
                column: "InputOutputName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_S7Area_AreaName",
                table: "S7Area",
                column: "AreaName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_S7BlockArea_AreaId",
                table: "S7BlockArea",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_S7BlockArea_ConnectionId",
                table: "S7BlockArea",
                column: "ConnectionId");

            migrationBuilder.CreateIndex(
                name: "IX_S7BlockArea_Name",
                table: "S7BlockArea",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_S7BlockArea_WordLenId",
                table: "S7BlockArea",
                column: "WordLenId");

            migrationBuilder.CreateIndex(
                name: "IX_S7ConnectionType_Name",
                table: "S7ConnectionType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_S7CpuType_CpuTypeName",
                table: "S7CpuType",
                column: "CpuTypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_S7WordLen_WordLenName",
                table: "S7WordLen",
                column: "WordLenName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tag_AnalogDigitalSignal",
                table: "Tag",
                column: "AnalogDigitalSignal");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_AreaId",
                table: "Tag",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_AutomationTypeId",
                table: "Tag",
                column: "AutomationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_BitOfByte",
                table: "Tag",
                column: "BitOfByte");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_ConnectionId",
                table: "Tag",
                column: "ConnectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_InputOutput",
                table: "Tag",
                column: "InputOutput");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_Name_AutomationTypeId",
                table: "Tag",
                columns: new[] { "Name", "AutomationTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tag_TagGroupId",
                table: "Tag",
                column: "TagGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_WordLenId",
                table: "Tag",
                column: "WordLenId");

            migrationBuilder.CreateIndex(
                name: "IX_TagGroup_Name",
                table: "TagGroup",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "S7BlockArea");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "S7Area");

            migrationBuilder.DropTable(
                name: "Bit");

            migrationBuilder.DropTable(
                name: "S7WordLen");

            migrationBuilder.DropTable(
                name: "AnalogDigital");

            migrationBuilder.DropTable(
                name: "Connection");

            migrationBuilder.DropTable(
                name: "InOut");

            migrationBuilder.DropTable(
                name: "TagGroup");

            migrationBuilder.DropTable(
                name: "AutomationType");

            migrationBuilder.DropTable(
                name: "S7ConnectionType");

            migrationBuilder.DropTable(
                name: "S7CpuType");
        }
    }
}
