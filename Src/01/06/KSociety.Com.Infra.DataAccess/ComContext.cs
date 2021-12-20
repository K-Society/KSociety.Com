using KSociety.Base.Infra.Shared.Class;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.Infra.DataAccess.EntityTypeConfiguration.Common;
using KSociety.Com.Infra.DataAccess.EntityTypeConfiguration.S7;
using KSociety.Com.Infra.DataAccess.EntityTypeConfiguration.Tcp;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Infra.DataAccess;

public class ComContext : DatabaseContext
{
    public ComContext(ILoggerFactory loggerFactory, IDatabaseConfiguration configuration, IMediator mediator)
        : base(loggerFactory, configuration, mediator)
    {
        //Database.EnsureCreated();
        //Database.Migrate();
    }

    public ComContext(DbContextOptions options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Conventions.Remove<ForeignKeyIndexConvention>(); //No Index for every foreign key

        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new AnalogDigital());
        modelBuilder.ApplyConfiguration(new Bit());
        modelBuilder.ApplyConfiguration(new EntityTypeConfiguration.Common.Connection());
        modelBuilder.ApplyConfiguration(new InOut());
        modelBuilder.ApplyConfiguration(new AutomationType());
        modelBuilder.ApplyConfiguration(new EntityTypeConfiguration.Common.Tag());
        modelBuilder.ApplyConfiguration(new TagGroup());

        modelBuilder.ApplyConfiguration(new Area());
        modelBuilder.ApplyConfiguration(new BlockArea());
        modelBuilder.ApplyConfiguration(new EntityTypeConfiguration.S7.S7Connection());
        modelBuilder.ApplyConfiguration(new ConnectionType());
        modelBuilder.ApplyConfiguration(new CpuType());
        modelBuilder.ApplyConfiguration(new EntityTypeConfiguration.S7.S7Tag());
        modelBuilder.ApplyConfiguration(new WordLen());

        //Logix
        modelBuilder.ApplyConfiguration(new EntityTypeConfiguration.Logix.LogixTag());
        modelBuilder.ApplyConfiguration(new EntityTypeConfiguration.Logix.LogixConnection());

        //Tcp
        modelBuilder.ApplyConfiguration(new EntityTypeConfiguration.Tcp.TcpTag());
        modelBuilder.ApplyConfiguration(new EntityTypeConfiguration.Tcp.TcpConnection());

        //view
        modelBuilder.ApplyConfiguration(new EntityTypeConfiguration.View.Common.TagGroupReady());
        modelBuilder.ApplyConfiguration(new EntityTypeConfiguration.View.Joined.AllConnection());
        modelBuilder.ApplyConfiguration(new EntityTypeConfiguration.View.Joined.AllTagGroupAllConnection());
        modelBuilder.ApplyConfiguration(new EntityTypeConfiguration.View.Joined.AllTagGroupConnection());

        //Seed
        modelBuilder.SeedCommon(LoggerFactory);
        modelBuilder.SeedS7(LoggerFactory);
        modelBuilder.SeedTcp(LoggerFactory);
    }
}