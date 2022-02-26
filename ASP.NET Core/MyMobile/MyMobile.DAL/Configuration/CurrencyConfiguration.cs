using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMobile.DAL.Models.CarAd.CarAdArgs;

namespace MyMobile.DAL.Configuration
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasData
                (
                    new Currency
                    {
                        Id = 1,
                        Name = "BGN",
                        CourseToDefault = 1

                    },

                    new Currency
                    {
                        Id = 2,
                        Name = "EUR",
                        CourseToDefault = 1.95m
                    }
                );
        }
    }
}
