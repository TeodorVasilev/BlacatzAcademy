using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMobile.DAL.Models.CarAd.CarAdArgs;

namespace MyMobile.DAL.Configuration
{
    public class ConditionConfiguration : IEntityTypeConfiguration<Condition>
    {
        public void Configure(EntityTypeBuilder<Condition> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasData
                (
                    new Condition
                    {
                        Id = 1,
                        Type = "Употребяван"
                    },

                    new Condition
                    {
                        Id = 2,
                        Type = "Нов"
                    },

                    new Condition
                    {
                        Id = 3,
                        Type ="За части"
                    }
                );
        }
    }
}
