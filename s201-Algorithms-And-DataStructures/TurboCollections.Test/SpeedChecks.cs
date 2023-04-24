using System.Diagnostics;

namespace TurboCollections.Test;

public class SpeedChecks
{
    [Test]
    public void ListRemoveMiddlePerformanceIsSimilarToDotNet()
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        for (int i = 0; i < 50; i++)
        {
            var list = new TurboList<int>();
            list.AddRange(Enumerable.Range(0, 1_000_000));
        }
        stopWatch.Stop();
        var elapsedTimeOurList = stopWatch.ElapsedMilliseconds;
        
        stopWatch.Reset();
        stopWatch.Start();
        
        for (int i = 0; i < 50; i++)
        {
            var list = new List<int>();
            list.AddRange(Enumerable.Range(0, 1_000_000));
        }
        stopWatch.Stop();
        
        Assert.AreEqual(stopWatch.ElapsedMilliseconds, elapsedTimeOurList, stopWatch.ElapsedMilliseconds / 10);
    }
    
    [Test]
    public void ListAddSingleVariable()
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        var listA = new TurboList<int>();
        for (int i = 0; i < 5_000_000; i++)
        {
            listA.Add(i);
        }
        stopWatch.Stop();
        var elapsedTimeOurList = stopWatch.ElapsedMilliseconds;
        
        stopWatch.Reset();
        stopWatch.Start();
        var listB = new TurboList<int>();
        for (int i = 0; i < 5_000_000; i++)
        {
            listB.Add(i);
        }
        stopWatch.Stop();
        
        Assert.AreEqual(stopWatch.ElapsedMilliseconds, elapsedTimeOurList, stopWatch.ElapsedMilliseconds / 5);
    }
    [Test]
    public void ListAddandRemoveAt()
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        var listA = new TurboList<int>();
        for (int i = 0; i < 5_000_000; i++)
        {
            
            listA.Add(i);
        }

        for (int i = 0; i < 100; i++)
        {
            listA.RemoveAt(10);
        } 
        stopWatch.Stop();
        var elapsedTimeOurList = stopWatch.ElapsedMilliseconds;
        
        stopWatch.Reset();
        stopWatch.Start();
        var listB = new TurboList<int>();
        for (int i = 0; i < 5_000_000; i++)
        {
            
            listB.Add(i);
        }
        for (int i = 0; i < 100; i++)
        {
            listB.RemoveAt(10);
        } 
        stopWatch.Stop();
        
        Assert.AreEqual(stopWatch.ElapsedMilliseconds, elapsedTimeOurList, stopWatch.ElapsedMilliseconds / 10);
    }
    
    [Test]
    public void ListAddandRemove()
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        var listA = new TurboList<int>();
        for (int i = 0; i < 5_000_000; i++)
        {
            
            listA.Add(i);
        }

        for (int i = 2; i < 500; i++)
        {
            listA.Remove(i);
        } 
        stopWatch.Stop();
        var elapsedTimeOurList = stopWatch.ElapsedMilliseconds;
        
        stopWatch.Reset();
        stopWatch.Start();
        var listB = new TurboList<int>();
        for (int i = 0; i < 5_000_000; i++)
        {
            
            listB.Add(i);
        }
        for (int i = 2; i < 500; i++)
        {
            listB.Remove(i);
        } 
        stopWatch.Stop();
        
        Assert.AreEqual(stopWatch.ElapsedMilliseconds, elapsedTimeOurList, stopWatch.ElapsedMilliseconds / 5);
    }
    
    [Test]
    public void ListIndexOf()
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        var listA = new TurboList<int>();
        for (int i = 0; i < 5_000_000; i++)
        {
            
            listA.Add(i);
        }

        for (int i = 1_000_000; i < 1_000_500; i++)
        {
            listA.IndexOf(i);
        } 
        stopWatch.Stop();
        var elapsedTimeOurList = stopWatch.ElapsedMilliseconds;
        
        stopWatch.Reset();
        stopWatch.Start();
        var listB = new TurboList<int>();
        for (int i = 0; i < 5_000_000; i++)
        {
            
            listB.Add(i);
        }
        for (int i = 1_000_000; i < 1_000_500; i++)
        {
            listB.IndexOf(i);
        } 
        stopWatch.Stop();
        
        Assert.AreEqual(stopWatch.ElapsedMilliseconds, elapsedTimeOurList, stopWatch.ElapsedMilliseconds / 25);
    }
}