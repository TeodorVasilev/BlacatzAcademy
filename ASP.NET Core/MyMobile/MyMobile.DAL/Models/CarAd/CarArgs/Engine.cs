﻿namespace MyMobile.DAL.Models.CarAd.CarArgs
{
    public class Engine
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public ICollection<CarAd> CarAds { get; set; }
    }
}