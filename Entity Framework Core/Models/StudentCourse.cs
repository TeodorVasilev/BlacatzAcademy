using System;
using System.Collections.Generic;
using System.Text;

namespace UniversitySystem.Models
{
    public class StudentCourse
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int Grade { get; set; }
    }
}
