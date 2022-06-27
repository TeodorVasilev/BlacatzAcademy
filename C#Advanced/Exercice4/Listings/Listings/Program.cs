using Listings;

List<Listing> listings = new List<Listing>()
{
    new Listing(2, "Pechka"),
    new Listing(1, "Divan"),
    new Listing(2, "Akumulator"),
    new Listing(1, "Televizor"),
    new Listing(2, "Hladilnik"),
    new Listing(1, "Telefon"),
    new Listing(2, "Boiler")
};

var groupedListings = listings.GroupBy(
    x => x.CategoryId).ToDictionary(x => x.Key, x => x.ToList());