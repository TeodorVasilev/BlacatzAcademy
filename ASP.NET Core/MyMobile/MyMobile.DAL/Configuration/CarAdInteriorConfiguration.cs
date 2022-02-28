using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMobile.DAL.Models.CarAd;
using MyMobile.DAL.Models.CarAd.CarArgs;

namespace MyMobile.DAL.Configuration
{
    public class CarAdInteriorConfiguration : IEntityTypeConfiguration<CarAdInterior>
    {
        public void Configure(EntityTypeBuilder<CarAdInterior> builder)
        {
            builder.HasKey(cai => cai.Id);

            builder
                .HasOne<CarAd>(cai => cai.CarAd)
                .WithMany(ca => ca.CarAdInteriors)
                .HasForeignKey(cai => cai.CarAdId);
            builder
                .HasOne<Interior>(cai => cai.Interior)
                .WithMany(i => i.CarAdInteriors)
                .HasForeignKey(cai => cai.InteriorId);
        }
    }
}
