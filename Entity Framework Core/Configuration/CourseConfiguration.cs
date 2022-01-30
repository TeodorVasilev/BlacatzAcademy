using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UniversitySystem.Models;

namespace UniversitySystem.Configuration
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasData
                (
                    new Course()
                    {
                        Id = 1,
                        Name = "SomeCourse",
                        TeacherCourses = new List<TeacherCourse>(),
                        StudentCourses = new List<StudentCourse>()
                    }
                );
        }
    }
}
