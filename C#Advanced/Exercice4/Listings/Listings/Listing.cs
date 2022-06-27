namespace Listings
{
    public class Listing
    {
        public Listing(int categoryId, string name)
        {
            this.CategoryId = categoryId;
            this.Name = name;
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
