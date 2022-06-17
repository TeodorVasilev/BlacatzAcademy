using Promotions;

ClientType clientType = new ClientType();

Promotion noDiscount = new Promotion(clientType, 5);
Console.WriteLine(noDiscount.FinalPrice);
clientType.Level = 2;
Promotion smalDiscount = new Promotion(clientType, 5);
Console.WriteLine(smalDiscount.FinalPrice);
clientType.Level = 3;
Promotion mediumDiscount = new Promotion(clientType, 5);
Console.WriteLine(mediumDiscount.FinalPrice);
