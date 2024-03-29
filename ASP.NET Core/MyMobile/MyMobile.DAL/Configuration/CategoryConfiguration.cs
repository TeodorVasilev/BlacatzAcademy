﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMobile.DAL.Models.CarAd.CarAdArgs;

namespace MyMobile.DAL.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasData
                (
                    new Category 
                    {
                        Id = 1,
                        Type = "Aвтомобили и джипове"
                    },

                    new Category
                    {
                        Id = 2,
                        Type = "Бусове"
                    },

                    new Category
                    {
                        Id = 3,
                        Type = "Камиони"
                    }
                );
        }
    }
}
