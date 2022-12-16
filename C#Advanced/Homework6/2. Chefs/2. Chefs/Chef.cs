namespace _2._Chefs
{
    public abstract class Chef
    {
        public Chef(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
        public int YearsExperience { get; set; }
    }
}
