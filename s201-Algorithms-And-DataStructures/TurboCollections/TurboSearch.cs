
namespace TurboCollections;

public class TurboSearch
{
    public static int BinarySearch(IList<IComparable> input, IComparable find)
    {
        
        int searchIndex = input.Count / 2;
        int toAddOrSubtract = input.Count / 4;

        while (searchIndex != -1 && searchIndex != input.Count)
        {
            if (input[searchIndex].Equals(find))
            {
                return searchIndex;
            }
            else if (input[searchIndex].CompareTo(find) < 0)
            {
                searchIndex += toAddOrSubtract;
                toAddOrSubtract = (int)(toAddOrSubtract * 0.5);
                if (toAddOrSubtract < 1)
                {
                    toAddOrSubtract = 1;
                }

                if (searchIndex != input.Count)
                {
                    if (input[searchIndex].CompareTo(find) < 0 && input[searchIndex - 1].CompareTo(find) > 0)
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            else if (input[searchIndex].CompareTo(find) > 0)
            {
                searchIndex -= toAddOrSubtract;
                toAddOrSubtract = (int)(toAddOrSubtract * 0.5);
                if (toAddOrSubtract < 1)
                {
                    toAddOrSubtract = 1;
                }

                if (searchIndex != -1)
                {
                    if (input[searchIndex].CompareTo(find) < 0 && input[searchIndex + 1].CompareTo(find) > 0)
                    {
                        return -1;
                    }
                }
            }
        }
        return -1;
    }

    public static int LinearSearch(IList<IComparable> input, IComparable search)
    {
        for (int i = 0; i < input.Count - 1; i++)
        {
            if (Equals(input[i], search))
            {
                return i;
            }
        }

        return -1;
    }
}