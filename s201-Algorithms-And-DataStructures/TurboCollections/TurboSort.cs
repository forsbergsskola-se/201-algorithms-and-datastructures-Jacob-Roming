namespace TurboCollections;

public static partial class TurboSort
{
    

    

    public static void SelectionSort(TurboList<int> input)
    {
        if (input.Count == 0)
        {
            return;
        }
        TurboList<int> tempList = new TurboList<int>();
        
        while (input.Count != 0)
        {
            int lowestValue = input.Get(0);
            for (int i = 0; i < input.Count; i++)
            {


                if (input.Get(i) < lowestValue)
                {
                    lowestValue = input.Get(i);
                }
                
            }

            input.Remove(lowestValue);
            tempList.Add(lowestValue);
        }

        foreach (var variable in tempList)
        {
            input.Add(variable);//This feels kinda dumb to do, but I cant think of a better way
        }

    }
}