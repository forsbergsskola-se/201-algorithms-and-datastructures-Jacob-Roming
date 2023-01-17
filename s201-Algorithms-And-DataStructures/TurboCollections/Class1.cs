namespace TurboCollections;

public static class TurboMaths
{
    public static void SayHello()
    {
        Console.WriteLine($"Hello, I'm {typeof(TurboMaths)}");
    }
    
    public static List<int> GetOddNumbersList(int maxNumber)
    {

        List<int> toReturn = new List<int>();
        for (int i = 0; i < maxNumber; i++)
        {
            if (i % 2 == 1)
            {
                toReturn.Add(i);
            }
        }
        return toReturn;
    }
    
    public static IEnumerable<int> GetOddNumbers(int maxNumber){
        for (int i = 0; i < maxNumber; i++)
        {
            if (i % 2 == 1)
            {
                yield return i;
            }
        }
    }
}