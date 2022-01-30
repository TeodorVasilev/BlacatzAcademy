using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UniversitySystem.Configuration;
using UniversitySystem.Models;

namespace UniversitySystem.Database
{
    public class UniversityDbContext : DbContext
    {
        public DbSet<University> Universities { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<TeacherCourse> TeacherCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.; Database=UniversityDatabase;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());

            modelBuilder.ApplyConfiguration(new StudentConfiguration());

            modelBuilder.ApplyConfiguration(new StudentCourseConfiguration());

            modelBuilder.ApplyConfiguration(new TeacherCourseConfiguration());

            modelBuilder.ApplyConfiguration(new UniversityConfiguration());

            modelBuilder.ApplyConfiguration(new CourseConfiguration());
        }
    }
}
