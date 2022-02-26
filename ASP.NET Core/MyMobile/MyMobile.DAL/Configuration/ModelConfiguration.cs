using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMobile.DAL.Models.CarAd.CarArgs;

namespace MyMobile.DAL.Configuration
{
    public class ModelConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.HasKey(m => m.Id);

            builder
                .HasOne<Make>(m => m.Make)
                .WithMany(m => m.Models)
                .HasForeignKey(m => m.MakeId);

            builder.HasData
                (
                    new Model()
                    {
                        Id = 1,
                        Name = "530",
                        MakeId = 1
                    },
                    new Model()
                    {
                        Id = 2,
                        Name = "528",
                        MakeId = 1
                    },
            
                    new Model()
                    {
                        Id = 3,
                        Name = "E 320",
                        MakeId = 2
                    },
            
                    new Model()
                    {
                        Id = 4,
                        Name = "C 180",
                        MakeId = 2
                    },
            
                    new Model()
                    {
                        Id = 5,
                        Name = "Vectra",
                        MakeId = 3
                    },
            
                    new Model()
                    {
                        Id = 6,
                        Name = "Grand Cherokee",
                        MakeId = 4
                    },
            
                    new Model()
                    {
                        Id = 7,
                        Name = "Patrol",
                        MakeId = 5
                    },
            
                    new Model()
                    {
                        Id = 8,
                        Name = "Terano",
                        MakeId = 5
                    }
                );
        }
    }
}
