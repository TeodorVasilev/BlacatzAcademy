namespace _1._Programmers
{
    public class GameDeveloper : Junior
    {
        public GameDeveloper(string name, int age, string company, decimal salary) 
        : base(name, age, company, salary)
        {
            this.MathKnowledge = new List<string>();
        }

        public List<string> MathKnowledge { get; set; }
    }
}
