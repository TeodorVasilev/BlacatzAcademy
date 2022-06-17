using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMobile.DAL.Models.CarAd;
using MyMobile.DAL.Models.CarAd.CarAdArgs;
using MyMobile.DAL.Models.CarAd.CarArgs;

namespace MyMobile.DAL.Configuration
{
    public class CarAdComfortConfiguration : IEntityTypeConfiguration<CarAdComfort>
    {
        public void Configure(EntityTypeBuilder<CarAdComfort> builder)
        {
            builder.HasKey(cac => cac.Id);

            builder
                .HasOne<Listing>(cac => cac.CarAd)
                .WithMany(ca => ca.CarAdComforts)
                .HasForeignKey(cac => cac.CarAdId);
            builder
                .HasOne<Comfort>(cac => cac.Comfort)
                .WithMany(c => c.CarAdComforts)
                .HasForeignKey(cac => cac.ComfortId);
        }
    }
}
