using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMobile.DAL.Models.CarAd.CarAdArgs;

namespace MyMobile.DAL.Configuration
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.HasKey(r => r.Id);

            builder.HasData
                (
                    new Region
                    {
                        Id = 1,
                        Name = "Пловдив"
                    }
                );
        }
    }
}
