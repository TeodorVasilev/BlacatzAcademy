﻿namespace MyMobile.DAL.Models.CarAd.CarAdArgs
{
    public class Condition
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public ICollection<Listing> CarAds { get; set; }
    }
}
