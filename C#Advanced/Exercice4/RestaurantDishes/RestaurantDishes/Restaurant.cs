namespace RestaurantDishes
{
    public class Restaurant
    {
        public Restaurant(string name)
        {
            this.Name = name;
            this.Dishes = new List<Dish>();
        }

        public string Name { get; set; }
        public List<Dish> Dishes = new List<Dish>(); 
    }
}
