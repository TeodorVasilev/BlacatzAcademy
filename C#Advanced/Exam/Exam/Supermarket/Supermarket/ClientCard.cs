namespace Supermarket
{
    public class ClientCard
    {
        public ClientCard(string id)
        {
            this.Id = id;
        }

        public string Id { get; set; }

        public decimal GetDiscount(decimal price)
        {
            decimal discount = 0;

            if(price <= 10000)
            {
                discount = 0.03m;
            }
            else if(price > 10000 && price <= 50000)
            {
                discount = 0.05m;
            }
            else if(price > 50000)
            {
                discount = 0.10m;
            }

            return discount;
        }
    }
}
