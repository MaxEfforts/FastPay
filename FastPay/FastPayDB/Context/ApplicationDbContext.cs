
using FastPayDB.Model;
using FastPayDB.DatabaseModels.Account.Address;
using FastPayDB.DatabaseModels.Account.User;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace FastPayDB.Context;


public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
{
    #region Configuration
    public class OptionBuild
    {
        public OptionBuild()
        {
            settings = new AppConfiguration();
            opsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            opsBuilder.UseSqlServer(settings.SqlConnectionString);
            dbOptions = opsBuilder.Options;
        }
        public DbContextOptionsBuilder<ApplicationDbContext> opsBuilder { get; set; }
        public DbContextOptions<ApplicationDbContext> dbOptions { get; set; }
        private AppConfiguration settings { get; set; }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging(); //I'm trying to track down the cause of an Entity Framework InvalidOperationException
    }

    public static OptionBuild ops = new OptionBuild();
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    #endregion

    #region ModelCreating
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<IdentityUser>(b =>
        {
            var indexNormalizedUserName = b.HasIndex(u => new { u.NormalizedUserName }).Metadata;
            b.Metadata.RemoveIndex(indexNormalizedUserName.Properties);

            var indexNormalizedEmail = b.HasIndex(u => new { u.NormalizedEmail }).Metadata;
            b.Metadata.RemoveIndex(indexNormalizedEmail.Properties);

        });
        //Change EF Core Migrations to different default owner
        foreach (var et in builder.Model.GetEntityTypes())
        {
            et.SetSchema("dbo");
        }
    }
    #endregion

    #region Tables
    public DbSet<Test>  tests { get; set; }

    public DbSet<ActivationCode> ActivationCode { get; set; }
    public DbSet<UserAddField> UserAddField { get; set; }
    public DbSet<UserAddFieldOption> UserAddFieldOption { get; set; }

    public DbSet<UserFormSetting> UserFormSetting { get; set; }
    public DbSet<UserAddressFormSetting> UserAddressFormSettings { get; set; }

    public DbSet<UserAddress> userAddresses { get; set; }

    public DbSet<UserAddFieldDateTime> UserAddFieldDateTime { get; set; }


    public DbSet<UserAddressAddField> UserAddressAddField { get; set; }
    public DbSet<UserAddressAddFieldOption> UserAddressAddFieldOption { get; set; }
    public DbSet<UserAddressAddFieldDateTime> UserAddressAddFieldDateTime { get; set; }


    #endregion
}

