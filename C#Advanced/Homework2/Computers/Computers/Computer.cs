namespace Computers
{
    public class Computer
    {
        public Computer()
        {

        }

        public Computer(double ram, string processor, string videoCard)
        {
            this.Ram = ram;
            this.Processor = processor;
            this.VideoCard = videoCard;
        }

        public Computer(string processor, string videoCard, bool wifiAdapter)
        {
            this.Processor = processor;
            this.VideoCard = videoCard;
            this.WifiAdapter = wifiAdapter;
        }

        public Computer(double ram, string processor, string videoCard, bool wifiAdapter)
        {
            this.Ram = ram;
            this.Processor = processor;
            this.VideoCard = videoCard;
            this.WifiAdapter = wifiAdapter;
        }

        public double Ram { get; set; }
        public string Processor { get; set; }
        public string VideoCard { get; set; }
        public bool WifiAdapter { get; set; }
    }
}
