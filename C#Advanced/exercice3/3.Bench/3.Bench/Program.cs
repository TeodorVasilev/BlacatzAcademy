using _3.Bench;

Park park = new Park();

park.Benches.Add(new Bench(true));
park.Benches.Add(new Bench(true));
park.Benches.Add(new Bench(true));
park.Benches.Add(new Bench(false));
park.Benches.Add(new Bench(true));

//Worker worker = new Worker();
//worker.FixBenchesInPark(park);

 park.Benches.Select(bench =>
{
    if(bench.IsBroken)
    {
        bench.IsBroken = false;
    }

    return bench;
}).ToList();    

Console.WriteLine();