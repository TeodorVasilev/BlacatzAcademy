using MyMobile.DAL.Models.ViewModels.Listings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMobile.DAL.Models.ViewModels.Pages
{
    public class MyAdsViewModel
    {
        public MyAdsViewModel()
        {
            CarAdViewModel = new ListingViewModel();
        }

        public ListingViewModel CarAdViewModel { get; set; }
    }
}
