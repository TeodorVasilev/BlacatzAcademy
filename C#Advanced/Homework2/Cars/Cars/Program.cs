using Cars;

Engine engine = new Engine();

Console.WriteLine(engine.Drive(190000));
Console.WriteLine(engine.Mileage);
Console.WriteLine(engine.Drive(15000));
Console.WriteLine(engine.Mileage);
Console.WriteLine(engine.Drive(10000));
Console.WriteLine(engine.Mileage);
Console.WriteLine(engine.Drive(1));
Console.WriteLine(engine.Mileage);
Console.WriteLine(engine.Drive(2));
Console.WriteLine(engine.Mileage);