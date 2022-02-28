using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMobile.DAL.Models.CarAd.CarArgs;

namespace MyMobile.DAL.Configuration
{
    public class EngineConfiguration : IEntityTypeConfiguration<Engine>
    {
        public void Configure(EntityTypeBuilder<Engine> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasData
                (
                    new Engine()
                    {
                        Id = 1,
                        Type = "Бензинов"
                    },

                    new Engine()
                    {
                        Id = 2,
                        Type = "Дизелов"
                    },

                    new Engine()
                    {
                        Id = 3,
                        Type = "Електрически"
                    },

                    new Engine()
                    {
                        Id = 4,
                        Type = "Хибриден"
                    }
                );
        }
    }
}
