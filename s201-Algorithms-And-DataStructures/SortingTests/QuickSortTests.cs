using TurboCollections;

namespace SortingTests;

public class QuickSortTests
{
    [Test]
    public void SortTest()
    {
        TurboList<int> testList = new TurboList<int>();
        testList.Add(40);
        testList.Add(2);
        testList.Add(999);
        testList.Add(-5);
        testList.Add(50);
        testList.Add(5);
        TurboSort.QuickSort(testList, 0, testList.Count-1);
        TurboList<int> controlList = new TurboList<int>();
        controlList.Add(-5);
        controlList.Add(2);
        controlList.Add(5);
        controlList.Add(40);
        controlList.Add(50);
        controlList.Add(999);
        Assert.That(testList, Is.EqualTo(controlList));
    }
    
    [Test]
    public void SortTestHugeList()
    {
        TurboList<int> testList = new TurboList<int>();
        for (int i = 10_000; i > -1; i--)
        {
            testList.Add(i);
        }
        TurboSort.QuickSort(testList, 0, testList.Count - 1);
        TurboList<int> controlList = new TurboList<int>();
        for (int i = 0; i < 10_001; i++)
        {
            controlList.Add(i);
        }
        Assert.That(testList, Is.EqualTo(controlList));
    }
    
    [Test]
    public void SortTestEmptyList()
    {
        TurboList<int> testList = new TurboList<int>();
        TurboSort.QuickSort(testList,0,0);
        TurboList<int> controlList = new TurboList<int>();
        Assert.That(testList, Is.EqualTo(controlList));
    }

    [Test]
    public void SortTestSingleValue()
    {
        TurboList<int> testList = new TurboList<int>();
        testList.Add(40);
        TurboSort.QuickSort(testList,0,testList.Count - 1);
        TurboList<int> controlList = new TurboList<int>();
        controlList.Add(40);
        Assert.That(testList, Is.EqualTo(controlList));
    }
    
    [Test]
    public void SortTestShortList()
    {
        TurboList<int> testList = new TurboList<int>();
        testList.Add(40);
        testList.Add(2);
        TurboSort.QuickSort(testList,0, testList.Count - 1);
        TurboList<int> controlList = new TurboList<int>();
        controlList.Add(2);
        controlList.Add(40);
        Assert.That(testList, Is.EqualTo(controlList));
    }

}