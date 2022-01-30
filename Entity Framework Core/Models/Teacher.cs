using System;
using System.Collections.Generic;
using System.Text;

namespace UniversitySystem.Models
{
    public class Teacher
    {
        public Teacher()
        {
            this.TeacherCourses = new List<TeacherCourse>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Education { get; set; }
        //uni
        public int UniversityId { get; set; }
        public University University { get; set; }
        //courses
        public ICollection<TeacherCourse> TeacherCourses { get; set; }
    }
}
