using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMobile.DAL.Models.CarAd.CarArgs;

namespace MyMobile.DAL.Configuration
{
    internal class ComfortConfiguration : IEntityTypeConfiguration<Comfort>
    {
        public void Configure(EntityTypeBuilder<Comfort> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasData
                (
                    new Comfort()
                    {
                        Id = 1,
                        Name = "Навигация"
                    },

                    new Comfort()
                    {
                        Id = 2,
                        Name = "Темпомат"
                    },

                    new Comfort()
                    {
                        Id = 3,
                        Name = "Стерео уредба"
                    },

                    new Comfort()
                    {
                        Id = 4,
                        Name = "Подгряване на седалките"
                    },

                    new Comfort()
                    {
                        Id = 5,
                        Name = "Климатик"
                    },

                    new Comfort()
                    {
                        Id = 6,
                        Name = "Климатроник"
                    }
                );
        }
    }
}
