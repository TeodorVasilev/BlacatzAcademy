using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyMobile.DAL.Configuration;
using MyMobile.DAL.Models.CarAd;
using MyMobile.DAL.Models.CarAd.CarAdArgs;
using MyMobile.DAL.Models.CarAd.CarArgs;
using MyMobile.DAL.Models.Identity;

namespace MyMobile.DAL.Data
{
    public class MyMobileContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public DbSet<Listing> CarAds { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<VehicleCategory> VehicleCategories { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<Eurostandard> Eurostandards { get; set; }
        public DbSet<Gearbox> Gearboxes { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Interior> Interiors { get; set; }
        public DbSet<CarAdInterior> CarAdInteriors { get; set; }
        public DbSet<Comfort> Comforts { get; set; }
        public DbSet<CarAdComfort> CarAdComforts { get; set; }
        public DbSet<Security> Securities { get; set; }
        public DbSet<CarAdSecurity> CarAdSecurities { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server =.; Database = MyMobileDatabase; Trusted_Connection = True");
            }
        }
        //it has to be able to add an ad without being logged in
        //fix relationships in configuration and in both listing and appuser classes
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //?

            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new CarAdConfiguration());//listing
            modelBuilder.ApplyConfiguration(new RegionConfiguration());
            modelBuilder.ApplyConfiguration(new TownConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ConditionConfiguration());
            modelBuilder.ApplyConfiguration(new CurrencyConfiguration());
            modelBuilder.ApplyConfiguration(new MakeConfiguration());
            modelBuilder.ApplyConfiguration(new ModelConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new EngineConfiguration());
            modelBuilder.ApplyConfiguration(new EurostandardConfiguration());
            modelBuilder.ApplyConfiguration(new GearboxConfiguration());
            modelBuilder.ApplyConfiguration(new ColorConfiguration());
            modelBuilder.ApplyConfiguration(new InteriorConfiguration());
            modelBuilder.ApplyConfiguration(new CarAdInteriorConfiguration());
            modelBuilder.ApplyConfiguration(new ComfortConfiguration());
            modelBuilder.ApplyConfiguration(new CarAdComfortConfiguration());
            modelBuilder.ApplyConfiguration(new SecurityConfiguration());
            modelBuilder.ApplyConfiguration(new CarAdSecurityConfiguration());
        }
    }
}
