using RestaurantDishes;

Restaurant restaurant1 = new Restaurant("Dunav most");
Dish piza1 = new Dish("Pizza 1");
piza1.Ingredients.Add(new Ingredient("Ingredient 1"));
piza1.Ingredients.Add(new Ingredient("Ingredient 2"));
piza1.Ingredients.Add(new Ingredient("Ingredient 3"));
restaurant1.Dishes.Add(piza1);

Restaurant restaurant2 = new Restaurant("Dunav most 2");
Dish pizza2 = new Dish("Pizza 2"); 
pizza2.Ingredients.Add(new Ingredient("Ingredient 4"));
pizza2.Ingredients.Add(new Ingredient("Ingredient 2"));
pizza2.Ingredients.Add(new Ingredient("Ingredient 3"));
pizza2.Ingredients.Add(new Ingredient("Ingredient 5"));
restaurant2.Dishes.Add(pizza2);

string searchIngradient = Console.ReadLine();
List<Restaurant> restaurants = new List<Restaurant>{restaurant1, restaurant2};

foreach (var restaurant in restaurants)
{
    foreach (var dish in restaurant.Dishes)
    {
        if(dish.Ingredients.Any(i => i.Name == searchIngradient))
        {
            Console.WriteLine(restaurant.Name);
            Console.WriteLine(dish.Name);
            Console.WriteLine(String.Join(", ", dish.Ingredients.Select(i => i.Name)));
        }
    }
}