using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMobile.DAL.Models.CarAd.CarArgs;

namespace MyMobile.DAL.Configuration
{
    public class InteriorConfiguration : IEntityTypeConfiguration<Interior>
    {
        public void Configure(EntityTypeBuilder<Interior> builder)
        {
            builder.HasKey(i => i.Id);

            builder.HasData
                (
                    new Interior()
                    {
                        Id = 1,
                        Name = "Кожен салон"
                    },

                    new Interior()
                    {
                        Id = 2,
                        Name = "Велурен салон"
                    },

                    new Interior()
                    {
                        Id = 3,
                        Name = "Десен волан"
                    }
                );
        }
    }
}
