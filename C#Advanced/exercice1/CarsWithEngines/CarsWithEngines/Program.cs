//class Engine
//{
//    public int HorsePower { get; set; }
//    public string Model { get; set; }
//}

//class Car
//{
//    public string Make { get; set; }
//    public string Model { get; set; }
//    public int Year { get; set; }
//    public Engine Engine { get; set; }
//}

//class Program
//{
//    public static void Main()
//    {
//        List<Engine> engines = new List<Engine>();
//        for (int i = 0; i < 2; i++)
//        {
//            string[] inputParameters = Console.ReadLine().Split(',');
//            Engine engine = new Engine();

//            engine.HorsePower = int.Parse(inputParameters[0]);
//            engine.Model = inputParameters[1];

//            engines.Add(engine);
//        }

//        List<Car> cars = new List<Car>();
//        for (int i = 0; i < 2; i++)
//        {
//            string[] inputParameters = Console.ReadLine().Split(',');
//            Car car = new Car();    
//            car.Make = inputParameters[0];
//            car.Model = inputParameters[1];
//            car.Year = int.Parse(inputParameters[2]);
//            //finish

//            cars.Add(car);
//        }
//    }
//}


class Engine
{
    public int horsePower;
    public string model;
}

class Car
{
    public string brand;
    public string model;
    public int year;
    public Engine engine;

    public void PrintInfo()
    {
        Console.WriteLine($"{this.brand}  {this.model}  {this.year} {this.engine}");
    }
}

class Program
{
    public static void Main()
    {
        List<Engine> engines = new List<Engine>();

        for (int i = 0; i < 2; i++)
        {
            Engine engine = new Engine();

            string[] inputParameters = Console.ReadLine().Split(",");
            engine.horsePower = int.Parse(inputParameters[0]);
            engine.model = inputParameters[1];

            engines.Add(engine);
        }

        List<Car> cars = new List<Car>();

        for (int i = 0; i < 2; i++)
        {
            Car car = new Car();
            string[] inputParameters = Console.ReadLine().Split(",");
            car.brand = inputParameters[0];
            car.model = inputParameters[1];
            car.year = int.Parse(inputParameters[2]);
            int engineIndex = int.Parse(inputParameters[3]);

            car.engine = engines[engineIndex];

            cars.Add(car);

        }

        for (int i = 0; i < cars.Count; i++)
        {
            cars[i].PrintInfo();
        }
    }
}
