using System;
using System.Collections.Generic;
using System.Text;

namespace UniversitySystem.Models
{
    public class Course
    {
        public Course()
        {
            this.TeacherCourses = new List<TeacherCourse>();
            this.StudentCourses = new List<StudentCourse>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        //teacher
        public ICollection<TeacherCourse> TeacherCourses { get; set; }
        //students
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
