namespace TurboCollections;

public partial class TurboSort
{
    public static void BubbleSort(TurboList<int> list)
    {
        bool noSwapsThisLoop = true;
        do
        {
            noSwapsThisLoop = true;
            
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list.Get(i) > list.Get(i + 1))
                {
                    int temp = list.Get(i + 1);
                    list.Set(i+1,list.Get(i));
                    list.Set(i,temp);
                    noSwapsThisLoop = false;
                }
            }

        } while (!noSwapsThisLoop);
    }
}