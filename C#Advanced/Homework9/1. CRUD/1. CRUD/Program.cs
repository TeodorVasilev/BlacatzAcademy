using _1._CRUD;

var pizza = new Pizza("pica", 10, 10);
pizza.Ingredients.Add("magdanos");
pizza.Ingredients.Add("djodjen");

var pizzeria = new Pizzeria();
pizzeria.Products.Add(pizza);

pizzeria.Show();

static void ShowMenu()
{
    Console.WriteLine("1. Show all pizzas");
    Console.WriteLine("2. Add new pizza");
    Console.WriteLine("3. Update pizza");
    Console.WriteLine("4. Delete pizza");
}