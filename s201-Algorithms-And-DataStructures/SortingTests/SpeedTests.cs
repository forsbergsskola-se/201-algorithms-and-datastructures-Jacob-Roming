using System.Diagnostics;
using TurboCollections;

namespace SortingTests;

public class SpeedTests
{
    [Test]
    public void SortTestHugeList()
    {
        Stopwatch timer = new Stopwatch();
        
        TurboList<IComparable> testList = new TurboList<IComparable>();
        for (int i = 10_000; i > -1; i--)
        {
            testList.Add(i);
        }
        timer.Start();
        TurboSort.QuickSort(testList, 0, testList.Count - 1);
        timer.Stop();
        long firstResult = timer.ElapsedMilliseconds;
        timer.Reset();
        
        
        TurboList<IComparable> quickList = new TurboList<IComparable>();
        for (int i = 10_000; i > -1; i--)
        {
            quickList.Add(i);
        }
        timer.Start();
        TurboSort.QuickSort(quickList, 0, quickList.Count-1);
        timer.Stop();
        long secondResult = timer.ElapsedMilliseconds;

        Assert.AreEqual(firstResult, secondResult, 0);
    }
    
    [Test]
    public void SortTest()
    {
        Stopwatch timer = new Stopwatch();
        TurboList<IComparable> testList = new TurboList<IComparable>();
        timer.Start();
        for (int i = 0; i < 100; i++)
        {
            testList.Add(40);
            testList.Add(2);
            testList.Add(999);
            testList.Add(-5);
            testList.Add(50);
            testList.Add(5);
            TurboSort.QuickSort(testList, 0, testList.Count - 1);
        }

        timer.Stop();
        long firstResult = timer.ElapsedMilliseconds;
        timer.Reset();
        timer.Start();
        for (int i = 0; i < 100; i++)
        {
            TurboList<IComparable> controlList = new TurboList<IComparable>();
            testList.Add(40);
            testList.Add(2);
            testList.Add(999);
            testList.Add(-5);
            testList.Add(50);
            testList.Add(5);
            TurboSort.BubbleSort(testList);
        }

        timer.Stop();
        long secondResult = timer.ElapsedMilliseconds;
        timer.Reset();
        Assert.AreEqual(firstResult, secondResult, 0);
    }
    
    
    [Test]
    public void RandomSortTest()
    {
        Stopwatch timer = new Stopwatch();
        TurboList<IComparable> testList = new TurboList<IComparable>();
        TurboList<IComparable> controlList = new TurboList<IComparable>();
        Random rand = new Random();
        timer.Start();
        for (int i = 0; i < 1_000; i++)
        {
            int number = rand.Next(0, 1000000);
            testList.Add(number);
            controlList.Add(number);
        }
        timer.Start();
        TurboSort.QuickSort(testList,0,testList.Count - 1);
        timer.Stop();
        long firstResult = timer.ElapsedMilliseconds;
        timer.Reset();
        timer.Start();
        TurboSort.BubbleSort(controlList);
        timer.Stop();
        long secondResult = timer.ElapsedMilliseconds;
        timer.Reset();
        Assert.AreEqual(firstResult, secondResult, 0);
    }
    
    
}