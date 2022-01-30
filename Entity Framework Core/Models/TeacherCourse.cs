using System;
using System.Collections.Generic;
using System.Text;

namespace UniversitySystem.Models
{
    public class TeacherCourse
    {
        public int Id { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
