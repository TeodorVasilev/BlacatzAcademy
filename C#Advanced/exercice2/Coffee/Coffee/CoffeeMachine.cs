namespace Coffee
{
    public class CoffeeMachine
    {
        private int shortCoffee;
        private int coffee;
        private int tea;

        public CoffeeMachine(int shortCoffee, int coffee, int tea)
        {
            this.shortCoffee = shortCoffee;
            this.coffee = coffee;
            this.tea = tea;
        }

        public void MakeDrink(string drink)
        {
            switch (drink)
            {
                case "coffee":
                    this.coffee -= 1;
                    break;
                case "shortCoffee":
                    this.shortCoffee -= 1;
                    break;
                case "tea":
                    this.tea -= 1;
                    break;
            }
        }
    }
}
