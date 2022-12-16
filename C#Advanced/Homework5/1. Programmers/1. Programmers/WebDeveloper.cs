namespace _1._Programmers
{
    public class WebDeveloper : Junior
    {
        public WebDeveloper(string name, int age, string company, decimal salary) 
        : base(name, age, company, salary)
        {
            this.WebKnowledge = new List<string>();
        }

        public List<string> WebKnowledge { get; set; }
    }
}
