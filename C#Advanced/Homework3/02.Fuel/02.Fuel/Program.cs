using _02.Fuel;


GasStation gasStation = new GasStation("GasStation1");

List<Fuel> fuels = new List<Fuel>()
{
    new Fuel("A95",1.50m),
    new Fuel("Diesel",1.86m),
    new Fuel("A98",2.00m),
};

gasStation.Fuels = fuels;

GasStation gasStation1 = new GasStation("GasStation2");

List<Fuel> fuels2 = new List<Fuel>()
{
    new Fuel("A95",1.80m),
    new Fuel("Diesel",1.90m),
    new Fuel("A98",2.12m),
};

gasStation1.Fuels = fuels2;

List<GasStation> stations = new List<GasStation>();
stations.Add(gasStation);
stations.Add(gasStation1);

GasStation lowestPriceStation = LowestPrice(stations);

Console.WriteLine($"{lowestPriceStation.Name}");
foreach (var item in lowestPriceStation.Fuels)
{
    Console.WriteLine($"{item.Type} - {item.Price}");
}

GasStation LowestPrice(List<GasStation> stations)
{
    decimal lowestAvgPrice = decimal.MaxValue;
    GasStation lowestPriceStation = null;

    foreach (var station in stations)
    {
        decimal averagePrice = station.Fuels.Average(f => f.Price);
        if(averagePrice < lowestAvgPrice)
        {
            lowestAvgPrice = averagePrice;
            lowestPriceStation = station;
        }
    }

    return lowestPriceStation;
}