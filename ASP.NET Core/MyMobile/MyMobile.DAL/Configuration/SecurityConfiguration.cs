using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMobile.DAL.Models.CarAd.CarArgs;

namespace MyMobile.DAL.Configuration
{
    public class SecurityConfiguration : IEntityTypeConfiguration<Security>
    {
        public void Configure(EntityTypeBuilder<Security> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasData
                (
                    new Security()
                    {
                        Id = 1,
                        Name = "GPS система за проследяване"
                    },

                    new Security()
                    {
                        Id=2,
                        Name = "Автоматичен контрол на стабилността"
                    },

                    new Security()
                    {
                        Id = 3,
                        Name = "Антиблокираща система"
                    },

                    new Security()
                    {
                        Id = 4,
                        Name = "Въздушни възглавници"
                    },

                    new Security()
                    {
                        Id = 5,
                        Name = "Парктроник"
                    },

                    new Security()
                    {
                        Id= 6,
                        Name = "Система за защита от пробуксуване"
                    }
                );
        }
    }
}
