using System.Collections;

namespace TurboCollections;

public partial class TurboSearch
{
    public static object? BinarySearch(TurboList<IComparable?> input, IComparable find)
    {
        
        int searchIndex = input.Count / 2;
        int toAddOrSubtract = input.Count / 4;

        while (searchIndex != -1 && searchIndex != input.Count)
        {
            if (input.Get(searchIndex)!.Equals(find))
            {
                return input.Get(searchIndex);
            }
            else if (input.Get(searchIndex).CompareTo(find) < 0)
            {
                searchIndex += toAddOrSubtract;
                toAddOrSubtract = (int)(toAddOrSubtract * 0.5);
                if (toAddOrSubtract < 1)
                {
                    toAddOrSubtract = 1;
                }
            }
            else if (input.Get(searchIndex).CompareTo(find) > 0)
            {
                searchIndex -= toAddOrSubtract;
                toAddOrSubtract = (int)(toAddOrSubtract * 0.5);
                if (toAddOrSubtract < 1)
                {
                    toAddOrSubtract = 1;
                }
            }
        }

        return null;

    }
}