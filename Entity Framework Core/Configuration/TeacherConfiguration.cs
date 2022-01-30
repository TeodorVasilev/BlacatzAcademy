using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UniversitySystem.Models;

namespace UniversitySystem.Configuration
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder
                .HasOne<University>(t => t.University)
                .WithMany(u => u.Teachers)
                .HasForeignKey(t => t.UniversityId);

            builder.HasData
            (
                new Teacher()
                {
                    Id = 1,
                    Name = "Bamzi",
                    Age = 50,
                    Education = "Krajbi",
                    UniversityId = 1
                },
                new Teacher()
                {
                    Id = 2,
                    Name = "Pencho",
                    Age = 54,
                    Education = "Prodajbi",
                    UniversityId = 1
                }
            );
        }
    }
}
