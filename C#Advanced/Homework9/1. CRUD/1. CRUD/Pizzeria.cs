namespace _1._CRUD
{
    public class Pizzeria
    {
        public Pizzeria()
        {
            this.Products = new List<Pizza>();
        }

        public List<Pizza> Products { get; set; }
        public void Show()
        {
            for (int i = 0; i < this.Products.Count; i++)
            {
                var pizza = this.Products[i];

                Console.WriteLine($"{i + 1}. {pizza.Name} - {pizza.Price}$");
                Console.WriteLine("Ingredients: ");
                foreach (var ingredient in pizza.Ingredients)
                {
                    Console.WriteLine($"- {ingredient}");
                }
            }
        }

        public void Add(string name, decimal price, int quantity, List<string> ingredients)
        {
            var pizza = new Pizza(name, price, quantity, ingredients);
            this.Products.Add(pizza);
        }

        public void Update(string name)
        {
            var pizza = this.Products.Where(p => p.Name == name).FirstOrDefault();
            if(pizza == null)
            {
                Console.WriteLine("Not found");
                return;
            }
        }

        public void Delete(string name)
        {
            var pizza = this.Products.Where(p => p.Name == name).FirstOrDefault();
            if(pizza != null)
                this.Products.Remove(pizza);
            else
                Console.WriteLine("Not found");

        }
    }
}
