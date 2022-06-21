namespace _3.Bench
{
    public class Worker
    {
        public void FixBenchesInPark(Park park)
        {
            for (int i = 0; i < park.Benches.Count; i++)
            {
                if(park.Benches[i].IsBroken == true)
                {
                    park.Benches[i].IsBroken = false;
                }
            }
        }
    }
}
