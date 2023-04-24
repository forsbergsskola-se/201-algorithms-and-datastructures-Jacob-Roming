using System.Diagnostics;
using TurboCollections;

namespace SearchTest;

public class PerformanceTests
{
    [Test]
    public void FindNumbersInaBigList()
    {
        TurboList<IComparable?> testList = new TurboList<IComparable?>();
        for (int i = 0; i < 1_000_000; i++)
        {
            testList.Add(i);
        }

        Stopwatch timer = new Stopwatch();
        timer.Start();
        for (int i = 600_000; i < 601_010; i++)
        {
            TurboSearch.BinarySearch(testList, i);
        }
        timer.Stop();
        long BinarySearchResult = timer.ElapsedMilliseconds;
        timer.Reset();
        timer.Start();
        for (int i = 600_000; i < 601_010; i++)
        {
            TurboSearch.LinearSearch(testList, i);
        }
        timer.Stop();
        Assert.AreEqual(timer.ElapsedMilliseconds, BinarySearchResult, 0);
    }
    
    [Test]
    public void FindNumbersInaMediumList()
    {
        TurboList<IComparable?> testList = new TurboList<IComparable?>();
        for (int i = 0; i < 10_000; i++)
        {
            testList.Add(i);
        }

        Stopwatch timer = new Stopwatch();
        timer.Start();
        for (int i = 6_000; i < 6_110; i++)
        {
            TurboSearch.BinarySearch(testList, i);
        }
        timer.Stop();
        long BinarySearchResult = timer.ElapsedMilliseconds;
        timer.Reset();
        timer.Start();
        for (int i = 6_000; i < 6_110; i++)
        {
            TurboSearch.LinearSearch(testList, i);
        }
        timer.Stop();
        Assert.AreEqual(timer.ElapsedMilliseconds, BinarySearchResult, 0);
    }
    
    [Test]
    public void FindNumbersInaSmallList()
    {
        TurboList<IComparable?> testList = new TurboList<IComparable?>();
        for (int i = 0; i < 100; i++)
        {
            testList.Add(i);
        }

        Stopwatch timer = new Stopwatch();
        timer.Start();
        for (int i = 60; i < 81; i++)
        {
            TurboSearch.BinarySearch(testList, i);
        }
        timer.Stop();
        long BinarySearchResult = timer.ElapsedMilliseconds;
        timer.Reset();
        timer.Start();
        for (int i = 60; i < 81; i++)
        {
            TurboSearch.LinearSearch(testList, i);
        }
        timer.Stop();
        Assert.AreEqual(timer.ElapsedMilliseconds, BinarySearchResult, 0);
    }
}