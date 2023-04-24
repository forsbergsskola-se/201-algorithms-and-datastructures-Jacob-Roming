namespace TurboCollections;

public static partial class TurboSort
{
    public static void ReverseQuickSort(IList<IComparable> input, int left, int right)
    {
        if (input.Count == 0)
        {
            return;
        }
        int leftIndex = left;
        int rightIndex = right;
        IComparable pivot = input[(left+right) / 2];
        while (leftIndex <= rightIndex)
        {
            while (input[leftIndex].CompareTo(pivot) > 0)//How does this avoid index out of bounds?
            {
                leftIndex++;
            }
        
            while (input[rightIndex].CompareTo(pivot) < 0) //Same for this, it makes no sense
            {
                rightIndex--;
            }
            if (leftIndex <= rightIndex)
            {
                (input[leftIndex], input[rightIndex]) = (input[rightIndex], input[leftIndex]);
                leftIndex++;
                rightIndex--;
            }
        }

        if (left < rightIndex)
        {
            QuickSort(input, left, rightIndex);
        }

        if (leftIndex < right)
        {
            QuickSort(input, leftIndex, right);
        }
    }
}