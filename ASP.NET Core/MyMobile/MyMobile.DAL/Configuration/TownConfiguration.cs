using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMobile.DAL.Models.CarAd.CarAdArgs;

namespace MyMobile.DAL.Configuration
{
    public class TownConfiguration : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasData
                (
                    new Town
                    {
                        Id = 1,
                        Name = "Асеновград",
                        RegionId = 1                    
                    },
            
                    new Town
                    {
                        Id = 2,
                        Name = "Садово",
                        RegionId = 1
                    }, 
                    
                    new Town
                    {
                        Id = 3,
                        Name = "Карлово",
                        RegionId = 1
                    }
                );
        }
    }
}
