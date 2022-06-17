using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentPriceCalculation
{
    public class Apartment
    {
        private readonly decimal price;

        public Apartment(double quadrature, decimal squareMeterPrice)
        {
            this.Quadrature = quadrature;
            this.SquareMeterPrice = squareMeterPrice;
            this.price = squareMeterPrice * (decimal)this.Quadrature;
        }

        public double Quadrature { get; set; }

        public decimal SquareMeterPrice { get; set; }

        public decimal GetPrice()
        {
            return this.price;
        }
    }
}
