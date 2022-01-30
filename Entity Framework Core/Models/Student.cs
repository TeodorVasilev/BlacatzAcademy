using System;
using System.Collections.Generic;
using System.Text;

namespace UniversitySystem.Models
{
    public class Student
    {
        public Student()
        {
            this.StudentCourses = new List<StudentCourse>();
        }

        public int PersonalNumber { get; set; } //id
        public string Name { get; set; }
        //university
        public int UniversityId { get; set; }
        public University University { get; set; }
        //courses
        public ICollection<StudentCourse> StudentCourses { get; set; }
        //grade
    }
}
