using Microsoft.EntityFrameworkCore;
using MyMobile.DAL.Data;
using MyMobile.DAL.Models.CarAd;
using MyMobile.DAL.Models.CarAd.CarAdArgs;

using(var context = new MyMobileContext())
{
    var carAd = new CarAd
    {
        Name = "Opel Astra 1.6 GAZ",
        DefaultPriceBgn = 1000,
        UserPrice = 1000,
        CategoryId = 1,
        ConditionId = 1,
        CurrencyId = 1,
        RegionId = 1,
        TownId = 1
    };

    var otherCarAd = new CarAd
    {
        Name = "Opel Astra 1.6 GAZ",
        DefaultPriceBgn = 1050,
        UserPrice = 1050,
        CategoryId = 2,
        ConditionId = 1,
        CurrencyId = 1,
        RegionId = 1,
        TownId = 2
    };

    //context.CarAds.Add(carAd);
    //context.CarAds.Add(otherCarAd);
    //context.SaveChanges();

    var carAds = context.CarAds
        .Include(c => c.Category)
        .Include(c => c.Condition)
        .Include(c => c.Currency)
        .Include(c => c.Region)
        .Include(c => c.Town)
        .ToList();

    foreach (var item in carAds)
    {
        Console.WriteLine($"{item.Name}" +
            $"{item.Category.Type}" +
            $"{item.Condition.Type}" +
            $"{item.Region.Name}" + 
            $"{item.Town.Name}" + 
            $"{item.DefaultPriceBgn}" + 
            $"{item.Currency.Name}");
    }


}

