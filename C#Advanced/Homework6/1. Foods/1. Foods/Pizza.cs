namespace _1._Foods
{
    public class Pizza : Food
    {
        public Pizza(int id, string name) 
        : base(id, name)
        {
            this.Energy = 45;
        }

        public override double GetEnergy()
        {
            return this.Energy;
        }
    }
}
