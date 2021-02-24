using KSociety.Base.Infra.Shared.Csv;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Infra.DataAccess.EntityTypeConfiguration.S7
{
    public static class ModelBuilderExtensions
    {
        public static void SeedS7(this ModelBuilder modelBuilder, ILoggerFactory loggerFactory)
        {
            modelBuilder.Entity<Domain.Entity.S7.CpuType>().HasData
            (
                new Domain.Entity.S7.CpuType(0, "S7-200", "S7 200 cpu type"),
                new Domain.Entity.S7.CpuType(1, "Logo0BA8", "Siemens Logo 0BA8 cpu type"),
                new Domain.Entity.S7.CpuType(10, "S7-300", "S7 300 cpu type"),
                new Domain.Entity.S7.CpuType(20, "S7-400", "S7 400 cpu type"),
                new Domain.Entity.S7.CpuType(30, "S7-1200", "S7 1200 cpu type"),
                new Domain.Entity.S7.CpuType(40, "S7-1500", "S7 1500 cpu type")
            );

            modelBuilder.Entity<Domain.Entity.S7.ConnectionType>().HasData
            (
                new Domain.Entity.S7.ConnectionType(1, "PG"),
                new Domain.Entity.S7.ConnectionType(2, "OP"),
                new Domain.Entity.S7.ConnectionType(3, "S7Basic 1"),
                new Domain.Entity.S7.ConnectionType(4, "S7Basic 2"),
                new Domain.Entity.S7.ConnectionType(5, "S7Basic 3"),
                new Domain.Entity.S7.ConnectionType(6, "S7Basic 4"),
                new Domain.Entity.S7.ConnectionType(7, "S7Basic 5"),
                new Domain.Entity.S7.ConnectionType(8, "S7Basic 6"),
                new Domain.Entity.S7.ConnectionType(9, "S7Basic 7"),
                new Domain.Entity.S7.ConnectionType(10, "S7Basic 8")
            );

            modelBuilder.Entity<Domain.Entity.S7.Area>().HasData
            (
                new Domain.Entity.S7.Area(28, "S7AreaCT", "Counter area memory (C1, C2, ...)"),
                new Domain.Entity.S7.Area(132, "S7AreaDB", "DB area memory (DB1, DB2, ...)"),
                new Domain.Entity.S7.Area(131, "S7AreaMK", "Merkers area memory (M0, M0.0, ...)"),
                new Domain.Entity.S7.Area(130, "S7AreaPA", "Output area memory"),
                new Domain.Entity.S7.Area(129, "S7AreaPE", "Input area memory"),
                new Domain.Entity.S7.Area(29, "S7AreaTM", "Timer area memory(T1, T2, ...)")
            );

            modelBuilder.Entity<Domain.Entity.S7.WordLen>().HasData
            (
                new Domain.Entity.S7.WordLen(0, "Bit", "S7 Bit variable type (bool)"),
                new Domain.Entity.S7.WordLen(1, "Byte", "S7 Byte variable type (8 bits)"),
                new Domain.Entity.S7.WordLen(2, "Word", "S7 Word variable type (16 bits, 2 bytes)"),
                new Domain.Entity.S7.WordLen(3, "Dword", "S7 DWord variable type (32 bits, 4 bytes)"),
                new Domain.Entity.S7.WordLen(4, "Int", "S7 Int variable type (16 bits, 2 bytes)"),
                new Domain.Entity.S7.WordLen(5, "DInt", "DInt variable type (32 bits, 4 bytes)"),
                new Domain.Entity.S7.WordLen(6, "Real", "Real variable type (32 bits, 4 bytes)"),
                new Domain.Entity.S7.WordLen(7, "LReal", "LReal variable type (64 bits, 8 bytes)"),
                new Domain.Entity.S7.WordLen(8, "String", "Char Array / C-String variable type (variable)"),
                new Domain.Entity.S7.WordLen(9, "S7String", "S7 String variable type (variable)"),
                new Domain.Entity.S7.WordLen(10, "S7WString", "S7 WString variable type (variable)"),
                new Domain.Entity.S7.WordLen(11, "Timer", "Timer variable type"),
                new Domain.Entity.S7.WordLen(12, "Counter", "Counter variable type"),
                new Domain.Entity.S7.WordLen(13, "DataTime", "DateTime variable type"),
                new Domain.Entity.S7.WordLen(14, "DataTimeLong", "DateTimeLong variable type")
            );

            //modelBuilder.Entity<Domain.Db.Entity.>()

            //modelBuilder.Entity<Domain.Entity.S7.S7Connection>()
            //    .HasData(
            //    ReadCsv<Domain.Entity.S7.S7Connection>.Read(loggerFactory,@"S7Connection")
            //);

            //modelBuilder.Entity<Domain.Entity.S7.S7Tag>()
            //    .HasData(
            //        ReadCsv<Domain.Entity.S7.S7Tag>.Read(loggerFactory, @"S7Tag")
            ////ReadCsv<Domain.Com.Entity.S7.S7Tag>.Read(@"S7TagSeparaBarre")
            //);

            var s7Connection = ReadCsv<Domain.Entity.S7.S7Connection>.Read(loggerFactory, @"S7Connection");
            if (!(s7Connection is null))
            {
                modelBuilder.Entity<Domain.Entity.S7.S7Connection>()
                    .HasData(
                        s7Connection
                    );
            }

            var s7Tag = ReadCsv<Domain.Entity.S7.S7Tag>.Read(loggerFactory, @"S7Tag");
            if (!(s7Tag is null))
            {
                modelBuilder.Entity<Domain.Entity.S7.S7Tag>()
                    .HasData(
                        s7Tag
                    );
            }
        }
    }
}
