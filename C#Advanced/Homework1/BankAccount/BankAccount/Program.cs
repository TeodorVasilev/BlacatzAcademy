using Bank_Account;

BankAccount account = new BankAccount();

string input = Console.ReadLine();
while (input.ToLower() != "end")
{
    string[] data = input.Split();
    string command = data[0];

    if(command.ToLower() == "deposit")
    {
        decimal money = decimal.Parse(data[1]);
        account.Deposit(money);
        Console.WriteLine($"{money:f2} succesfully added into your account");
    }
    else if(command.ToLower() == "widthdraw")
    {
        try
        {
            decimal money = decimal.Parse(data[1]);
            account.Widthraw(money);
            Console.WriteLine($"{money:f2} withdrawn");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    else if(command.ToLower() == "balance")
    {
        Console.WriteLine($"Your current balance: {account.Balance:f2}");
    }

    input = Console.ReadLine();
}