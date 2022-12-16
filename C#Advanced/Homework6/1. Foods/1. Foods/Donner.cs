namespace _1._Foods
{
    public class Donner : Food
    {
        public Donner(int id, string name) : base(id, name)
        {
            this.Energy = 75;
        }

        public override double GetEnergy()
        {
            return this.Energy;
        }
    }
}
