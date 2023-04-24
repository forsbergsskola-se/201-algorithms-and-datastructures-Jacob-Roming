namespace TurboCollections;

public static partial class TurboSort
{
    public static void BubbleSort(IList<IComparable> list)
    {
        bool noSwapsThisLoop = true;
        do
        {
            noSwapsThisLoop = true;
            
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i].CompareTo(list[i+1]) > 0)
                {
                    IComparable temp = list[i+1];
                    list[i+1] = list[i];
                    list[i] = temp;
                    noSwapsThisLoop = false;
                }
            }

        } while (!noSwapsThisLoop);
    }
}