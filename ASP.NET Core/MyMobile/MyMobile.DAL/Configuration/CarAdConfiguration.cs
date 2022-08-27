using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMobile.DAL.Models.CarAd;
using MyMobile.DAL.Models.CarAd.CarAdArgs;
using MyMobile.DAL.Models.CarAd.CarArgs;
using MyMobile.DAL.Models.Identity;

namespace MyMobile.DAL.Configuration
{
    public class CarAdConfiguration : IEntityTypeConfiguration<Listing>
    {
        public void Configure(EntityTypeBuilder<Listing> builder)
        {
            builder.HasKey(ca => ca.Id);

            builder
                .HasOne<Category>(ca => ca.Category)
                .WithMany(c => c.CarAds)
                .HasForeignKey(ca => ca.CategoryId);
            builder
                .HasOne<Condition>(ca => ca.Condition)
                .WithMany(c => c.CarAds)
                .HasForeignKey(ca => ca.ConditionId);
            builder
                .HasOne<Currency>(ca => ca.Currency)
                .WithMany(c => c.CarAds)
                .HasForeignKey(ca => ca.CurrencyId);
            builder
                .HasOne<Region>(ca => ca.Region)
                .WithMany(r => r.CarAds)
                .HasForeignKey(ca => ca.RegionId);
            builder
                .HasOne<Town>(ca => ca.Town)
                .WithMany(t => t.CarAds)
                .HasForeignKey(ca => ca.TownId)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasOne<Make>(ca => ca.Make)
                .WithMany(m => m.CarAds)
                .HasForeignKey(ca => ca.MakeId)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasOne<Model>(ca => ca.Model)
                .WithMany(m => m.CarAds)
                .HasForeignKey(ca => ca.ModelId)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasOne<VehicleCategory>(ca => ca.VehicleCategory)
                .WithMany(vc => vc.CarAds)
                .HasForeignKey(ca => ca.VehicleCategoryId);
            builder
                .HasOne<Engine>(ca => ca.Engine)
                .WithMany(e => e.CarAds)
                .HasForeignKey(ca => ca.EngineId);
            builder
                .HasOne<Gearbox>(ca => ca.Gearbox)
                .WithMany(g => g.CarAds)
                .HasForeignKey(ca => ca.GearboxId);
            builder
                .HasOne<Color>(ca => ca.Color)
                .WithMany(c => c.CarAds)
                .HasForeignKey(ca => ca.ColorId);
            builder
                .HasOne<AppUser>(ca => ca.AppUser)
                .WithMany(au => au.CarAds)
                .HasForeignKey(ca => ca.AppUserId);
            builder
                .HasOne<Promotion>(ca => ca.Promotion)
                .WithMany(p => p.CarAds)
                .HasForeignKey(ca => ca.PromotionId);
        }
    }
}
