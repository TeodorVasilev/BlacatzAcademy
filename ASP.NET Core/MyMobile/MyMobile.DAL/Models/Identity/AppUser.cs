using Microsoft.AspNetCore.Identity;
using MyMobile.DAL.Models.CarAd.CarAdArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMobile.DAL.Models.Identity
{
    public class AppUser : IdentityUser<int>
    {
        public string? FirstName  { get; set; }
        public string? LastName { get; set; }
        public string? Adress { get; set; }

        public ICollection<Listing> CarAds { get; set; }//
    }
}
