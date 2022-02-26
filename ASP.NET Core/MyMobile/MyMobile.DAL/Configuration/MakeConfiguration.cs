using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMobile.DAL.Models.CarAd.CarArgs;

namespace MyMobile.DAL.Configuration
{
    public class MakeConfiguration : IEntityTypeConfiguration<Make>
    {
        public void Configure(EntityTypeBuilder<Make> builder)
        {
            builder.HasKey(m => m.Id);

            builder.HasData
                (
                    new Make()
                    {
                        Id = 1,
                        Name = "BMW"
                    },
            
                    new Make()
                    {
                        Id = 2,
                        Name = "Mercedes-Benz"
                    },
            
                    new Make()
                    {
                        Id = 3,
                        Name = "Opel",
                    },
            
                    new Make()
                    {
                        Id = 4,
                        Name = "Jeep"
                    },
            
                    new Make()
                    {
                        Id = 5,
                        Name = "Nissan"
                    }
                );
        }
    }
}
