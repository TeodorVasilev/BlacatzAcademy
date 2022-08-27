using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMobile.DAL.Models.CarAd.CarAdArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMobile.DAL.Configuration
{
    internal class PromotionConfiguration : IEntityTypeConfiguration<Promotion>
    {
        public void Configure(EntityTypeBuilder<Promotion> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasData
                (
                    new Promotion()
                    {
                       Id = 1,
                       Name = "VIP"
                    },

                    new Promotion()
                    {
                       Id = 2,
                       Name = "TOP"
                    }
                );
        }
    }
}
