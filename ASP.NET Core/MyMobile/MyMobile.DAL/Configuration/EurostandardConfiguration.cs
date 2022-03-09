using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMobile.DAL.Models.CarAd.CarArgs;

namespace MyMobile.DAL.Configuration
{
    public class EurostandardConfiguration : IEntityTypeConfiguration<Eurostandard>
    {
        public void Configure(EntityTypeBuilder<Eurostandard> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasData
                (
                    new Eurostandard()
                    {
                        Id = 1,
                        Name = "Euro 1"
                    },

                    new Eurostandard()
                    {
                        Id = 2,
                        Name = "Euro 2"
                    },

                    new Eurostandard()
                    {
                        Id = 3,
                        Name = "Euro 3"
                    },

                    new Eurostandard()
                    {
                        Id= 4,
                        Name = "Euro 4"
                    },

                    new Eurostandard()
                    {
                        Id = 5,
                        Name = "Euro 5"
                    },

                    new Eurostandard()
                    {
                        Id = 6,
                        Name = "Euro 6"
                    }
                );
        }
    }
}
