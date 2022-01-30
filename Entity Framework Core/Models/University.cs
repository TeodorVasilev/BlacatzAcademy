using System;
using System.Collections.Generic;
using System.Text;

namespace UniversitySystem.Models
{
    public class University
    {
        public University()
        {
            this.Teachers = new List<Teacher>();
            this.Students = new List<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Town { get; set; }
        //teachers
        public ICollection<Teacher> Teachers { get; set; }
        //students
        public ICollection<Student> Students { get; set; }
    }
}
