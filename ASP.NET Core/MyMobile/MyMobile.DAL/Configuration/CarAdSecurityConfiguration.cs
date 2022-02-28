using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMobile.DAL.Models.CarAd;
using MyMobile.DAL.Models.CarAd.CarArgs;

namespace MyMobile.DAL.Configuration
{
    public class CarAdSecurityConfiguration : IEntityTypeConfiguration<CarAdSecurity>
    {
        public void Configure(EntityTypeBuilder<CarAdSecurity> builder)
        {
            builder.HasKey(cas => cas.Id);

            builder
                .HasOne<CarAd>(cas => cas.CarAd)
                .WithMany(ca => ca.CarAdSecurities)
                .HasForeignKey(cas => cas.CarAdId);
            builder
                .HasOne<Security>(cas => cas.Security)
                .WithMany(ca => ca.CarAdSecurities)
                .HasForeignKey(cas => cas.SecurityId);
        }
    }
}
