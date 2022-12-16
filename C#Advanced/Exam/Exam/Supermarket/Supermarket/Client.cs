namespace Supermarket
{
    public class Client
    {
        public Client(string firstName, string lastName, string id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = id;
            this.Cart = new List<Product>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
        public ClientCard ClientCard { get; set; }
        public List<Product> Cart { get; set; }

        public override string ToString()
        {
            return $"Id: {this.Id} - Name: {this.FirstName} {this.LastName}";
        }
    }
}
