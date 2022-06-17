namespace Bank_Account
{
    public class BankAccount
    {
        public decimal Balance { get; set; }

        public void Deposit(decimal money)
        {
            this.Balance += money;
        }

        public void Widthraw(decimal money)
        {
            if(this.Balance >= money)
            {
                this.Balance -= money;
            }
            else
            {
                throw new Exception("Insufficient balance");
            }
        }

        public decimal ShowBalance()
        {
            return this.Balance;
        }
    }
}
