using _2.Headphones;

public class Program
{
    public static void Main()
    {
        List<Headphone> headphones = new List<Headphone>();
        headphones.Add(new Headphone(50.0));
        headphones.Add(new Headphone(20.0));
        headphones.Add(new Headphone(35.0));
        headphones.Add(new Headphone(40.0));
        headphones.Add(new Headphone(60.0));
        headphones.Add(new Headphone(15.0));
        headphones.Add(new Headphone(32.0));

        Console.WriteLine(GetHeadphoneWithMaxVolume(headphones).MaxVolume);
    }

    public static Headphone GetHeadphoneWithMaxVolume(List<Headphone> headphones)
    {
        double maxVolume = 0;
        int index = -1;
        for (int i = 0; i < headphones.Count; i++)
        {
            if(headphones[i].MaxVolume > maxVolume)
            {
                maxVolume = headphones[i].MaxVolume;
                index = i;
            }
        }

        return index != 1 ? headphones[index] : new Headphone(0);
    }
}