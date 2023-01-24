namespace TurboCollections;

public partial class TurboSort
{
    public static void QuickSort(TurboList<int> input, int left, int right)
    {
        if (input.Count == 0)
        {
            return;
        }
        int leftIndex = left;
        int rightIndex = right;
        int pivot = input.Get(left);
        while (leftIndex <= rightIndex)
        {
            while (input.Get(leftIndex) < pivot)//How does this avoid index out of bounds?
            {
                leftIndex++;
            }
        
            while (input.Get(rightIndex) > pivot) //Same for this, it makes no sense
            {
                rightIndex--;
            }
            if (leftIndex <= rightIndex)
            {
                int temp = input.Get(leftIndex);
                input.Set(leftIndex, input.Get(rightIndex));
                input.Set(rightIndex, temp);
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