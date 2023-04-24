using TurboCollections;

namespace SortingTests;

public class SelectionSortTest
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
        TurboSort.SelectionSort(testList);
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
    public void SortTestShortList()
    {
        TurboList<int> testList = new TurboList<int>();
        testList.Add(40);
        testList.Add(2);
        TurboSort.SelectionSort(testList);
        TurboList<int> controlList = new TurboList<int>();
        controlList.Add(2);
        controlList.Add(40);
        Assert.That(testList, Is.EqualTo(controlList));
    }
    
    [Test]
    public void SortTestSingleValue()
    {
        TurboList<int> testList = new TurboList<int>();
        testList.Add(40);
        TurboSort.SelectionSort(testList);
        TurboList<int> controlList = new TurboList<int>();
        controlList.Add(40);
        Assert.That(testList, Is.EqualTo(controlList));
    }
    
    [Test]
    public void SortTestEmptyList()
    {
        TurboList<int> testList = new TurboList<int>();
        TurboSort.SelectionSort(testList);
        TurboList<int> controlList = new TurboList<int>();
        Assert.That(testList, Is.EqualTo(controlList));
    }
    
    [Test]
    public void SortTestHugeList()
    {
        TurboList<int> testList = new TurboList<int>();
        for (int i = 1_000; i > -1; i--)
        {
            testList.Add(i);
        }
        TurboSort.SelectionSort(testList);
        TurboList<int> controlList = new TurboList<int>();
        for (int i = 0; i < 1_001; i++)
        {
            controlList.Add(i);
        }
        Assert.That(testList, Is.EqualTo(controlList));
    }
}