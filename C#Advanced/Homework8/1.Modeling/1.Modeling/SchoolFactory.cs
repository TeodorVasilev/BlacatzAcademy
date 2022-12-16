namespace _1.Modeling
{
    public class SchoolFactory
    {
        public School Create()
        {
            var school = new School();

            var pesho = new Student("Pesho", 23, "12A");
            pesho.Grades.Add(new Grade { Course = "Fizika", Rating = 2 });

            school.Students.Add(pesho);

            var naPeshoBashtaMu = new Parent("Na Pesho Bashta Mu", 40);
            naPeshoBashtaMu.Students.Add(pesho);

            school.Parents.Add(naPeshoBashtaMu);

            var daskal = new Teacher("Daskala", 50, "Fizika", Role.Director);
            daskal.Courses.Add("Fizika");
            daskal.Students.Add(pesho);

            school.Teachers.Add(daskal);

            return school;
        }
    }
}
