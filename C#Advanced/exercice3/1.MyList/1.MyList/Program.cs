using _1.MyList;

MyList mylist = new MyList();
mylist.Add(1);
mylist.Add(2);
mylist.Add(3);
mylist.Add(4);
mylist.Add(5);
mylist.Add(6);
mylist.Add(7);
mylist.Remove(5);

for (int i = 0; i < mylist.Count; i++)
{
    Console.WriteLine(mylist[i]);
}