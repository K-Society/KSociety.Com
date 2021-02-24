using KSociety.Base.Infra.Shared.Csv;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Infra.DataAccess.EntityTypeConfiguration.Common
{
    public static class ModelBuilderExtensions
    {
        public static void SeedCommon(this ModelBuilder modelBuilder, ILoggerFactory loggerFactory)
        {
            modelBuilder.Entity<Domain.Entity.Common.AutomationType>().HasData
            (
                new Domain.Entity.Common.AutomationType(0, "Base", "Base"),
                new Domain.Entity.Common.AutomationType(1, "Siemens", "Siemens"),
                new Domain.Entity.Common.AutomationType(2, "Logix", "Logix"),
                new Domain.Entity.Common.AutomationType(3, "Modbus", "Modbus"),
                new Domain.Entity.Common.AutomationType(4, "Tcp", "Generic TCP")
            );

            modelBuilder.Entity<Domain.Entity.Common.AnalogDigital>().HasData
            (
                new Domain.Entity.Common.AnalogDigital("Analog"),
                new Domain.Entity.Common.AnalogDigital("Digital")
            );

            modelBuilder.Entity<Domain.Entity.Common.Bit>().HasData
            (
                new Domain.Entity.Common.Bit(0, "Bit 0"),
                new Domain.Entity.Common.Bit(1, "Bit 1"),
                new Domain.Entity.Common.Bit(2, "Bit 2"),
                new Domain.Entity.Common.Bit(3, "Bit 3"),
                new Domain.Entity.Common.Bit(4, "Bit 4"),
                new Domain.Entity.Common.Bit(5, "Bit 5"),
                new Domain.Entity.Common.Bit(6, "Bit 6"),
                new Domain.Entity.Common.Bit(7, "Bit 7")
            );

            modelBuilder.Entity<Domain.Entity.Common.InOut>().HasData
            (
                new Domain.Entity.Common.InOut("R", "Read"),
                new Domain.Entity.Common.InOut("W", "Write"),
                new Domain.Entity.Common.InOut("U", "Unknown"),
                new Domain.Entity.Common.InOut("RW", "Read/Write")
            );

            //modelBuilder.Entity<Domain.Entity.Common.TagGroup>().HasData(
            //    ReadCsv<Domain.Entity.Common.TagGroup>.Read(loggerFactory, @"TagGroup")
            //);

            var tagGroup = ReadCsv<Domain.Entity.Common.TagGroup>.Read(loggerFactory, @"TagGroup");
            if (!(tagGroup is null))
            {
                modelBuilder.Entity<Domain.Entity.Common.TagGroup>()
                    .HasData(
                        tagGroup
                    );
            }
        }
    }
}
