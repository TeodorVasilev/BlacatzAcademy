namespace Promotions
{
    public class Promotion
    {
        private decimal priceWithoutDiscount;
        private ClientType clientType;

        public Promotion(ClientType clientType, decimal priceWithoutDiscount)
        {
            this.clientType = clientType;
            this.priceWithoutDiscount = priceWithoutDiscount;
        }

        public decimal FinalPrice
        {
            get
            {
                decimal discountProcent = 0;
                switch (this.clientType.Level)
                {
                    case 2:
                        discountProcent = 0.15m;
                        break;
                    case 3:
                        discountProcent = 0.25m;
                        break;
                }

                return this.priceWithoutDiscount = this.priceWithoutDiscount * (1 - discountProcent);
            }
        }
    }
}
