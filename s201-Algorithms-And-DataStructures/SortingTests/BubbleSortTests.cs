using TurboCollections;

namespace SortingTests;

public class BubbleTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void SortTest()
    {
        TurboList<IComparable> testList = new TurboList<IComparable>();
        testList.Add(40);
        testList.Add(2);
        testList.Add(999);
        testList.Add(-5);
        testList.Add(50);
        testList.Add(5);
        TurboSort.BubbleSort(testList);
        TurboList<IComparable> controlList = new TurboList<IComparable>();
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
        TurboList<IComparable> testList = new TurboList<IComparable>();
        testList.Add(40);
        testList.Add(2);
        TurboSort.BubbleSort(testList);
        TurboList<IComparable> controlList = new TurboList<IComparable>();
        controlList.Add(2);
        controlList.Add(40);
        Assert.That(testList, Is.EqualTo(controlList));
    }
    
    [Test]
    public void SortTestSingleValue()
    {
        TurboList<IComparable> testList = new TurboList<IComparable>();
        testList.Add(40);
        TurboSort.BubbleSort(testList);
        TurboList<IComparable> controlList = new TurboList<IComparable>();
        controlList.Add(40);
        Assert.That(testList, Is.EqualTo(controlList));
    }
    
    [Test]
    public void SortTestEmptyList()
    {
        TurboList<IComparable> testList = new TurboList<IComparable>();
        TurboSort.BubbleSort(testList);
        TurboList<IComparable> controlList = new TurboList<IComparable>();
        Assert.That(testList, Is.EqualTo(controlList));
    }
    
    [Test]
    public void SortTestHugeList()
    {
        TurboList<IComparable> testList = new TurboList<IComparable>();
        for (int i = 1_000; i > -1; i--)
        {
            testList.Add(i);
        }
        TurboSort.BubbleSort(testList);
        TurboList<IComparable> controlList = new TurboList<IComparable>();
        for (int i = 0; i < 1_001; i++)
        {
            controlList.Add(i);
        }
        Assert.That(testList, Is.EqualTo(controlList));
    }
    
}