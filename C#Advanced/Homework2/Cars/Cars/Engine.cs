namespace Cars
{
    public class Engine
    {
        private double lifeKms { get; }
        public Engine()
        {
            this.lifeKms = 200000;
        }

        public double FuelConsumption { get; set; }
        public double Mileage { get; set; }

        public string Drive(double mileage)
        {
            if (this.Mileage + mileage > this.lifeKms)
            {
                this.Mileage += this.lifeKms - this.Mileage;
                return "Check engine";
            }

            this.Mileage += mileage;

            return "Driving";
        }
    }
}
