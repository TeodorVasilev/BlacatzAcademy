namespace _1._Foods
{
    public class Salad : Food
    {
        public Salad(int id, string name) : base(id, name)
        {
            this.Energy = 10;
        }

        public override double GetEnergy()
        {
            return this.Energy;
        }
    }
}
