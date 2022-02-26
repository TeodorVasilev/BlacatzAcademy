using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMobile.DAL.Models.CarAd;
using MyMobile.DAL.Models.CarAd.CarAdArgs;
using MyMobile.DAL.Models.CarAd.CarArgs;

namespace MyMobile.DAL.Configuration
{
    public class CarAdConfiguration : IEntityTypeConfiguration<CarAd>
    {
        public void Configure(EntityTypeBuilder<CarAd> builder)
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
        }
    }
}
