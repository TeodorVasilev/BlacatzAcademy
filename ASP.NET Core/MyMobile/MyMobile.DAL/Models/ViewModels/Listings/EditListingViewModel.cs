using MyMobile.DAL.Models.ViewModels.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMobile.DAL.Models.ViewModels.Listings
{
    public class EditListingViewModel
    {
        public ListingViewModel ListingViewModel { get; set; }
        public CreateListingViewModel CreateListingViewModel { get; set; }
    }
}
