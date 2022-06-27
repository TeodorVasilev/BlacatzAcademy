namespace RestaurantDishes
{
    public class Dish
    {
        public Dish(string name)
        {
            this.Name = name;
            this.Ingredients = new List<Ingredient>();
        }
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
    }
}
