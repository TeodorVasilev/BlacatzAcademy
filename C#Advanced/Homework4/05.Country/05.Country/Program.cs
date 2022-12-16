using _05.Country;

List<Country> countries = new List<Country>();

countries.Add(new Country("Country1"));
countries.Add(new Country("Country2"));

countries[0].Cities.Add(new City("City1"));
countries[0].Cities.Add(new City("City2"));
countries[0].Cities.Add(new City("City3"));

countries[1].Cities.Add(new City("City4"));
countries[1].Cities.Add(new City("City5"));
countries[1].Cities.Add(new City("City6"));

List<City> citiesByCountry = GetCitiesByCountry(Console.ReadLine(), countries);

foreach (var city in citiesByCountry)
{
    Console.WriteLine(city.Name);
}

List<City> GetCitiesByCountry(string country, List<Country> countries)
{
    List<City> cities = countries.Where(x => x.Name == country).FirstOrDefault().Cities.ToList();

    return cities;
}