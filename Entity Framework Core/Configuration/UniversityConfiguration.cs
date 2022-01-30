using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UniversitySystem.Models;

namespace UniversitySystem.Configuration
{
    public class UniversityConfiguration : IEntityTypeConfiguration<University>
    {
        public void Configure(EntityTypeBuilder<University> builder)
        {
            builder.HasData
                (
                    new University()
                    {
                        Id = 1,
                        Name = "SomeUniversity",
                        Address = "Address1",
                        Town = "Plovdiv",
                    },
                    new University()
                    {
                        Id = 2,
                        Name = "SomeOtherUniversity",
                        Address = "Address2",
                        Town = "Sofia",
                    }
                );
        }
    }
}
