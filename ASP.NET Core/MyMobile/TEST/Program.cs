using Microsoft.EntityFrameworkCore;
using MyMobile.DAL.Data;
using MyMobile.DAL.Models.CarAd;
using MyMobile.DAL.Models.CarAd.CarAdArgs;

using (var context = new MyMobileContext())
{
    DateTime start = new DateTime();
    start = DateTime.Now; // zapisva se v bazata

    DateTime end = start.AddDays(7); //zapisva se kato data na iztichane

    Console.WriteLine(end);

    for (int i = 0; i < 9; i++)
    {
        start = start.AddDays(1);
        if(start > end)
        {
            Console.WriteLine("expired");
        }
        else
        {
            Console.WriteLine("active");
        }
    }
}

