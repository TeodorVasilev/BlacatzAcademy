using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMobile.DAL.Models.CarAd.CarArgs;

namespace MyMobile.DAL.Configuration
{
    public class GearboxConfiguration : IEntityTypeConfiguration<Gearbox>
    {
        public void Configure(EntityTypeBuilder<Gearbox> builder)
        {
            builder.HasKey(g => g.Id);

            builder.HasData
                (
                    new Gearbox()
                    {
                        Id = 1,
                        Type = "Ръчна"
                    },

                    new Gearbox()
                    {
                        Id = 2,
                        Type = "Автоматична"
                    },

                    new Gearbox()
                    {
                        Id = 3,
                        Type = "Полуавтоматична"
                    }
                );
        }
    }
}
