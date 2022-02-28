using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMobile.DAL.Models.CarAd.CarArgs;

namespace MyMobile.DAL.Configuration
{
    public class VehicleCategoryConfiguration : IEntityTypeConfiguration<VehicleCategory>
    {
        public void Configure(EntityTypeBuilder<VehicleCategory> builder)
        {
            builder.HasKey(vc => vc.Id);

            builder.HasData
                (
                    new VehicleCategory()
                    {
                        Id = 1,
                        Name = "Седан"
                    },

                    new VehicleCategory()
                    {
                        Id = 2,
                        Name = "Комби"
                    },

                    new VehicleCategory()
                    {
                        Id = 3,
                        Name = "Стреч лимузина"
                    },

                    new VehicleCategory()
                    {
                        Id=4,
                        Name = "Джип"
                    }
                );
        }
    }
}
