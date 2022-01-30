using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using UniversitySystem.Database;

namespace UniversitySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new UniversityDbContext())
            {
                var teachers = context.Teachers.Include(t => t.University).ToList();

                foreach (var teacher in teachers)
                {
                    Console.WriteLine(teacher.Name);
                    Console.WriteLine(teacher.University.Name);
                }
            }

        }
    }
}
