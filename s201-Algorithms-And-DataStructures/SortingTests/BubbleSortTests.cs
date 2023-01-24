using TurboCollections;

namespace SortingTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

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
        TurboSort.BubbleSort(testList);
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
        TurboSort.BubbleSort(testList);
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
        TurboSort.BubbleSort(testList);
        TurboList<int> controlList = new TurboList<int>();
        controlList.Add(40);
        Assert.That(testList, Is.EqualTo(controlList));
    }
    
    [Test]
    public void SortTestEmptyList()
    {
        TurboList<int> testList = new TurboList<int>();
        TurboSort.BubbleSort(testList);
        TurboList<int> controlList = new TurboList<int>();
        Assert.That(testList, Is.EqualTo(controlList));
    }
    
    [Test]
    public void SortTestHugeList()
    {
        TurboList<int> testList = new TurboList<int>();
        for (int i = 100_000; i > -1; i--)
        {
            testList.Add(i);
        }
        TurboSort.BubbleSort(testList);
        TurboList<int> controlList = new TurboList<int>();
        for (int i = 0; i < 100_001; i++)
        {
            controlList.Add(i);
        }
        Assert.That(testList, Is.EqualTo(controlList));
    }
    
}