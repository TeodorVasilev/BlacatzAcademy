using Users;

List<User> users = new List<User>()
{
    new User(1, "Pesho"),
    new User(2, "Gosho"),
    new User(3, "Mima"),
    new User(4, "Ivan"),
    new User(5, "Penka"),
    new User(6, "Stoqn"),
    new User(7, "Penko"),
    new User(8, "Dancho"),
};

int searchId = int.Parse(Console.ReadLine());

User user = users.Where(x => x.Id == searchId).FirstOrDefault();

Console.WriteLine(user.Name);
