namespace _07.Smartphone
{
    public class Smartphone
    {
        public Smartphone(string brand, string model)
        {
            this.Brand = brand;
            this.Model = model;
        }

        public Smartphone(string brand, string model, double ram)
            : this(brand, model)
        {
            this.Ram = ram;
        }

        public Smartphone(string brand, string model, double ram, string processor)
            : this(brand, model, ram)
        {
            this.Processor = processor;
        }

        public string Brand { get; set; }
        public string Model { get; set; }
        public double Ram { get; set; }
        public string Processor { get; set; }
    }
}
