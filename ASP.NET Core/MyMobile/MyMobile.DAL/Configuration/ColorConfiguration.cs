using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMobile.DAL.Models.CarAd.CarArgs;

namespace MyMobile.DAL.Configuration
{
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasData
                (
                    new Color()
                    {
                        Id = 1,
                        Name = "Металик"
                    },

                    new Color()
                    {
                        Id = 2,
                        Name = "Черен"
                    },

                    new Color()
                    {
                        Id = 3,
                        Name = "Син"
                    },

                    new Color()
                    {
                        Id = 4,
                        Name = "Сив"
                    },

                    new Color()
                    {
                        Id = 5,
                        Name = "Бордо"
                    }
                );
        }
    }
}
